using FluentValidation;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Validators
{
    //inherits from AbstractValidator
    public class AddStudentRequestValidator: AbstractValidator<AddStudentRequest>
    {
        //only added istudentrepo to satisfy gender requirement currently not in use
        public AddStudentRequestValidator(IStudentRepository istudentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(1000000000);
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();

            /*you need to make a rule for gender Id after you add gender back into the models
            RuleFor(x=>x.GenderId).NotEmpty().Must(id=>
            {
            var gender = istudentRepository.GetGenderAsync().Result.ToList()
                .FirstOrDefault(x => x.Id == id);
            if (gender == !null) 
            {
                return true;
            }

            return false;
            }).WithMessage("Please select a valid gender")*/

        }
    }
}
