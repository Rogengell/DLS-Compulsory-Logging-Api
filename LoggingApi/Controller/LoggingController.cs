using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using LoggingApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

[ApiController]
[Route("[controller]")]
public class LoggingController : Controller
{
    private readonly ILoggingService _service;

    public LoggingController(ILoggingService service)
    {
        _service = service;
    }
    
    [HttpPut("Logging")]
    public async Task<IActionResult> CreateLogging([FromBody] loggingRequest req)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var status = await _service.CreateLogging(req);

            if (!status)
                return BadRequest("failed to write");

            Console.WriteLine("Create Logging");
            return Ok("Logging Created");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Something went wrong createing the logging" + ex.Message);
            return BadRequest(new { message = ex.Message });
        }
    }
}
