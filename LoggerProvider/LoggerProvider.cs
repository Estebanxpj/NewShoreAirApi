using Application.Shared.Logger.ProviderContracts;

namespace Adapters.Providers.Logger.Provider
{
  public class LoggerProvider : ILoggerProviderContract
  {
    public void LogError( string message )
    {
      Console.WriteLine(message );
    }

    public void LogInfo( string message )
    {
      Console.WriteLine( message );
    }

    public void LogMessage( string message )
    {
      Console.WriteLine( message );
    }
  }
}
