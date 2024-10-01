using LoggingApi.Request_Responce;
using Model;

public interface ILoggingService
{
    Task<loggingResponse> CreateLogging(Logging loggingObject);
}