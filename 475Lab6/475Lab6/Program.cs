using DataAccessLayer;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475Lab6
{
    public class Program
    {
        static void Add(BusinessLayer.BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Name:");
            string Name = Console.ReadLine();
            switch (layerType)
            { 
                case LayerType.TEACHER:
                    Teacher newTeacher = new Teacher() { TeacherName = Name };
                    myBusinessLayer.AddTeacher(newTeacher);
                    Console.WriteLine("Teacher: " + Name + " created.");
                    break;
                case LayerType.COURSE:
                    Console.WriteLine("Teacher Id:");
                    int Id = Int32.Parse(Console.ReadLine());
                    Course newCourse = new Course() { CourseName = Name, TeacherId = Id };
                    myBusinessLayer.AddCourse(newCourse);
                    Console.WriteLine("Course: " + Name + " created.");
                    break;
                default:
                    break;
            }
        }

        static void Update(BusinessLayer.BusinessLayer myBusinessLayer, LayerType layerType)
        {

            switch (layerType)
            {
                case LayerType.TEACHER:
                    foreach (var s in myBusinessLayer.getAllTeachers())
                    {
                        Console.WriteLine(s.TeacherId + " " + s.TeacherName);
                    }
                    Console.WriteLine("Enter Teacher ID: ");
                    int NameTeacher = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Enter New Name For Teacher: ");
                    myBusinessLayer.GetTeacherByID(NameTeacher).TeacherName = Console.ReadLine();
                    myBusinessLayer.UpdateTeacher(myBusinessLayer.GetTeacherByID(NameTeacher));
                    Console.WriteLine("Teacher name has been updated to:  " + myBusinessLayer.GetTeacherByID(NameTeacher).TeacherName);

                    break;

                case LayerType.COURSE:
                    foreach (var s in myBusinessLayer.GetAllCourses())
                    {
                        Console.WriteLine(s.CourseId + " " + s.CourseName);
                    }
                    Console.WriteLine("Enter Course ID: ");
                    int NameCourse = Int32.Parse(Console.ReadLine());
                    int choice = -1;
                    Console.WriteLine
                                      (
                                      "\n 0. Update Name \n " +
                                      "1. Update Teacher \n "
                                      );
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Selection invalid\n");
                    }
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Enter New Name For Course: ");
                            myBusinessLayer.GetCourseByID(NameCourse).CourseName = Console.ReadLine();
                            myBusinessLayer.UpdateCourse(myBusinessLayer.GetCourseByID(NameCourse));
                            Console.WriteLine("Course name has been updated to: " + myBusinessLayer.GetCourseByID(NameCourse).CourseName);
                            break;
                        case 1:
                            Console.WriteLine("Enter New Teacher Id For Course: ");
                            myBusinessLayer.GetCourseByID(NameCourse).TeacherId = Int32.Parse(Console.ReadLine());
                            myBusinessLayer.UpdateCourse(myBusinessLayer.GetCourseByID(NameCourse));
                            Console.WriteLine("Course teacher id has been updated to: " + myBusinessLayer.GetCourseByID(NameCourse).TeacherId);
                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }
        }

        static void Delete(BusinessLayer.BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Id to delete:");
            int Id = Int32.Parse(Console.ReadLine());
            switch (layerType)
            {
                case LayerType.TEACHER:
                    if (myBusinessLayer.GetTeacherByID(Id) == null)
                        Console.WriteLine("No teacher by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Teacher: " + myBusinessLayer.GetTeacherByID(Id).TeacherName + " has been deleted");
                        myBusinessLayer.RemoveTeacher(myBusinessLayer.GetTeacherByID(Id));
                    }
                    break;

                case LayerType.COURSE:
                    if (myBusinessLayer.GetCourseByID(Id) == null)
                        Console.WriteLine("No Course by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Course: " + myBusinessLayer.GetCourseByID(Id).CourseName + " has been deleted");
                        myBusinessLayer.RemoveCourse(myBusinessLayer.GetCourseByID(Id));
                    }
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            int choice = -1;
            bool exit = true;
            do
            {
                Console.WriteLine
                   (
                   "\n0. Exit Program \n" +
                   "1. Add Teachers \n" +
                   "2. Update Teacher \n" +
                   "3. Delete Teacher \n" +
                   "4. Display all Teachers \n" +
                   "5. Display Teacher's Courses by Teacher id \n" +
                   "6. Add Course \n" +
                   "7. Update Course \n" +
                   "8. Delete Course \n" +
                   "9. Display all Courses\n"
                   );
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Selection invalid\n");
                }

                BusinessLayer.BusinessLayer myBusinessLayer = new BusinessLayer.BusinessLayer();

                switch (choice)
                {
                    case 0:
                        exit = false;
                        Environment.Exit(0);
                        break;

                    case 1:
                        Add(myBusinessLayer, LayerType.TEACHER);
                        break;

                    case 2:
                        Update(myBusinessLayer, LayerType.TEACHER);
                        break;

                    case 3:
                        Delete(myBusinessLayer, LayerType.TEACHER);
                        break;

                    case 4:
                        foreach (var t in myBusinessLayer.GetAllTeachers())
                        {
                            Console.WriteLine(t.TeacherId + " " + t.TeacherName);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Teacher Id:");
                        int Id = Int32.Parse(Console.ReadLine());
                        var coursePrint = myBusinessLayer.GetAllCourses().Where(t => t.TeacherId == Id);
                        foreach (var course in coursePrint)
                        {
                            Console.WriteLine(course.CourseId + " " + course.CourseName + " ");
                        }
                        break;

                    case 6:
                        Add(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 7:
                        Update(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 8:
                        Delete(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 9:
                        foreach (var c in myBusinessLayer.GetAllCourses())
                        {
                            Console.WriteLine(c.CourseId + " " + c.CourseName);
                        }
                        break;

                    default:
                        Console.WriteLine("Please select a valid Menu Option");
                        break;
                }
            }
            while (exit);
        }

        enum LayerType
        {
            TEACHER,
            COURSE
        }

    }
}
