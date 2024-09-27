using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Logging
    {
        [Key]
        public int Id { get; set; }
        public int TraceId { get; set; }
        public int SpanId { get; set; }
        public int? ParentSpanId { get; set; }
        public string? LoggingString { get; set; }
        public DateTime Time { get; set; }
    }
}