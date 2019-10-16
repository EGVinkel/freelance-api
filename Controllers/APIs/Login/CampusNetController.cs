using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Freelance_Api.Models.APIs.Login.CampusNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freelance_Api.Controllers.APIs.Login
{
    [Route("api/login/[controller]")]
    [ApiController]
    public class CampusNetController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CNUserAuth cNUserAuthBody)
        {
            int ResponseStatusCode;

            ResponseStatusCode = await UserCampusNetAuthHTTPRequestAsync(cNUserAuthBody);
            Console.WriteLine(ResponseStatusCode);
            

            if (ResponseStatusCode == 401)
            {
                return BadRequest(ModelState);
            }

            return Ok(ResponseStatusCode);
        }

        protected async Task<int> UserCampusNetAuthHTTPRequestAsync(CNUserAuth cnUserAuth)
        {
            string url = @"https://auth.dtu.dk/dtu/mobilapp.jsp";

            HttpClient client = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", cnUserAuth.AuthUsername),
                new KeyValuePair<string, string>("password", cnUserAuth.AuthPassword),
            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            content.Headers.Add("X-appname", "DTU Inside Companion");
            content.Headers.Add("X-token", "ae034f83-4bf4-48a9-86c5-a47f03ad6054");

            var response = await client.PostAsync(url, content);

            var respContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(respContent);

            var ResponseStatusCode = (int) response.StatusCode;

            return ResponseStatusCode;
        }
    }
}