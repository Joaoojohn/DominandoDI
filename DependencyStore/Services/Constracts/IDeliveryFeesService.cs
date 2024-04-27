namespace DependencyStore.Services.Constracts
{
    public interface IDeliveryFeesService
    {
        Task<decimal> GetDeliveryFeeAsync(string zipCode);
    }
}
