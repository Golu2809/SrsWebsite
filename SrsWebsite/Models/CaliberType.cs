using System.ComponentModel.DataAnnotations;

namespace SrsWebsite.Models
{
    public class CaliberType
    {
        public int CaliberTypeId { get; set; }
        [Required]
        public string CaliberName { get; set; }
    }
}