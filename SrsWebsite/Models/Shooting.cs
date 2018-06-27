using System;
using System.ComponentModel.DataAnnotations;

namespace SrsWebsite.Models
{
    public class Shooting
    {
        public int ShootingId { get; set; }
        public int NumberOfShoots { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        public bool IsFinished { get; set; }
        [Required]
        public CaliberType Caliber { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public ShootingType ShootingType { get; set; }
    }
}