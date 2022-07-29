using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MahdaviEshop.Framework.Enums;
using Polly;
using RestSharp;
using System.Net.Http;
using Polly.Retry;
using Polly.Timeout;
using RestSharpPolly;
using RestSharpPolly.PolicyProviders;

namespace MahdaviEshop.Framework.ServiceProvider
{
    public class ServiceProvicer : IServiceProvicer
    {
        public async Task<RestResponse> Rest(string url, string action, Dictionary<string, object> parameters,
             Dictionary<string, string> headers, ParameterType parameterType, Method method = Method.GET)
        {
            var restClient = new RestClient(url);
            var maxRetryAttempts = 10;
            var pauseBetweenFailures = TimeSpan.FromSeconds(2);
            IRestResponse result = new RestResponse();
            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);
            await retryPolicy.ExecuteAsync(async () =>
            {


                var request = new RestRequest(method);
                request.RequestFormat = DataFormat.Json;


                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }

                //if (parameters != null)
                //{
                //    foreach (var param in parameters)
                //    {
                //        request.AddParameter(param.Key, param.Value, parameterType);
                //    }
                //}
                request.AddBody(parameters);
                result = await restClient.ExecuteAsync(request);
            });
            return result as RestResponse;

        }

        public async Task<HttpResponseMessage> CallService(string baseAddress, Dictionary<string, string> parameters,
            Dictionary<string, string> headers, CallServiceType callServiceType = CallServiceType.Get,
            string token = null, string tokenAuthorization = "Bearer", HttpContentType httpContentType = HttpContentType.FormUrlEncodedContent)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = null;


                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Add("Authorization", $@"{tokenAuthorization} {token}");

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (parameters != null)
                {
                    switch (httpContentType)
                    {
                        case HttpContentType.ByteArrayContent:
                            {
                                break;
                            }
                        case HttpContentType.FormUrlEncodedContent:
                            {
                                content = new FormUrlEncodedContent(parameters);
                                break;
                            }
                        case HttpContentType.MultipartContent:
                            {
                                break;
                            }
                        case HttpContentType.MultipartFormDataContent:
                            {
                                break;
                            }
                        case HttpContentType.ReadOnlyMemoryContent:
                            {
                                break;
                            }
                        case HttpContentType.StreamContent:
                            {
                                break;
                            }
                        case HttpContentType.StringContent:
                            {
                                content = new StringContent(JsonSerializer.Serialize(parameters), UnicodeEncoding.UTF8, "application/json");
                                break;
                            }
                    }
                }

                HttpResponseMessage response = null;

                switch (callServiceType)
                {
                    case CallServiceType.Get:
                        {
                            if (parameters != null)
                            {
                                baseAddress = string.Format(baseAddress + "?{0}",
                                    string.Join("&",
                                        parameters.Select(kvp =>
                                            string.Format("{0}={1}", kvp.Key, kvp.Value))));
                            }

                            response = await client.GetAsync(baseAddress);
                            break;
                        }
                    case CallServiceType.Post:
                        {
                            response = await client.PostAsync(baseAddress, content);

                            break;
                        }
                    case CallServiceType.Put:
                        {
                            response = await client.PutAsync(baseAddress, content);
                            break;
                        }
                    case CallServiceType.Patch:
                        {
                            response = await client.PatchAsync(baseAddress, content);
                            break;
                        }
                    case CallServiceType.Delete:
                        {
                            response = await client.DeleteAsync(baseAddress);
                            break;
                        }
                }

                if (response == null || !response.IsSuccessStatusCode)
                    return null;

                return response;
            }
        }

        public async Task<HttpResponseMessage> PollyRequest(string baseAddress, Dictionary<string, string> parameters,
            Dictionary<string, string> headers, CallServiceType callServiceType = CallServiceType.Get,
            string token = null, string tokenAuthorization = "Bearer", HttpContentType httpContentType = HttpContentType.FormUrlEncodedContent)
        {




            //ok
            var httpClient2 = new HttpClient();
            var maxRetryAttempts2 = 20;
            var pauseBetweenFailures2 = TimeSpan.FromSeconds(2);
            var retryPolicy2 = Policy.Handle<Exception>()
                .WaitAndRetryAsync(maxRetryAttempts2, i => pauseBetweenFailures2);
            HttpResponseMessage response2 = new HttpResponseMessage();
            await retryPolicy2.ExecuteAsync(async () =>
            {
                var Response = httpClient2.GetAsync(baseAddress).Result;
                Response.EnsureSuccessStatusCode();

            });

            var fd = response2.Content;
          //  return response2;





            //2
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent content = null;


            if (!string.IsNullOrWhiteSpace(token))
                httpClient.DefaultRequestHeaders.Add("Authorization", $@"{tokenAuthorization} {token}");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            if (parameters != null)
            {
                switch (httpContentType)
                {
                    case HttpContentType.ByteArrayContent:
                        {
                            break;
                        }
                    case HttpContentType.FormUrlEncodedContent:
                        {
                            content = new FormUrlEncodedContent(parameters);
                            break;
                        }
                    case HttpContentType.MultipartContent:
                        {
                            break;
                        }
                    case HttpContentType.MultipartFormDataContent:
                        {
                            break;
                        }
                    case HttpContentType.ReadOnlyMemoryContent:
                        {
                            break;
                        }
                    case HttpContentType.StreamContent:
                        {
                            break;
                        }
                    case HttpContentType.StringContent:
                        {
                            content = new StringContent(JsonSerializer.Serialize(parameters), UnicodeEncoding.UTF8, "application/json");
                            break;
                        }
                }
            }

            HttpResponseMessage response = null;


            var maxRetryAttempts = 20;
            var pauseBetweenFailures = TimeSpan.FromSeconds(2);
            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);

            await retryPolicy.ExecuteAsync(async () =>
            {
                // var Response = httpClient.GetAsync(baseAddress).Result;



                switch (callServiceType)
                {
                    case CallServiceType.Get:
                        {
                            if (parameters != null)
                            {
                                baseAddress = string.Format(baseAddress + "?{0}",
                                    string.Join("&",
                                        parameters.Select(kvp =>
                                            string.Format("{0}={1}", kvp.Key, kvp.Value))));
                            }

                            response =  httpClient.GetAsync(baseAddress).Result;
                            break;
                        }
                    case CallServiceType.Post:
                        {
                            response = await httpClient.PostAsync(baseAddress, content);

                            break;
                        }
                    case CallServiceType.Put:
                        {
                            response = await httpClient.PutAsync(baseAddress, content);
                            break;
                        }
                    case CallServiceType.Patch:
                        {
                            response = await httpClient.PatchAsync(baseAddress, content);
                            break;
                        }
                    case CallServiceType.Delete:
                        {
                            response = await httpClient.DeleteAsync(baseAddress);
                            break;
                        }
                }
                response.EnsureSuccessStatusCode();

            });

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            return response;



        }
    }
}

