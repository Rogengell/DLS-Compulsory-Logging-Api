using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace LoggingApi.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly LADbContext _context;
        public LoggingService(LADbContext context)
        {
            _context = context;
        }

        public async Task<Boolean> CreateLogging(loggingRequest loggingRequest)
        {
            try
            {
                var req = new Logging
                {
                    TraceId = loggingRequest.TraceId,
                    SpanId = loggingRequest.SpanId,
                    ParentSpanId = loggingRequest.ParentSpanId,
                    LoggingString = loggingRequest.LoggingString,
                    Time = loggingRequest.Time,
                };
                _context.logging.Add(req);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
    }
}