using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class VerifyIdPinDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression("^[0-9]*$")]
        public string Pin { get; set; }
    }
}
