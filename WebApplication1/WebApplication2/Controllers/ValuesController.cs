﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("LogRequest & ErroHandaling")]
        public IActionResult GetHello()
        {
            return Ok("Hello from MyController!");
        }
    }
}
