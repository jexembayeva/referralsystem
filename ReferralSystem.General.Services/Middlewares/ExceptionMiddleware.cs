using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ReferralSystem.General.Services.Middlewares
{
    public sealed class ExceptionMiddleware
    {
        private static readonly HashSet<Type> _suppressExceptions = new ()
        {
            typeof(OperationCanceledException),
            typeof(TaskCanceledException),
        };

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return InvokeNextAsync(context);
        }

        private async Task InvokeNextAsync(HttpContext context)
        {
            try
            {
                await _next?.Invoke(context);
            }
            catch (Exception exception)
            {
                if (_suppressExceptions.Contains(exception.GetType()))
                {
                    return;
                }

                throw;
            }
        }
    }
}
