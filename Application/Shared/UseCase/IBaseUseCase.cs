using Application.Shared.Logger.ProviderContracts;

namespace Application.Shared.UseCase
{
  public interface IBaseUseCase
  {
    public string useCaseContext { get; }
    public ILoggerProviderContract? logger { get; }
  }
}
