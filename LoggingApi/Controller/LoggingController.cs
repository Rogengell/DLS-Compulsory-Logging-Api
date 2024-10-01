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
            return StatusCode(400,"Bad Request");
        }
        try
        {
            var logging = new Logging
            {
                TraceId = (int)req.TraceId!,
                ParentSpanId = req.ParentSpanId,
                LoggingString = req.LoggingString,
                Time = req.Time ?? DateTime.Now
            };

            var status = await _service.CreateLogging(logging);

            if (status._Status == 400)
                return StatusCode(400,status._responceMessage);

            Console.WriteLine("Create Logging");
            return StatusCode(200,status);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Something went wrong createing the logging" + ex.Message);
            return StatusCode(400,ex.Message);
        }
    }
}
