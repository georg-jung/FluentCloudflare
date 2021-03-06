# Changelog

## v0.3.0

* **New**: Proper handling of errors returned as part of responses of the Cloudflare API. This includes a new `ResponseHasErrorsException` type (inheriting `CloudflareException`), which will be thrown if the response's errors field is not null or empty on `CallAsync` or `EnsureSuccess`. This exception type provides an `Errors` property.
* **New**: Cache purging by URL and purge everything


## v0.2.1

* This now targets JSON.Net 11.0.1 and Microsoft.CSharp 4.0.1 to achieve broader compatibility
  * When consuming this library you can of course update to the newest versions of the dependencies. Newer versions are not *required* though, which is why I target lower versions. [MSDN on Dependencies](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/dependencies)
* **Fix**: When sending GET-requests, empty bodies and bodies like "{}" are not sent anymore - they are pointless. This fixes using these methods on the "full" .Net Framework. See https://github.com/dotnet/corefx/issues/28135


## v0.1.7

* **New**: Support for [SourceLink](https://github.com/dotnet/sourcelink)
* **Fix**: Replace deprecated `PackageIconUrl` with `PackageIcon`


## v0.1.6

Logo added to package.


## v0.1.5

### Updating

* Replace calls to `SendAsync` with `ParseAsync`
* If you declared variables containing partly-built API Methods not using var but using `IApiMethod<TEntity>` you need to change the declaration as outlined below.

### Breaking Changes

* The three methods-to-use for making API Calls are now `SendAsync`, `ParseAsync` and, most importantly, `CallAsync` (via Extension). `ParseAsync` is now, what `SendAsync` was before. Sorry for the inconvenience.
  * `SendAsync` is the most raw option and returns the plain `HttpResponseMessage` for further custom processing.
  * `ParseAsync` parses the response message as before, in the most commen case as a `Response<TEntity>`. `ParseAsync` is built on top of `SendAsync`.
  * `CallAsync` is built on top of `ParseAsync`. It just returns the result inside `Response<TEntity>.Result` and throws if the response does not indicate success. Possibly this is the method you want to call in most cases. Be sure add `using FluentCloudflare.Extensions;`.
  * This new architecture allows for more flexibility, which is needed i.e. for `Dns.Export`. Until now just API methods which returned a standard json response were supported. This is now modular.
* What formely was `IApiMethod<TEntity>` now is `IResponseApiMethod<TEntity>`, indicating it is an API method that has a standard json-response type of answer format. The new `IApiMethod` and `IApiMethod<T>` are more general. This would even allow using the same architecture for other non-Cloudflare APIs
  * `IApiMethod` supports `SendAsync`
  * `IApiMethod<TPayload>` additionally supports `ParseAsync`
  * `IResponseApiMethod<TEntity>` additionally supports `CallAsync`
* `IOrderedSyntax` now is an interface on it's own and is not integrated into `IPaginatedSyntax` anymore. Cloudflare's API has endpoints which support paging but don't support ordering by a field.

### New Features

* Accounts: Get and List
* Zone: Create


## v0.1.3

### Breaking Changes

* Classes `AuthorizedBuilder`, `ListBuilderBase`, `ZoneBuilder`, `ApiMethod<TEntity>` and `ApiMethodBase<TEntity>` which meant to be internal in the first place are `internal` now. If you use the API as documented this is of no relevance for you. If you used them/want to extend the API by inheritance/etc. feel free to open an issue to discuess this. Currently, my priority is to keep the public API surface as small as possible to let it be as stable as possible.

### New Features

* Origin CA: List & Get
  * including the needed support for using `X-Auth-User-Service-Key`

### Fixes

* `/?` is just appended to request query strings if needed.