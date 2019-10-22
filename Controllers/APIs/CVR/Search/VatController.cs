using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;

namespace Freelance_Api.Controllers.APIs
{
    [Route("api/cvr/search/vat")]
    [ApiController]
    public class VatController : ControllerBase
    {
        [HttpPost("{vatFromEndPoint}")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync(string vatFromEndPoint)
        {
            int responseStatusCode;
            var responseFromHttpRequest = await CVRVatHTTPRequestAsync(vatFromEndPoint);
            var responseContentFromHttpRequest = await responseFromHttpRequest.Content.ReadAsStringAsync();
            
            Console.WriteLine(responseFromHttpRequest);
            Console.WriteLine(responseContentFromHttpRequest);

            responseStatusCode = (int) responseFromHttpRequest.StatusCode;
            
            if (responseStatusCode == 401)
            {
                return BadRequest(ModelState);
            }

            return Ok(responseContentFromHttpRequest);
        }
        
        protected async Task<HttpResponseMessage> CVRVatHTTPRequestAsync(string vatFromQuery)
        {
            string baseApiURL = "https://cvrapi.dk/api";

            HttpClient client = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("vat", vatFromQuery),
                new KeyValuePair<string, string>("country", "DK"),
            });

            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
                "[DTU@Gruppe0] [Freelance-portal] - [Ali M] [aamoussa97@gmail.com]");
            
            var parameters = new Dictionary<string, string>();
            parameters.Add("vat", vatFromQuery);
            parameters.Add("country", "DK");
            var encodedContent = new FormUrlEncodedContent (parameters);
            
            var response = await client.PostAsync(baseApiURL, content);
            
            return response;
        }
    }
}