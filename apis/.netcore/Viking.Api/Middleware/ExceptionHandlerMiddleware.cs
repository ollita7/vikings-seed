using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Viking.Sdk;

namespace Viking.Api.Middleware
{
    public static class ExceptionHandlerMiddleware
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.WriteAsync(JsonConvert.SerializeObject(new RetornoDataOut { Result = Retorno.Error, Msg = message }));
        }
    }
}