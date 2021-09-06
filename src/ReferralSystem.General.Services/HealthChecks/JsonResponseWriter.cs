using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ReferralSystem.General.Services.HealthChecks
{
    public static class JsonResponseWriter
    {
        private static readonly JsonSerializerSettings _serializerSettings = new ()
        {
            Converters = { new StringEnumConverter() },
            Error = (sender, args) =>
            {
                args.ErrorContext.Handled = true;
            },
        };

        public static Task WriteResponseAsync(HttpContext context, HealthReport result)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var jsonResponse = JsonConvert.SerializeObject(result, _serializerSettings);

            context.Response.ContentType = MediaTypeNames.Application.Json;
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
