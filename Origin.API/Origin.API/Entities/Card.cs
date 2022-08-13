using System.ComponentModel.DataAnnotations;

namespace Origin.API.Entities
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Pin { get; set; }
        public bool Lock { get; set; } = false;
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public double Balance { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
