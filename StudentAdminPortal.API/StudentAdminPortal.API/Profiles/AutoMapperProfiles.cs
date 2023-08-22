using StudentAdminPortal.API.DomainModels;
using DataModels = StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles: AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>()
                .ReverseMap();

            CreateMap<DataModels.Gender, Gender>()
                .ReverseMap();

            CreateMap<DataModels.Address, Address>()
                .ReverseMap();

            CreateMap<UpdateStudentRequest, DataModels.Student>()
                .ForMember(dest => dest.Address.PhysicalAddress, opt => opt.MapFrom(src => src.PhysicalAddress))
                .ForMember(dest => dest.Address.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress));

        }

        
    }
}
 