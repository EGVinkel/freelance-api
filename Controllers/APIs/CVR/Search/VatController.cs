using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Freelance_Api.Models.APIs.Login.CampusNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Freelance_Api.Controllers.APIs
{
    [Route("api/cvr/search/vat")]
    [ApiController]
    public class VatController : ControllerBase
    {
        [HttpPost("{id:length(8)}")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync(string vatFromEndPoint)
        {
            int ResponseStatusCode = 200;

            if (ResponseStatusCode == 401)
            {
                return BadRequest(ModelState);
            }

            return Ok(ResponseStatusCode);
        }
    }
}