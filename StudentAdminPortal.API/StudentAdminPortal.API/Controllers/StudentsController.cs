using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));

        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]

        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)

        {
            //fetch student details
            var student = await studentRepository.GetStudentAsync(studentId);

            //return student details

            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")] 
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] DomainModels.UpdateStudentRequest request) //Update student is a specific model
        {
            if (await studentRepository.Exists(studentId))
            {

                //update details

                var updatedStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request)); //maps the request to the data models.student

                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<DomainModels.Student>(updatedStudent));
                }

            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[Controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await studentRepository.Exists(studentId))
            { 
            var student = await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<DomainModels.Student>(student));
            }

            return NotFound();
        }
       
    }
}
