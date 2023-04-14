using NetflixMVC.ViewModel;
using Newtonsoft.Json;
using System.Net;

namespace NetflixMVC.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;


        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext,ex.Message,HttpStatusCode.NotFound,"Can't find object");
                httpContext.Response.Redirect("/Home/Error");
                throw;
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e.Message, HttpStatusCode.NotFound, "Can't find object");
                httpContext.Response.Redirect("/Home/Error");
                
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exsMsg, HttpStatusCode httpStatusCode, string message)
        {
            _logger.LogError(exsMsg);
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorVM errorVM = new ErrorVM()
            {
                Message = message,
                Code = (int)httpStatusCode
            };

            string res = JsonConvert.SerializeObject(errorVM);
            _logger.LogError(res);
        }

    }
}
