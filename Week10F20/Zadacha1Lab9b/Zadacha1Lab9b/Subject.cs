using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1Lab9b
{
    public class Subject : EventArgs
    {  // Event object

        public const int MAX_GRADES = 5;
        public string Title { get; set; }
        private int[] grades;
        public Subject(string title, int[] grades)
        {
            Title = title;
            Grades = grades;
        }
        /// <summary>
        /// propfull + Tab
        /// </summary>
        public int[] Grades
        {
            get
            {
                int[] temp = new int[grades.Length];
                grades.CopyTo(temp,0);

                return temp;
            }
            set
            {
                if (value != null && value.Length == MAX_GRADES)
                {
                    grades = new int[MAX_GRADES];
                    for (int i = 0; i < MAX_GRADES; i++)
                    {
                        grades[i] = value[i];
                    }
                }
                else
                    grades = new int[MAX_GRADES];
            }
        }

        public override string ToString()
            =>$"{Title} [ {( string.Join(", ", grades))} ]";
             
        }
    }

