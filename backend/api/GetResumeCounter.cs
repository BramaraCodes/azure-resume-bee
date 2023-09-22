using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            // These are Azure func with CosmosDB bindings : Trigger, input and Output Bindings
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", collectionName:"AzResumeContainer", ConnectionStringSetting ="AzureResumeConnectionString", Id="1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"AzureResume", collectionName:"AzResumeContainer", ConnectionStringSetting ="AzureResumeConnectionString", Id="1", PartitionKey = "1")] out Counter updatedCounter,

            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            log.LogInformation("Arrived at counter");

            updatedCounter.Count++;
            log.LogInformation("Updated the counter");

            var jsonToReturn = JsonConvert.SerializeObject(counter);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}