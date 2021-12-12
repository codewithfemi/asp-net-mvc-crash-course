using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public readonly ILogger _logger;
        public readonly IEmailSender _emailSender;

        public CustomExceptionFilter(ILoggerFactory loggerFactory, IEmailSender emailSender)
        {
            _logger = loggerFactory.CreateLogger<CustomExceptionFilter>();
            _emailSender = emailSender;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Error handled in filter");
            _emailSender.SendEmailAsync("admin@mvcapp.com", "Exception from filter", context.Exception.ToString()).GetAwaiter().GetResult();

            var viewResult = new ViewResult();
            viewResult.ViewName = "CustomError";

            context.Result = viewResult;
        }
    }
}
