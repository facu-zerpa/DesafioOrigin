using AutoMapper;
using Origin.API.DTO;
using Origin.API.Entities;

namespace Origin.API.Utils
{
    public class OperationResponseWithdrawDTO : IMappingAction<Operation, ResponseWithdrawDTO>
    {
        private readonly IConfiguration configuration;

        public OperationResponseWithdrawDTO(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Process(Operation source, ResponseWithdrawDTO destination, ResolutionContext context)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);
            destination.Number = crypto.Desencript(source.Card.Number);
            destination.DateOperation = source.Date;
            destination.Amount = source.Amount;
            destination.Balance = source.Card.Balance;
        }
    }
}
