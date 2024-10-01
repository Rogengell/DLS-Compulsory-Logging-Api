using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingApi.Request_Responce
{
    public class loggingResponse
    {        
        public int _Status { get; set; }
        public int? _ParentSpanId { get; set; }
        public string _responceMessage { get; set; }

        
        public loggingResponse(int Status,string responceMessage ,int ParentSpanId)
        {
            _Status = Status;
            _ParentSpanId = ParentSpanId;
            _responceMessage = responceMessage;
        }
        public loggingResponse(int Status,string responceMessage)
        {
            _Status = Status;
            _responceMessage = responceMessage;
        }
    }
}