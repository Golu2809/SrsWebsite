using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SrsWebsite.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DbSet<Shooting> Shootings { get; set; }
        public DbSet<CaliberType> Calibers { get; set; }
    }
}