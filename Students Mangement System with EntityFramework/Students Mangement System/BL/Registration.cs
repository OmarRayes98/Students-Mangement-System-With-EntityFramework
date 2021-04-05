using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Students_Mangement_System.BL
{
    class Registration
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Student_Regisrtation registration = new Student_Regisrtation();

        public void Add_SRegistration(int id_student, int ID_class, DateTime date, int Value_R, string Note_R)
        {
            registration = new Student_Regisrtation();

            //to get the sequence number 
            var connection = dbo.Database.Connection;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Next value For Id_SR;";
            var obj = cmd.ExecuteScalar();

            connection.Close();

            int sequence_ID = (int)obj;
            //end

            registration.Id_SR = sequence_ID;
            registration.Id_S = id_student;
            registration.Id_Class = ID_class;
            registration.Date_Reg = date;
            registration.Value_Reg = Value_R;
            registration.Note_Reg = Note_R;


            dbo.Student_Regisrtation.Add(registration);
            dbo.SaveChanges();

        }


        public List<Student> Fill_ChooseStudent()
        {
            return (from item in dbo.Students orderby item.Id_S descending select item).ToList();

        }

        public List<Class> Fill_ChooseClass()
        {
            return (from item in dbo.Classes orderby item.Id_Class descending select item).ToList();
        }
        

        public List< Show_Course_Result>  Show_Coures_Cost(int ID_Class)
        {
            return dbo.Show_Course(ID_Class).ToList(); 
        }

        public Array Show_SRegistrations()
        {

            return (from register in dbo.Student_Regisrtation
                    join student in dbo.Students on register.Id_S equals student.Id_S
                    join classes in dbo.Classes on register.Id_Class equals classes.Id_Class
                    select new { register.Id_SR, student.Name, name_class=classes.Name,register.Date_Reg, register.Value_Reg, register.Note_Reg  }).ToArray();
        }

        public void Delete_Register(int id)
        {
            registration = (from item in dbo.Student_Regisrtation where item.Id_SR == id select item).FirstOrDefault();
            dbo.Student_Regisrtation.Remove(registration);//dbo.Entry(students).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
        }

        public void Update_Register(int ID_student, int ID_class, DateTime date, int value_Reg, string cause, int ID_SReg)
        {
            registration = (from item in dbo.Student_Regisrtation where item.Id_SR == ID_SReg select item).Single();
            registration.Id_S = ID_student;
            registration.Id_Class = ID_class;
            registration.Date_Reg = date;
            registration.Value_Reg = value_Reg;
            registration.Note_Reg = cause;

            dbo.Entry(registration).State = System.Data.Entity.EntityState.Modified;// or without it , it's ok 

            dbo.SaveChanges();

        }

        public Array Search_SRegister(string name)
        {
            return (from register in dbo.Student_Regisrtation
                    join student in dbo.Students on register.Id_S equals student.Id_S
                    join classes in dbo.Classes on register.Id_Class equals classes.Id_Class
                    where student.Name.Contains(name) || classes.Name.Contains(name)
                    select new { register.Id_SR, student.Name, name_class = classes.Name, register.Date_Reg, register.Value_Reg, register.Note_Reg }).ToArray();
        }

        public Student_Regisrtation Check_FindStudentClass(int ID_Student, int ID_Class)
        {
            registration = (from item in dbo.Student_Regisrtation where item.Id_S == ID_Student && item.Id_Class == ID_Class select item).FirstOrDefault();
            return registration;
        }

        public Student_Regisrtation Check_FindStudentCourse(int ID_Student, string Name_Course)
        {
            registration = (from classes in dbo.Classes
                            join course in dbo.Courses on classes.Id_Course equals course.Id_Course
                            join register in dbo.Student_Regisrtation on classes.Id_Class equals register.Id_Class
                            join student in dbo.Students on register.Id_S equals student.Id_S
                            where register.Id_S == ID_Student && course.Name == Name_Course select register).FirstOrDefault();
            return registration;
        }



    }

}

