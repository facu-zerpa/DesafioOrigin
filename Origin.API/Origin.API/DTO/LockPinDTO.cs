using System.ComponentModel.DataAnnotations;

namespace Origin.API.DTO
{
    public class LockPinDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public string Id { get; set; }
    }
}
