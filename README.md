# FluentCloudflare

[![Build Status](https://dev.azure.com/georg-jung/FluentCloudflare/_apis/build/status/georg-jung.FluentCloudflare?branchName=master)](https://dev.azure.com/georg-jung/FluentCloudflare/_build/latest?definitionId=4&branchName=master)
[![NuGet version (FluentCloudflare)](https://img.shields.io/nuget/v/FluentCloudflare.svg?style=flat)](https://www.nuget.org/packages/FluentCloudflare/)


This .Net Standard 2.0 library makes it easy to consume the [Cloudflare REST API v4](https://api.cloudflare.com/) using a fluent syntax. It helps you with building the requests and parsing the results with ease. Bring your own `HttpClient`.

Please note this is currently in active development and the API is likely to change.

## Getting Started

* [NuGet Package](https://www.nuget.org/packages/FluentCloudflare/)
  * `PM> Install-Package FluentCloudflare`

```c#
using var hc = new HttpClient();
var context = Cloudflare.WithToken(YourApiToken); // or .WithKey(ApiKey, "you@example.com");

// Get all zones of all accounts which exactly match the given name - in this case exactly one.
var zones = await context.Zones.List()
    .WithName("cloudflare-api-debug.com")
    .CallAsync(hc);
var zone = zones.First();

// We dont need to start every request from scratch.
var zoneCtx = context.Zone(zone.Id);
var dns = zoneCtx.Dns;

// Notice the call to SendAsync instead of CallAsync. This way we dont get the
// result contained in the response but the whole response.
// Actually, CallAsync is an extension method in FluentCloudflare.Extensions which uses SendAsync internally.
var recordsResponse = await dns.List().PerPage(100).SendAsync(hc);
if (recordsResponse.ResultInfo.TotalCount > 100)
    Console.WriteLine("We got more than 100 DNS records! We may want to get more of them using paging...");

var records = recordsResponse.Unpack(); // or recordsResponse.Result, skipping validation of the call's success
var first = records.First();

await dns.Delete(first).CallAsync(hc);
await dns.Create(first.Type, $"new-{first.Name}", first.Content).CallAsync(hc);
```

## Features / Scope

The Cloudflare API offers quite many methods. While this library offers multiple layers of abstraction, making it easily extendable, it does not support the full API on the highest level. Supporting bigger parts of the API is subject to active development. Feel free to contribute and send PRs.

Currently, the following APIs are supported:

| Area          | Supported     | Comments |
| ------------- | ------------- | -------- |
| [Authorization](https://api.cloudflare.com/#getting-started-requests) | :white_check_mark: | Both tokens and keys are supported |
| [DNS Records](https://api.cloudflare.com/#dns-records-for-a-zone-properties) | :white_check_mark: except [import](https://api.cloudflare.com/#dns-records-for-a-zone-import-dns-records) [export](https://api.cloudflare.com/#dns-records-for-a-zone-export-dns-records) and [error codes](https://api.cloudflare.com/#dns-records-for-a-zone-export-dns-records) |
| [Cloudflare IPs](https://api.cloudflare.com/#cloudflare-ips-properties) | :white_check_mark: |
| [Zone](https://api.cloudflare.com/#zone-properties) | [List](https://api.cloudflare.com/#zone-list-zones) only

If you have a requirement for a specific area feel free to open an issue.

## Disclaimer

I'm not related to Cloudflare in any way. This is no official product. 