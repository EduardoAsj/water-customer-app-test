using RestSharp;
using TechTalk.SpecFlow;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

// Note: Console.WriteLine() statements are included to verify that the automation is functioning correctly. 
// The test is expected to fail since it is designed to test a non-compliant scenario.

namespace WaterCustomerAppTest.StepDefinitions
{
    [Binding]
    public class CustomerApiTestsSteps
    {
        private readonly RestClient client;
        private RestRequest request;
        private IRestResponse response;

        public CustomerApiTestsSteps()
        {
            client = new RestClient("http://localhost:3001");
        }

        [Given(@"I have an empty name")]
        public void EmptyName()
        {
            request = new RestRequest("/", Method.POST);
            request.AddJsonBody(new { name = "" });
            Console.WriteLine("Request prepared with empty customer name.");
        }

        [Given(@"I have a blank request body")]
        public void BlankRequestBody()
        {
            request = new RestRequest("/", Method.POST);
            request.AddJsonBody(new { });
            Console.WriteLine("Request prepared with a blank request body.");
        }

        [Given(@"I have a name ""(.*)""")]
        public void ClientName(string clientName)
        {
            request = new RestRequest("/", Method.POST);
            request.AddJsonBody(new { name = clientName });
            Console.WriteLine($"Request prepared with customer name: {clientName}");
        }

        [When(@"I send a POST request to the customer API")]
        public void PostRequestCustomerApi()
        {
            response = client.Execute(request);
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");
        }

        [Then(@"I should receive a bad request response")]
        public void ReceiveBadRequestResponse()
        {
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Console.WriteLine("Verified that the response status is BadRequest.");
        }

        [Then(@"the error message should indicate that the name is required")]
        public void ErrorMessageNameRequired()
        {
            Assert.IsTrue(response.Content.Contains("Please provide your name"));
            Console.WriteLine("Verified that the error message indicates the name is required.");
        }

        [Then(@"I should receive a success response")]
        public void ReceiveSuccessResponse()
        {
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine("Verified that the response status is OK.");
        }

        [Then(@"the response should contain correctly calculated customer sizes")]
        public void CalculatedCustomerSizes()
        {
            var responseBody = JObject.Parse(response.Content);
            var customers = responseBody["customers"];
            foreach (var customer in customers)
            {
                int employees = customer["employees"].Value<int>();
                string expectedSize = GetExpectedSize(employees);
                Assert.AreEqual(expectedSize, customer["size"].Value<string>());
            }
            Console.WriteLine("Verified that the response contains correctly calculated customer sizes.");
        }

        private string GetExpectedSize(int employees)
        {
            if (employees <= 2500) return "Small";
            if (employees > 2500 && employees <= 5000) return "Medium";
            return "Big";
        }
    }
}
