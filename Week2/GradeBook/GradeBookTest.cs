// Fig. 4.13: GradeBookTest.cs
// GradeBook constructor used to specify the course name at the 
// time each GradeBook object is created.
using System;

public class GradeBookTest
{
    // Main method begins program execution
    public static void Main(string[] args)
    {
        /*// create GradeBook object
        GradeBook gradeBook1 = new GradeBook("CS101 Introduction to C# Programming");
        GradeBook gradeBook2 = new GradeBook("CS102 Data Structures in C#");

        // display initial value of courseName for each GradeBook
        Console.WriteLine("gradeBook1 course name is: {0}",gradeBook1.CourseName);
        Console.WriteLine("gradeBook2 course name is: {0}",gradeBook2.CourseName); */


        GradeBook gradeBook1 = new GradeBook("CS101 Introduction to C# Programming","Ivanov");
        gradeBook1.DisplayMessage();
        Console.WriteLine(gradeBook1.GetGradeBookTitleCourseStart());
    }
} 

