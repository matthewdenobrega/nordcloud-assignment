using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NordCloudAssignment.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NordCloudAssignment
{
    public class Input
    {
        public List<double> Position { get; set; }
        public List<List<double>> GridConfig { get; set; }
    }

    public static class PowerGridFunction
    {
        [FunctionName("PowerGridFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger logger)
        {
            logger.LogInformation("PowerGridFunction processing request");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                var input = data.ToObject<Input>();

                var message = new PowerGrid(input.GridConfig)
                    .BestLinkStationForPositionMessage(new Position(input.Position[0], input.Position[1]));

                var result = new JObject
                {
                    { "message", message }
                };

                return new OkObjectResult(result);
            }
            catch (Exception exception)
            {
                var error = new JObject
                {
                    { "message", "An error occurred: " + exception.Message }
                };

                return new BadRequestObjectResult(error);
            }
        }
    }
}
