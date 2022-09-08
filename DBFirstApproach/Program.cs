using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EF_Demo_DBEntities dBEntities = new EF_Demo_DBEntities())
            {
                List<Student> listStudents = dBEntities.Students.ToList();

                foreach (Student std in listStudents)
                {
                    Console.WriteLine($"Name = {std.FirstName} {std.LastName}, " +
                        $"Email = {std.StudentAddress.Email}, Mobile = {std.StudentAddress.Mobile}");
                }
            }
            Console.ReadKey();
        }
    }
}
