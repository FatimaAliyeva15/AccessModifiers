using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class Student
    {


        public Student(string fullname, string groupno, double avgpoint)
        {
            FullName = fullname;
            GroupNo = groupno;
            AvgPoint = avgpoint;
        }



        public string FullName { get; set; }
        private string _groupNo;
        private double _avgPoint { get; set; }

        public string GroupNo 
        {
            get { return _groupNo; }

            set
            {
                string check = @"^[A-Z]{2}\d{3}$";
                if (Regex.IsMatch(value, check))
                {
                    _groupNo = value;
                }
                else
                {
                    Console.WriteLine("GroupNO duzgun daxil et");
                }
            } 
        }

        public double AvgPoint 
        {
            get { return _avgPoint; }

            set
            {
                bool check = false;
                do
                {
                    if (value >= 0 && value <= 100)
                    {
                        _avgPoint = value;
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Ortalama bali duzgun daxil edilmeyib");
                        
                        string point;
                        do
                        {
                            Console.Write("Telebenin ortalama balini daxil et: ");
                            point = Console.ReadLine();
                        } while ((!double.TryParse(point, out value)));
                    }

                } while (!check);
            } 
        
        }


    }
}


