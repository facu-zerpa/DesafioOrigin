using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Origin.API.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Code { get; set; }
        public double? Amount { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        [ForeignKey("TypeOperation")]
        public int TypeOperationId { get; set; }
        public TypeOperation TypeOperation { get; set; }

    }
}
