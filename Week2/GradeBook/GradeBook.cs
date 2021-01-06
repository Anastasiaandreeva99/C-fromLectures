// Fig. 4.12: GradeBook.cs
// GradeBook class with a constructor to initialize the course name.
using System;

public class GradeBook
{
    private string courseName; 
                              
    #region Constructors
    public GradeBook(string name, string instructorName)
    {
        CourseName = name; 
        InstructorName = instructorName;
    } 
    #endregion


    #region Properties

    public int CourseStart => DateTime.Now.Year;
    public string CourseName
    {
        get
        {
            return courseName;
        }
        set
        {
            courseName = value;
        } 
    } 

    public string InstructorName { get; set; }

    #endregion


    public void DisplayMessage()
    {
        Console.WriteLine($"This course is presented by:{InstructorName} ");
        Console.WriteLine("Welcome to the grade book for\n{0}!", CourseName);
    } 

    public (int, string, string) GetGradeBookTitleCourseStart()
                       => (CourseStart, CourseName, InstructorName);
    public void ChangeCourseTitle((string name, string instructor) title)
        => (CourseName, InstructorName) = (title.name, title.instructor);
} 


