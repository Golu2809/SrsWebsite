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

        public int UserId { get; set; }
        public int CaliberTypeId { get; set; }
        public int PaymentTypeId { get; set; }
        public int ShootingTypeId { get; set; }

        public User User { get; set; }
        public CaliberType CaliberType { get; set; }
        public PaymentType PaymentType { get; set; }
        public ShootingType ShootingType { get; set; }


        public Shooting()
        {
            NumberOfShoots = 0;
            IsFinished = false;
            CreationDateTime = DateTime.Now;
        }

        //[Required]
        //public CaliberType Caliber { get; set; }
        //[Required]
        //public PaymentType PaymentType { get; set; }
        //[Required]
        //public ShootingType ShootingType { get; set; }
    }
}