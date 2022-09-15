using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
                int i = 1;


                var students = dBEntities.Students.FirstOrDefault(s => s.StudentId == 1);

                dBEntities.Entry(students).Reference(s => s.StudentAddress).Load();

                dBEntities.Entry(students).Reference(s => s.Standard).Load();

                dBEntities.Entry(students).Collection(s => s.Courses).Load();

                Console.WriteLine($"studentId: {students.StudentId} Name= {students.FirstName}{students.LastName} Standard Id = {students.StandardId}");

                foreach (var cou in students.Courses)
                {
                    Console.WriteLine($"CourseName:{cou.CourseName}");
                }

                //var listStud = //dBEntities.Students.Include<Student>(x => x.Standard).ToList();
                //    (from s in dBEntities.Students.Include("Standard") select s).ToList();

                //var studenlist = dBEntities.Students.SqlQuery("Select * from Student").ToList<Student>();

                //Console.WriteLine($"studentId: {student.StudentId} Name= {student.FirstName}{student.LastName} Standard Id = {student.StandardId}");

                //var studentEntity = dBEntities.Students.SqlQuery("SELECT * FROM Student WHERE StudentId = @StudentId", new SqlParameter("@StudentId", i)).FirstOrDefault();

                //Console.WriteLine($"studentId: {studentEntity.StudentId} Name= {studentEntity.FirstName}{studentEntity.LastName} Standard Id = {studentEntity.StandardId}");

                //List<Student> listStud = dBEntities.Students.ToList();
                //foreach (Student std in listStud)
                //{
                //    Console.WriteLine($"studentId: {std.StudentId} Name= {std.FirstName}{std.LastName} Standard Id = {std.StandardId}");
                //}

            }
            Console.ReadKey();
        }
    }
}
