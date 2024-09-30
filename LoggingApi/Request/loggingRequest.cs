using System.ComponentModel.DataAnnotations;

public class loggingRequest
{
    [Required]
    public int TraceId { get; set; }
    [Required]
    public int SpanId { get; set; }
    public int? ParentSpanId { get; set; }
    public string? LoggingString { get; set; }
    [Required]
    public DateTime Time { get; set; }
}