using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class VerifyIdPinDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Pin es requerido")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Pin solo 4 digitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros se permite")]
        public string Pin { get; set; }
    }
}
