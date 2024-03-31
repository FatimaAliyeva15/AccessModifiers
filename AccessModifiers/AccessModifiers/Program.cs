using System.Text.RegularExpressions;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Group group = new Group();

            Console.WriteLine("Qrup yarat");
            Console.Write("No: ");
            group.No = Console.ReadLine();

            Console.Write("");
            string studentlimitStr = "";
            int studentlimit;
            do
            {
                Console.Write("StudentLimit: ");
                studentlimitStr = Console.ReadLine();
            } while (!int.TryParse(studentlimitStr, out studentlimit));

            group.StudentLimit = studentlimit;

            Console.WriteLine("");
            Console.WriteLine("Qrup yaradildi");
            Console.WriteLine($"Qrup Nomresi: {group.No}");
            Console.WriteLine($"Telebe Limit sayi: {group.StudentLimit}");
            

            bool check = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Telebe elave et");
                Console.WriteLine("2. Bütün telebelere bax");
                Console.WriteLine("3. Telebeler uzre axtarış et");
                Console.WriteLine("0. Proqramı bitir");

                string choiceStr;
                byte choice;

                do
                {
                    Console.WriteLine("");
                    Console.Write("Sechim edin: ");
                    choiceStr = Console.ReadLine();
                } while (!byte.TryParse(choiceStr, out choice));


                if(choice == 1)
                {
                    Console.WriteLine("");
                    if(group.Students.Length < group.StudentLimit)
                    {
                        Console.WriteLine("Telebe elave et");

                        Console.WriteLine("");
                        Console.Write("Telebenin tam adini daxil et: ");
                        string fullname = Console.ReadLine();

                        Console.Write("");
                        Console.Write("Telebenin qrup nomresini daxil et: ");
                        string groupno;
                        do
                        {
                            groupno = Console.ReadLine();
                            if (!Regex.IsMatch(groupno, @"^[A-Z]{2}\d{3}$"))
                            {
                                Console.Write("Qrup nomresini duzgun daxil et: ");
                            }
                        } while (!Regex.IsMatch(groupno, @"^[A-Z]{2}\d{3}$"));


                        string avgPointStr;
                        double avgpoint;
                        do
                        {
                            Console.Write("Telebenin ortalama balini daxil et: ");
                            avgPointStr = Console.ReadLine();
                        } while (!double.TryParse(avgPointStr, out avgpoint));

                        Student student = new Student(fullname, groupno, avgpoint);

                        //group.AddStudent(student);

                        if (groupno == group.No)
                        {
                            group.AddStudent(student);
                            Console.WriteLine("");
                            Console.WriteLine("Telebe elave olundu");

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Bele bir qrup yoxdur");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Telebe limiti asilmisdir. Artiq telebe elave etmek olmaz. Basqa sechim edin");
                    }

                }

                else if(choice == 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bütün telebelere bax");
                    Console.WriteLine("");
                    group.ShowAllStudents();

                    //for (int i = 0; i < group.Students.Length; i++)
                    //{
                    //    Student student = group.Students[i];
                    //    Console.WriteLine($"{student.FullName}, {student.GroupNo}, {student.AvgPoint}");
                    //}

                }

                else if(choice == 3)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Telebeler uzre axtarış et");
                    Console.WriteLine("");
                    Console.Write("Axtarilan telebenin tam adini daxil et: ");
                    string search = Console.ReadLine();
                    Console.WriteLine("");

                    bool checkSearch = false;
                    for(int i = 0;i<group.Students.Length; i++)
                    {
                        Student student = group.Students[i];
                        if(search == student.FullName)
                        {
                            Console.WriteLine($"{student.FullName}, {student.GroupNo}, {student.AvgPoint}");
                            checkSearch = true; 
                        }
                    }
                    if (!checkSearch)
                    {
                        Console.WriteLine("Qrupda bele bir telebe yoxdur");
                    }
                }

                else if(choice == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Proqram bitdi");
                    check = false;
                    break;
                }

                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Duzgun sechim edin");

                }

            } while (check);

        }
    }
}


