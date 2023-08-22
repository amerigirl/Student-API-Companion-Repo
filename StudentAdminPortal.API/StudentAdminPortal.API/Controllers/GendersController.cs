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
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await this.iStudentRepository.GetGendersAsync();

              return Ok(mapper.Map<List<DomainModels.Gender>>(genderList));
        }
  
    } 
}
