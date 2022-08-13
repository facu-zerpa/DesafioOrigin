using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class BalanceDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public string Id { get; set; }
    }
}
