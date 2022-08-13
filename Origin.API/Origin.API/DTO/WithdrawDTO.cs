using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class WithDrawDTO
    {
        [Required]
        public string Id { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double Ammount { get; set; }
    }
}
