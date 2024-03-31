namespace Application.Interfaces
{
    public interface IOrdersRepository
    {
        Task<Guid> CreateOrderAsync(DateTime dateCreation,  decimal price, Guid userId);
    }
}