using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class Group
    {
        private string _no;
        private int _studentLimit;
        
        public string No 
        {
            get {  return _no; }

            set
            {
                bool check = false;
                do
                {
                    string check2 = @"^[A-Z]{2}\d{3}$";
                    if (Regex.IsMatch(value, check2))
                    {
                        _no = value;
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Qrup nomresi duzgun daxil et");
                        Console.Write("No: ");
                        value = Console.ReadLine();

                    }
                }while (!check);
            } 
        
        }

        public int StudentLimit 
        {
            
            get { return _studentLimit; } 
            
            set
            {
                bool check = false;
                do
                {
                    if (value >= 0 && value <= 20)
                    {
                        _studentLimit = value;
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Limit duzgun daxil et");
                        string limit;
                        do
                        {
                            Console.Write("StudentLimit: ");
                            limit = Console.ReadLine();
                        } while (!int.TryParse(limit, out value));
                    }
                } while (!check);
            }
        
        }

        public Student[] Students = new Student[] { };

        public void AddStudent(Student student)
        {
            if(Students.Length < StudentLimit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("Telebe limiti aşılmışdır");
            }
        }

        public void ShowAllStudents()
        {
            for(int i = 0; i < Students.Length; i++)
            {
                Student student = Students[i];
                Console.WriteLine($"{student.FullName}, {student.GroupNo}, {student.AvgPoint}");
            }
        }
        
    }
}
