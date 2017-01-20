using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using StudyBuddies.Business.Infrastructure.Exceptions;

namespace StudyBuddies.Web.App_Start
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            var exceptionType = actionExecutedContext.Exception.GetType();

            if (exceptionType == typeof(BusinessLayerException))
            {
                message = actionExecutedContext.Exception.Message;
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = actionExecutedContext.Exception.Message;
                statusCode = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(UnauthorizedException))
            {
                message = actionExecutedContext.Exception.Message;
                statusCode = HttpStatusCode.Unauthorized;
            }
            else
            {
                _logger.Error(actionExecutedContext.Exception);
            }

            actionExecutedContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = statusCode
            };

            base.OnException(actionExecutedContext);
        }
    }
}