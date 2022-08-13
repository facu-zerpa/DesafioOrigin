using System.ComponentModel.DataAnnotations;

namespace Origin.API.Entities
{
    public class TypeOperation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
