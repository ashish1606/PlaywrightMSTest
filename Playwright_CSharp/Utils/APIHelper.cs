using Microsoft.Playwright;
using Playwright_CSharp.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Utils
{
    public class APIHelper
    {

        private readonly IAPIRequestContext apiContext;

        public APIHelper(IAPIRequestContext apiContext)
        {
            this.apiContext = apiContext;
        }
        
        public async Task<HttpResponse> GetAsync(string url)
        {
            var response=await apiContext.GetAsync(url);
            return await CreateHtppRespnse(response);
        }

      

        public async Task<HttpResponse> PostAsync(string url, object payload)
        {
            var response = await apiContext.PostAsync(url, new APIRequestContextOptions
            {
                DataObject=payload
            });
            return await CreateHtppRespnse(response);
        }

        public async Task<HttpResponse> PutAsync(string url, object payload)
        {
            var response = await apiContext.PutAsync(url, new APIRequestContextOptions
            {
                DataObject = payload
            });
            return await CreateHtppRespnse(response);
        }


        public async Task<HttpResponse> DeleteAsync(string url)
        {
            var response = await apiContext.DeleteAsync(url);
          
            return await CreateHtppRespnse(response);
        }


        private async Task<HttpResponse> CreateHtppRespnse(IAPIResponse response)
        {
            return new HttpResponse
            {
                StatusCode = (HttpStatusCode)response.Status,
                Content=await response.TextAsync(),
                IsSuccess=(Boolean)response.Ok,
            };
        }

    }

    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
        public bool IsSuccess { get; set; }
    }
}
