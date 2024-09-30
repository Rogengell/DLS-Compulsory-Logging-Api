using Model;

public interface ILoggingService
{
    Task<Boolean> CreateLogging(Logging loggingObject);
}