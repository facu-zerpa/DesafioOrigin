using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class VerifyNumberDTO
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        [RegularExpression("^[0-9]*$")]
        public string Number { get; set; }
    }
}
