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
        /*
         * Used to add an element to the database, both Teacher and Course
         */
        static void Add(BusinessLayer.BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Name:");
            string Name = Console.ReadLine();//User input for name
            switch (layerType)//controls which table is added to
            { 
                case LayerType.TEACHER://Used to add to Teacher table
                    Teacher newTeacher = new Teacher() { TeacherName = Name };
                    myBusinessLayer.AddTeacher(newTeacher);
                    Console.WriteLine("Teacher: " + Name + " created.");
                    break;
                case LayerType.COURSE://Used to add to Course table
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

        /*
         * Used to update an element to the database, both Teacher and Course
         */
        static void Update(BusinessLayer.BusinessLayer myBusinessLayer, LayerType layerType)
        {

            switch (layerType)//controls which table is updated
            {
                case LayerType.TEACHER://Updates Teacher Table
                    foreach (var s in myBusinessLayer.getAllTeachers())//displays all the elements in Teacher
                    {
                        Console.WriteLine(s.TeacherId + " " + s.TeacherName);
                    }
                    Console.WriteLine("Enter Teacher ID: ");
                    int NameTeacher = Int32.Parse(Console.ReadLine());//User input for TeacherID 

                    Console.WriteLine("Enter New Name For Teacher: ");
                    myBusinessLayer.GetTeacherByID(NameTeacher).TeacherName = Console.ReadLine();//User input for change of name
                    myBusinessLayer.UpdateTeacher(myBusinessLayer.GetTeacherByID(NameTeacher));//Updates the column
                    Console.WriteLine("Teacher name has been updated to:  " + myBusinessLayer.GetTeacherByID(NameTeacher).TeacherName);

                    break;

                case LayerType.COURSE://Updates Course Table
                    foreach (var s in myBusinessLayer.GetAllCourses())//Displays all elements in Course Table
                    {
                        Console.WriteLine(s.CourseId + " " + s.CourseName);
                    }
                    Console.WriteLine("Enter Course ID: ");
                    int NameCourse = Int32.Parse(Console.ReadLine());//User input for CourseID
                    int choice = -1;
                    Console.WriteLine
                                      (
                                      "\n 0. Update Name \n " +
                                      "1. Update Teacher \n "
                                      );
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine())//User input for update choice
                    }
                    catch//Makes sure choice is valid
                    {
                        Console.WriteLine("Selection invalid\n");
                    }
                    switch (choice)//Used to choose update choice
                    {
                        case 0://Used to update course name
                            Console.WriteLine("Enter New Name For Course: ");
                            myBusinessLayer.GetCourseByID(NameCourse).CourseName = Console.ReadLine();//User input for Course name change
                            myBusinessLayer.UpdateCourse(myBusinessLayer.GetCourseByID(NameCourse));//Updates row in Course
                            Console.WriteLine("Course name has been updated to: " + myBusinessLayer.GetCourseByID(NameCourse).CourseName);
                            break;
                        case 1://Used to update Teacher who teaches course
                            Console.WriteLine("Enter New Teacher Id For Course: ");
                            myBusinessLayer.GetCourseByID(NameCourse).TeacherId = Int32.Parse(Console.ReadLine());//User input for TeacherID change
                            myBusinessLayer.UpdateCourse(myBusinessLayer.GetCourseByID(NameCourse));//Updates row in course
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
        /*
         * Used to delete Row from table, both Teacher and Course
         */
        static void Delete(BusinessLayer.BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Id to delete:");
            int Id = Int32.Parse(Console.ReadLine());//User input for deletion element id
            switch (layerType)//Used to Decide the table the element will be deleted from
            {
                case LayerType.TEACHER://Used to delete elements from Teacher Table
                    if (myBusinessLayer.GetTeacherByID(Id) == null)//Checks if element exists
                        Console.WriteLine("No teacher by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Teacher: " + myBusinessLayer.GetTeacherByID(Id).TeacherName + " has been deleted");
                        myBusinessLayer.RemoveTeacher(myBusinessLayer.GetTeacherByID(Id));//Removes row from Teacher Table
                    }
                    break;

                case LayerType.COURSE://Used to delete elements from Course Table
                    if (myBusinessLayer.GetCourseByID(Id) == null)//Checks if element exists 
                        Console.WriteLine("No Course by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Course: " + myBusinessLayer.GetCourseByID(Id).CourseName + " has been deleted");
                        myBusinessLayer.RemoveCourse(myBusinessLayer.GetCourseByID(Id));//removes row from Course Table
                    }
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            int choice = -1;
            bool exit = true;//Used to stop loop
            do
            {
                Console.WriteLine//Menu
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
                    choice = Int32.Parse(Console.ReadLine());//Menu choice
                }
                catch
                {
                    Console.WriteLine("Selection invalid\n");
                }

                BusinessLayer.BusinessLayer myBusinessLayer = new BusinessLayer.BusinessLayer();

                switch (choice)//Used to navigate Menu
                {
                    case 0://Exits Menu loop
                        exit = false;
                        Environment.Exit(0);
                        break;

                    case 1://Add to Teacher
                        Add(myBusinessLayer, LayerType.TEACHER);
                        break;

                    case 2://Update Teacher
                        Update(myBusinessLayer, LayerType.TEACHER);
                        break;

                    case 3://Remove Teacher
                        Delete(myBusinessLayer, LayerType.TEACHER);
                        break;

                    case 4://Dislays all Teachers
                        foreach (var t in myBusinessLayer.GetAllTeachers())
                        {
                            Console.WriteLine(t.TeacherId + " " + t.TeacherName);
                        }
                        break;

                    case 5://Displays one Teacher and all courses the teach
                        Console.WriteLine("Teacher Id:");
                        int Id = Int32.Parse(Console.ReadLine());
                        var coursePrint = myBusinessLayer.GetAllCourses().Where(t => t.TeacherId == Id);
                        foreach (var course in coursePrint)
                        {
                            Console.WriteLine(course.CourseId + " " + course.CourseName + " ");
                        }
                        break;

                    case 6://Adds Course
                        Add(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 7://Updates Course
                        Update(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 8://Deletes Course
                        Delete(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 9://Displays all Courses
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

        enum LayerType//Used to differentiate between Teacher and Course
        {
            TEACHER,
            COURSE
        }

    }
}
