public class loggingRequest
{
    public int TraceId { get; set; }
    public int SpanId { get; set; }
    public int? ParentSpanId { get; set; }
    public string? LoggingString { get; set; }
    public DateTime Time { get; set; }
}