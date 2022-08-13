using Microsoft.EntityFrameworkCore;
using Origin.API.Entities;
using Origin.API.Repository.IRepository;
using Origin.API.Utils;

namespace Origin.API.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public CardRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<Card> GetCard(string id)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);
            var idDesencript = Convert.ToInt32(crypto.Desencript(id));
            var card = await context.Cards.FirstOrDefaultAsync(x => x.Id == idDesencript && !x.Lock);
            return card;
        }

        public async Task<bool> LockCard(string id)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);
            var idDesencript = Convert.ToInt32(crypto.Desencript(id));
            var card = await context.Cards.FirstOrDefaultAsync(x => x.Id == idDesencript);
            if (card is null)
            {
                return false;
            }
            card.Pin = crypto.Encript("4321");
            card.Lock = true;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DiscountBalance(string id, double amount)
        {
            try
            {
                var card = GetCard(id).Result;
                card.Balance = card.Balance - amount;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<Card> VerifyNumberCard(string number)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);
            var cardEncript = crypto.Encript(number);
            var card = await context.Cards.FirstOrDefaultAsync(x => x.Number.Contains(cardEncript) && !x.Lock);
            return card;
        }

        public async Task<bool> VerifyPinCard(string id, string pin)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);

            var idDesencript = Convert.ToInt32(crypto.Desencript(id));
            var pinEncript = crypto.Encript(pin);

            var card = await context.Cards.FirstOrDefaultAsync(x => x.Id == idDesencript && x.Pin.Contains(pinEncript));

            return card is not null;
        }


    }
}
