using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApplication3.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IEmailSender emailSender, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
            try
            {
                // Forward request to the next middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error handled in middleware");
                await emailSender.SendEmailAsync("admin@mvcapp.com", "Exception from middleware", ex.ToString());

#if DEBUG
                throw;
#else

                await context.Response.WriteAsync("Sorry something went wrong, please try again. Handled in middleware");
#endif
            }
        }

    }
}
