namespace Application.Interfaces
{
    public interface IOrdersService
    {
        Task<Guid> CreateAsync(Guid userId, decimal price, DateTime dateCreation);
    }
}