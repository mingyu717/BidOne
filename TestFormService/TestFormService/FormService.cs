
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using TestFormService.Contract;
using Unity;

namespace TestFormService
{
    public static class FormService
    {
        [FunctionName("SaveFile")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var profile = JsonConvert.DeserializeObject<Profile>(requestBody);

            var container = UnityContainer.Instance;

            var profileService = container.Resolve<IProfileService>();
            profileService.Save(profile);

            return profile == null
                ? new BadRequestObjectResult("Profile should not be null")
                : (ActionResult)new OkObjectResult(profile);
        }
    }
}
