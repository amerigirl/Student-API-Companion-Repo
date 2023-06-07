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

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

      
    }
}
