using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class WithDrawDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public string Id { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "No se permiten numeros negativos.")]
        public double Ammount { get; set; }
    }
}
