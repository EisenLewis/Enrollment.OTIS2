using Enrollment.DatabaseModels;
using Entprog.Repository;

namespace Enrollment.App.Repositories
{
    public interface IStudentRepository
        : IGenericRepository<Student>
    {
        //Add more contracts for more specialized purposes
        //Example
        //Task Enroll();
    }
}
