using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;


namespace USend.Api.Configuration.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var response = context.HttpContext.Response;

            response.StatusCode = StatusCodes.Status500InternalServerError;
            response.ContentType = "application/json";
            context.Result = new JsonResult(exception.Message);
        }
    }
}
