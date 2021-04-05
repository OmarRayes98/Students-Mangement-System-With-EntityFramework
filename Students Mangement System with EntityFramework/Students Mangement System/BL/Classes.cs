using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Classes
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Class classes = new Class();

        public Array Fill_Classes()
        {
            return (from item in dbo.Classes select new { item.Id_Class, item.Name, item.Id_Course}).ToArray();
        }

        public void Add_Classes(string name, int Id_Course)
        {
            classes = new Class();

            //to get the sequence number 
            var connection = dbo.Database.Connection;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Next value For Id_Class;";
            var obj = cmd.ExecuteScalar();

            connection.Close();

            int class_ID = (int)obj;
            //end

            classes.Id_Class = class_ID;
            classes.Name = name;
            classes.Id_Course = Id_Course;
            dbo.Classes.Add(classes);
            dbo.SaveChanges();

        }

        public Class Check_Class(string Name)
        {
            classes = (from item in dbo.Classes where item.Name == Name select item).FirstOrDefault();
            return classes;

        }

        public void Delete_Class(int id)
         {
             classes = (from item in dbo.Classes where item.Id_Class == id select item).FirstOrDefault();
             dbo.Classes.Remove(classes);//dbo.Entry(classes).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
         }
        
        public void Update_Class(int id, string name, int id_course)
        {
            classes = (from item in dbo.Classes where item.Id_Class == id select item).Single();
            classes.Name = name;
            classes.Id_Course = id_course;

            dbo.Entry(classes).State = System.Data.Entity.EntityState.Modified;// or without it , it's ok 

            dbo.SaveChanges();



        }

        
        public List<Course> Fill_ComNameClassCourse()
        {
            List<Course> query = new List<Course>();
            query = dbo.Courses.ToList();

            return query;

        }

        public Array Search_Class(string name)
        {      
            return (from item in dbo.Classes where item.Name.Contains(name) select new { item.Id_Class, item.Name, item.Id_Course }).ToArray();

        }


    }
}
