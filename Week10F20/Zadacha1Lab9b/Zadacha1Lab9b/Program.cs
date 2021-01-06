using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1Lab9b
{
    class Program
    {
        private enum Subjects { English, CS, Math };
        static void Main(string[] args)
        {
            StudentCardReport report = new StudentCardReport();// 1. subsribe for event source
            report.PassOrFail += OnPassOrFail;// 2. subsribe for event PassOrFail

            // Subscriber generate event args
            List<Subject> list = new List<Subject>();
            string[] titles = new string[]{"English", "Math", "CS"};
            Random r = new Random();
            int[] grades;
            for (int i = 0; i < titles.Length; i++)
            {
                grades = new int[Subject.MAX_GRADES];
                for (int j = 0; j < Subject.MAX_GRADES; j++)
                {
                    grades[j] = r.Next(0, 151);
                }
                Subject s = new Subject(titles[i], grades);
                Console.WriteLine(s);
                Console.WriteLine();
                list.Add(s);
            }

            report.ListOfGrades = list;
            report.ProcessReport(); // Activate event source
        }
        private static void OnPassOrFail(object sender, EventArgs args)
        {
            Subject subject = (Subject)args;
            string output = subject.Title + "Congratulations: Passing";
            Console.WriteLine(output);
        }

    }
}
