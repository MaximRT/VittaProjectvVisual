namespace Application.Interfaces
{
    public interface IOrdersService
    {
        Task<Guid> CreateOrderAsync(Guid userId, decimal price, DateTime dateCreation);
    }
}