using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;


namespace CoreAndMongoDB.UI
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:54206/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /* Api Client içerisinde Default header bilgisi göndererek Authorizationu sağlamak.
            //WebApiClient.DefaultRequestHeaders.Add("Authorization","Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiRW5lcyIsImV4cCI6MTUyMDIxOTg4OCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1NDIwNi8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjU0MjA2LyJ9.qKVNmnEePG9e0vliJcpVbLqjZ47mxysC9e3uA_iKiVc");
            */
        }
      

    }
}
