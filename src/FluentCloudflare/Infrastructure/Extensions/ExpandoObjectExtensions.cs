using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace FluentCloudflare.Infrastructure.Extensions
{
    internal static class ExpandoObjectExtensions
    {
        public static void SetValues(this ExpandoObject target, IDictionary<string, object> values)
        {
            var trgDic = target as IDictionary<string, object>;
            foreach ((var key, var value) in values)
            {
                trgDic[key] = value;
            }
        }

        public static string ToJson(this ExpandoObject value)
        {
            dynamic dyn = value;
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            return JsonConvert.SerializeObject(dyn);
        }

        public static string ToQueryString(this ExpandoObject value)
        {
            static IEnumerable<string> GetAssignments(IDictionary<string, object> dic)
            {
                foreach ((var key, var val) in dic)
                    yield return $"{key}={HttpUtility.UrlEncode(val?.ToString() ?? "")}";
            }

            return string.Join("&", GetAssignments(value));
        }
    }
}
