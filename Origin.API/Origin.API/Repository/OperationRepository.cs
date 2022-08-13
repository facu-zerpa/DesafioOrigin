using Microsoft.EntityFrameworkCore;
using Origin.API.Entities;
using Origin.API.Repository.IRepository;
using Origin.API.Utils;

namespace Origin.API.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public OperationRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<Operation> GetOperationCard(int id)
        {
            return await context.Operations.Include(x => x.Card).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> InsertOperationBalance(Operation operation)
        {
            try
            {
                context.Add(operation);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Operation> InsertOperationWidtdraw(Operation operation)
        {
            Operation op = null;
            try
            {
                context.Add(operation);
                await context.SaveChangesAsync();
                return GetOperationCard(operation.Id).Result;
            }
            catch (Exception ex)
            {
                return op;
            }
        }
    }
}
