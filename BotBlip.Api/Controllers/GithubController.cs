using BotBlip.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotBlip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        Github github;
        
        public GithubController()
        {
            github = new Github();

        }


        [HttpGet]
        public IActionResult GetRepositories()
        {
            var response = github.GetRepositories();
            return Ok(response);
        }
    }
}
