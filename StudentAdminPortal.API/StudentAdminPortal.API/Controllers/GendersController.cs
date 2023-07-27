using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.DataModels
{    
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository iStudentRepository;
        private readonly IMapper mapper;

        public GendersController(IStudentRepository iStudentRepository, IMapper mapper)
        {
            this.iStudentRepository = iStudentRepository;
            this.mapper = mapper;
        }

    [HttpGet]
    [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders(IStudentRepository studentRepository)
        {
            //had to create the variable in line 21 in order to pass the method in line 25

            var genderList = await studentRepository.GetGenderAsync();


            if (genderList == null || genderList.Any()) 
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<DomainModels.Gender>>(genderList));
        }
    }
}
