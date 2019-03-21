using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Icatu.EmployeeManagerAPI.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Icatu.EmployeeManagerAPI.Extension
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
