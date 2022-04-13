namespace Supermarket.Core.Services.ActionServices.Interfaces
{
    public interface IDtoMappingService
    {
        TResult Map<TInput, TResult>(TInput input);
    }
}
