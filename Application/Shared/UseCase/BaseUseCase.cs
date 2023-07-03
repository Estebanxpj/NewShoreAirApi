using Application.Shared.Logger.ProviderContracts;

namespace Application.Shared.UseCase
{
  public abstract class BaseUseCase : IBaseUseCase
  {
    public string useCaseContext { get; } = string.Empty;
    public ILoggerProviderContract? logger { get; }

    public BaseUseCase( string useCaseContext, ILoggerProviderContract loggerProvider )
    {
      this.useCaseContext = useCaseContext;
      this.logger = loggerProvider;
    }


  }
}
