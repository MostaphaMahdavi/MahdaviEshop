using System;
using MahdaviEshop.Framework.Enums;
using RestSharp;
namespace MahdaviEshop.Framework.ServiceProvider
{
    public interface IServiceProvicer
    {

        Task<RestResponse> Rest(string url, string action, Dictionary<string, object> parameters,
             Dictionary<string, string> headers, ParameterType parameterType, Method method = Method.GET);

        Task<HttpResponseMessage> CallService(string baseAddress, Dictionary<string, string> parameters,
            Dictionary<string, string> headers, CallServiceType callServiceType = CallServiceType.Get,
            string token = null, string tokenAuthorization = "Bearer", HttpContentType httpContentType = HttpContentType.FormUrlEncodedContent);


        Task<HttpResponseMessage> PollyRequest(string baseAddress, Dictionary<string, string> parameters,
            Dictionary<string, string> headers, CallServiceType callServiceType = CallServiceType.Get,
            string token = null, string tokenAuthorization = "Bearer", HttpContentType httpContentType = HttpContentType.FormUrlEncodedContent);
    }
}

