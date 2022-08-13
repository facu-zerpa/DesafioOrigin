using Origin.API.Entities;

namespace Origin.API.Repository.IRepository
{
    public interface IOperationRepository
    {
        Task<bool> InsertOperationBalance(Operation operation);
        Task<Operation> InsertOperationWidtdraw(Operation operation);
        Task<Operation> GetOperationCard(int id);
    }
}
