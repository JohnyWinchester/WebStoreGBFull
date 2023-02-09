using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreGB.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<TestMiddleware> _Logger;
        public TestMiddleware(RequestDelegate next,ILogger<TestMiddleware> logger)
        {
            _Next = next;
            _Logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _Next(context);
        }
    }
}
