using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    //what is the flow for communication between controller, repository, and interface?
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper, IImageRepository imageRepository) //added image repo to grab pics
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository; 
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<DataModels.Student>>(students));

        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudentAsync")]

        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)

        {
            //fetch student details
            var student = await studentRepository.GetStudentAsync(studentId);

            //return student details

            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DataModels.Student>(student));
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
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            var student = await studentRepository.DeleteStudent(studentId);

            if (student == null)
            {
                return NotFound();
            }

            await studentRepository.DeleteStudent(studentId);
            return Ok();

        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var student = await studentRepository.AddStudent(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id },
                mapper.Map<DomainModels.Student>(student));
        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]

        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        {
            //check if student exists

            if (await studentRepository.Exists(studentId))
            {
                //create a new guid for the name of the file coming from the frontend
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                //upload image to local storage (IImageRepo)
                var fileImagePath = await imageRepository.Upload(profileImage, fileName);

                //update the profile image path in the database in localStorageImage Repository
                if (await studentRepository.UpdateProfileImage(studentId, fileImagePath))
                { 
                    return Ok(fileImagePath);    //checks if it is working
                };

                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
              
            }

        return NotFound();
        }


    }
}
