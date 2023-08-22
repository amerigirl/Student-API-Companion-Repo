using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {

        public Task<List<Student>> GetStudentsAsync();

        public Task<Student> GetStudentAsync(Guid studentId);

        public Task<List<Gender>> GetGendersAsync();

        public Task<bool>Exists(Guid studentId);

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        { 
        var existingStudent = await GetStudentAsync(studentId);
            if (existingStudent != null)
            { 
            existingStudent.FirstName = request.FirstName;
            existingStudent.LastName = request.LastName;
            existingStudent.DateOfBirth = request.DateOfBirth;
            existingStudent.Email = request.Email;
            existingStudent.Mobile = request.Mobile;
            existingStudent.GenderId = request.GenderId;
            existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
            existingStudent.Address.PostalAddress = request.Address.PostalAddress;

              
            }
            
             await SaveChangesAsync();
             return existingStudent;
        }

    }
}
