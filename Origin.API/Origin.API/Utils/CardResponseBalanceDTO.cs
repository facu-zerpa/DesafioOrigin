using AutoMapper;
using Origin.API.DTO;
using Origin.API.Entities;

namespace Origin.API.Utils
{
    public class CardResponseBalanceDTO : IMappingAction<Card, ResponseBalanceDTO>
    {
        private readonly IConfiguration configuration;

        public CardResponseBalanceDTO(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Process(Card source, ResponseBalanceDTO destination, ResolutionContext context)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);
            destination.Number = crypto.Desencript(source.Number);
        }
    }
}
