using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingApi.Data;
using LoggingApi.Request_Responce;
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

        public async Task<loggingResponse> CreateLogging(Logging loggingObject)
        {
            try
            {
                _context.logging!.Add(loggingObject);
                await _context.SaveChangesAsync();

                return new loggingResponse(200, "Success", loggingObject.SpanId);;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new loggingResponse(400, ex.Message);
            }
        }
    }
}