using Origin.API.Entities;

namespace Origin.API.Repository.IRepository
{
    public interface ICardRepository
    {
        Task<Card> VerifyNumberCard(string number);
        Task<bool> VerifyPinCard(string id, string pin);
        Task<bool> LockCard(string id);
        Task<Card> GetCard(string id);
        Task<bool> DiscountBalance(string id, double amount);
    }
}
