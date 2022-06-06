using Enrollment.DatabaseModels;
using Entprog.Repository;

namespace Enrollment.App.Repositories
{
    public class StudentRepository
        : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
