using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbir.Middleware
{
    public class AuthorizationMiddleware
    {
        /// <summary>
        /// Часть 2.2 п.4 Создание middleware авторизации
        /// </summary>
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var authHeader = httpContext.Request.Headers["Authorization"];

            if(authHeader != "Basic YWRtaW46YWRtaW4=")
            {
                await httpContext.Response.WriteAsync("Authorization error!");
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}
