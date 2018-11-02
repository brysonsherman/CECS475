using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IStandardRepository : IRepository<Standard>
    {
    }
    public interface IStudentRepository : IRepository<Student>
    {
    }
    public interface ITeacherRepository : IRepository<Teacher>
    {
    }

    public interface ICourseRepository : IRepository<Course>
    {
    }
    public class StandardRepository : Repository<Standard>, IStandardRepository
    {
        public StandardRepository() : base(new SchoolDBEntities())
        {
        }
    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository()
        : base(new SchoolDBEntities())
        {
        }
    }
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository()
        : base(new SchoolDBEntities())
        {
        }
    }
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository()
        : base(new SchoolDBEntities())
        {
        }
    }
}