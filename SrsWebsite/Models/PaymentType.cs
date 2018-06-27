using System.ComponentModel.DataAnnotations;
namespace SrsWebsite.Models
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}