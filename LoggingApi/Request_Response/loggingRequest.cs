using System.ComponentModel.DataAnnotations;

public class loggingRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public int? TraceId { get; set; }
    
    [Range(0, int.MaxValue)]
    public int? ParentSpanId { get; set; }
    
    [StringLength(int.MaxValue, MinimumLength = 0)]
    public string? LoggingString { get; set; }

    public DateTime? Time { get; set; }
}