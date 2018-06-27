using System.ComponentModel.DataAnnotations;

namespace SrsWebsite.Models
{
    public class ShootingType
    {
        public int ShootingTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}