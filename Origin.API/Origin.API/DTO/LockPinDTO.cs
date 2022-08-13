using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class LockPinDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
