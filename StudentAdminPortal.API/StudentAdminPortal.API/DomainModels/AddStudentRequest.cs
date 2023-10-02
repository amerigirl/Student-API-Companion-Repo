using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortal.API.DomainModels
{
    public class AddStudentRequest
    {   [Required]
        public string? FirstName { get; set; }
       

        [Required]
        public string? LastName { get; set; }
       
        [Required]
        public string? DateOfBirth { get; set; }
      

        [EmailAddress][Required]
        public string? Email { get; set; }
   

        [Required]
        public long Mobile { get; set; }

       //public Guid GenderId { get; set; }

        public string? PhysicalAddress { get; set; }

        [Required]
        public string? PostalAddress { get; set; }

    }
}
