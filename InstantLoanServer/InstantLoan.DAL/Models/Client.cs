using System.ComponentModel.DataAnnotations;


// MODEL OR ENTITY
namespace InstantLoan.DAL.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string Identification { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string ProfileImage { get; set; }

    }
}
