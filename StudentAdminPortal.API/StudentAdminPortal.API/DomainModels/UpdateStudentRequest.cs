using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortal.API.DomainModels
{
    public class UpdateStudentRequest

    {   [Required]
        public string? FirstName { get; set; }
        
        [Required]
        public string? LastName { get; set; }
        
        public DateTime? DateOfBirth { get; set; }

        [Required][EmailAddress]
        public string? Email { get; set; }

        [Required]
        public long Mobile { get; set; }
        
        //public Guid GenderId { get; set; }
        
        public string? PhysicalAddress { get; set; }

        [Required]
        public string? PostalAddress { get; set; }

    }
}
