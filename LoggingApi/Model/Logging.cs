using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Logging
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpanId { get; set; }
        public int TraceId { get; set; }
        public int? ParentSpanId { get; set; }
        public string? LoggingString { get; set; }
        public DateTime Time { get; set; }


        [ForeignKey("ParentSpanId")]
        public virtual Logging? Parent { get; set; }
    }
}