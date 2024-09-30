using System.ComponentModel.DataAnnotations;

public class loggingRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public int? TraceId { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int? SpanId { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? ParentSpanId { get; set; }
    
    [StringLength(int.MaxValue, MinimumLength = 0)]
    public string? LoggingString { get; set; }

    [Required]
    public DateTime? Time { get; set; }
}