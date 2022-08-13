using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class BalanceDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
