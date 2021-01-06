using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1Lab9b
{
   public class StudentCardReport
    { //Publisher: Event source
        public event EventHandler PassOrFail; // 1. publish event
        public List<Subject> ListOfGrades { get; set; }

        public StudentCardReport( )
        {   
            
        }
       
        public void ProcessReport()
        {
            foreach (var item in ListOfGrades)
            {
                int[] grades = item.Grades;

                foreach (var grade in grades)
                {
                    if(grade > 75)
                        PassOrFail?.Invoke(this, item);// 2. fire event
                    else
                        Console.WriteLine("{0}: Grade: F", item.Title);
                }
               
            }

        }
    }
}
