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
        static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                Console.WriteLine
                   (
                   "\n 0. Exit Program \n" +
                   "1. Add Teachers \n" +
                   "2. Update Teacher \n" +
                   "3. Delete Teacher \n" +
                   "4. Display all Teachers \n" +
                   "5. Display Teacher's Courses by Teacher id \n" +
                   "6. Add Course \n" +
                   "7. Update Course \n" +
                   "8. Delete Course \n " +
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

                BusinessLayer myBusinessLayer = new BusinessLayer();

                switch (choice)
                {
                    case 0:
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
                            Console.WriteLine(t.TeacherId + " " + t.TeacherName + " " + t.Description);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Teacher Id:");
                        int Id = Int32.Parse(Console.ReadLine());
                        var coursePrint = myBusinessLayer.getAllCourses().Where(t => t.TeacherId == Id);
                        foreach (var course in coursePrint)
                        {
                            Console.WriteLine(course.StudentID + " " + course.StudentName + " ");
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
                        foreach (var c in myBusinessLayer.getAllCourses())
                        {
                            Console.WriteLine(c.CourseID + " " + c.CourseName);
                        }
                        break;

                    default:
                        Console.WriteLine("Please select a valid Menu Option");
                        break;
                }
            }
            while ((choice >= 0) & (choice < 10));
        }

        enum LayerType
        {
            TEACHER,
            COURSE
        }

    }
}
