namespace Application.Shared.Logger.ProviderContracts
{
  public interface ILoggerProviderContract
  {
    void LogError( string message );
    void LogMessage( string message );
    void LogInfo( string message );
  }
}
