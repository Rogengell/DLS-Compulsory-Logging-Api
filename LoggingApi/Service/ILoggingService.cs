public interface ILoggingService
{
    Task<Boolean> CreateLogging(loggingRequest loggingRequest);
}