using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository //inherits from IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

      

        public async Task<Student>GetStudentAsync(Guid studentId)
        {
            return await context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
           return await context.Gender.ToListAsync(); //because this method is async we always have to return await
        }

        public async Task<bool> Exists(Guid studentId)
        {
          return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            throw new NotImplementedException();
        }
    }
}
