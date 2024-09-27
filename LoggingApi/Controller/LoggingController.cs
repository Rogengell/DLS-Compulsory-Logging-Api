using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

[ApiController]
[Route("[controller]")]
public class LoggingController : Controller
{
    [HttpPut("Logging")]
    public async Task<int> CreateLogging()
    { 
        try
        {
            //TODO: create logging
            await Task.Delay(1000);
            Console.WriteLine("Create Logging");
            return StatusCodes.Status200OK;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Something went wrong createing the logging" + ex.Message);
            return StatusCodes.Status400BadRequest;
            throw;
        }
    }
}
