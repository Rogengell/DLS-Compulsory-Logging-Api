using System.Diagnostics;
using System.Reflection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.Span;

namespace Helper;

public class Monitoring
{
    public static readonly string ServiceName = Assembly.GetCallingAssembly().GetName().Name ?? "Unknown";
    public static TracerProvider _tracerProvider;
    public static ActivitySource activitySource = new ActivitySource(ServiceName);

    static Monitoring()
    {
        _tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddZipkinExporter()
            .AddConsoleExporter()
            .AddSource(activitySource.Name)
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(ServiceName))
            .Build();
        
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.WithSpan()
            .WriteTo.Seq("http://localhost:5341")
            .WriteTo.Console()
            .CreateLogger();
    }
}
