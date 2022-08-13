using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class VerifyNumberDTO
    {
        [Required(ErrorMessage = "Id es requerido.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Tarjeta valida consta de 16 digitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros se permite")]
        public string Number { get; set; }
    }
}
