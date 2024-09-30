using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using LoggingApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        Console.WriteLine(ModelState.IsValid);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var logging = new Logging
            {
                TraceId = (int)req.TraceId!,
                SpanId = (int)req.SpanId!,
                ParentSpanId = req.ParentSpanId,
                LoggingString = req.LoggingString,
                Time = (DateTime)req.Time!,
            };

            var status = await _service.CreateLogging(logging);

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
