using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IStandardRepository _standardRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;


        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository();
            _teacherRepository = new TeacherRepository();

        }

        #region Standard
        public IEnumerable<Standard> GetAllStandards()
        {
            return _standardRepository.GetAll();
        }

        public Standard GetStandardByID(int id)
        {
            return _standardRepository.GetById(id);
        }

        public Standard GetStandardByName(string name)
        {
            return _standardRepository.GetSingle(
                s => s.StandardName.Equals(name),
                s => s.Students);
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Insert(standard);
        }

        public void UpdateStandard(Standard standard)
        {
            _standardRepository.Update(standard);
        }

        public void RemoveStandard(Standard standard)
        {
            _standardRepository.Delete(standard);
        }
        #endregion

        #region Student
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentByID(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student GetStudentByName(string name)
        {
            return _studentRepository.GetSingle(
                s => s.StudentName.Equals(name));
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void RemoveStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        #endregion



        #region Teacher
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacherByID(int id)
        {
            return _teacherRepository.GetById(id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return _teacherRepository.GetSingle(
                s => s.TeacherName.Equals(name));
        }

        public void AddTeacher(Teacher Teacher)
        {
            _teacherRepository.Insert(Teacher);
        }

        public void UpdateTeacher(Teacher Teacher)
        {
            _teacherRepository.Update(Teacher);
        }

        public void RemoveTeacher(Teacher Teacher)
        {
            _teacherRepository.Delete(Teacher);
        }

        #endregion

        #region Course
        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseByID(int id)
        {
            return _courseRepository.GetById(id);
        }

        public Course GetCourseByName(string name)
        {
            return _courseRepository.GetSingle(
                s => s.CourseName.Equals(name));
        }

        public void AddCourse(Course Course)
        {
            _courseRepository.Insert(Course);
        }

        public void UpdateCourse(Course Course)
        {
            _courseRepository.Update(Course);
        }

        public void RemoveCourse(Course Course)
        {
            _courseRepository.Delete(Course);
        }

        #endregion
    }
}