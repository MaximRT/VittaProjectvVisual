namespace Application.Interfaces
{
    public interface IOrdersRepository
    {
        Task<Guid> Add(DateTime dateCreation,  decimal price, Guid userId);
    }
}