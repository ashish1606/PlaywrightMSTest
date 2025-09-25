using Playwright_CSharp.Config;
using Playwright_CSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Tests
{
    [TestClass]
    public class APITest : APIBase
    {

        private APIHelper apiHelper;

        

        [TestMethod]

        public async Task TestGetRequest()
        {
            apiHelper = new APIHelper(ApiContext);
            var response = await apiHelper.GetAsync("https://petstore.swagger.io/v2/store/inventory");
            Console.WriteLine("Resposne Body is : " + response.Content);
            Console.WriteLine("Response Status code is : " + response.StatusCode);
            Console.WriteLine("Response success is : " + response.IsSuccess);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,"Get Request Failed");
        }


        [TestMethod]
        public async Task TestPostRequest()
        {
            apiHelper = new APIHelper(ApiContext);

            var payload = new
            {
                id=5,
                petId= 2,
                quantity= 1,
                shipDate= "2025-01-23T13:28:31.177Z",
                status= "placed",
                complete= true

            };

            var response = await apiHelper.PostAsync("https://petstore.swagger.io/v2/store/order", payload);
            Console.WriteLine("Resposne Body is : " + response.Content);
            Console.WriteLine("Response Status code is : " + response.StatusCode);
            Console.WriteLine("Response success is : " + response.IsSuccess);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Post Request Failed");
        }

        [TestMethod]
        public async Task TestDeleteRequest()
        {
            apiHelper = new APIHelper(ApiContext);
            var response = await apiHelper.DeleteAsync("https://petstore.swagger.io/v2/store/order/5");
            Console.WriteLine("Resposne Body is : " + response.Content);
            Console.WriteLine("Response Status code is : " + response.StatusCode);
            Console.WriteLine("Response success is : " + response.IsSuccess);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Delete Request Failed");
        }



    }
}
