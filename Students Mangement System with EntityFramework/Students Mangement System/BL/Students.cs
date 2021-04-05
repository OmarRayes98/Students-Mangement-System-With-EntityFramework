using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{

    class Students
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Student students = new Student();
        public void Add_Student(string name,string phone,string land_line,string gender,int specialization)
        {
             students = new Student();

            //to get the sequence number 
            var connection = dbo.Database.Connection;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText= "SELECT Next value For Id_Students;";
            var obj = cmd.ExecuteScalar();

            connection.Close();

            int sequence_ID = (int)obj;
            //end
                     
            students.Id_S = sequence_ID;
            students.Name = name;
            students.Phone = phone;
            students.Land_Line = land_line;
            students.Gender = gender;
            students.Id_Specializtion = specialization;
            
             dbo.Students.Add(students);
             dbo.SaveChanges();

        }

        public Array Show_Students()
        {
            
            return (from student in dbo.Students
                    join sp in dbo.Specializtions on student.Id_Specializtion equals sp.Id_Specializtion
                    select new { student.Id_S, student.Name, student.Land_Line, student.Phone, student.Gender, sp.Name_Specializtion }).ToArray();          
        }

        public void Delete_Student(int id)
        {
            students = (from item in dbo.Students where item.Id_S == id select item).FirstOrDefault();
            dbo.Students.Remove(students);//dbo.Entry(students).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
        }


        public void Update_Student(string name, string phone, string land_line, string gender, int specialization,int id)
        {
             students = (from item in dbo.Students where item.Id_S == id select item).Single();
             students.Name = name;
             students.Phone = phone;
             students.Land_Line = land_line;
             students.Gender = gender;
             students.Id_Specializtion = specialization;

             dbo.Entry(students).State = System.Data.Entity.EntityState.Modified;// or without it , it's ok 

             dbo.SaveChanges();



        }

        public Array Search_Student(string name)
        {
            return (from student in dbo.Students
                    join sp in dbo.Specializtions on student.Id_Specializtion equals sp.Id_Specializtion
                    where student.Name.Contains(name) || sp.Name_Specializtion.Contains(name)
                    select new { student.Id_S, student.Name, student.Land_Line, student.Phone, student.Gender, sp.Name_Specializtion }).ToArray();

        }


        public Student Check_Student(string name)
        {
            students = (from item in dbo.Students where item.Name==name  select item).SingleOrDefault();
            return students;

        }

    }
}
