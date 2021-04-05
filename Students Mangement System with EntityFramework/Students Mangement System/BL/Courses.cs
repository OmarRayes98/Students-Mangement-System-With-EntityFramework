using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Courses
    {

        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Course course = new Course();


        public Array Fill_Courses()
        {
        return (from item in dbo.Courses select new { item.Id_Course, item.Name, item.Cost }).ToArray();          
        }

        public void Add_Courses(string name, int cost)
        {
            course = new Course();
            
            //to get the sequence number 
            var connection = dbo.Database.Connection;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Next value For Id_Course;";
            var obj = cmd.ExecuteScalar();

            connection.Close();

            int course_ID = (int)obj;
            //end

            course.Id_Course = course_ID;
            course.Name = name;
            course.Cost = cost;
            dbo.Courses.Add(course);
            dbo.SaveChanges();

        }

        public void Delete_Course(int id)
        {
            course = (from item in dbo.Courses where item.Id_Course == id select item).FirstOrDefault();
            dbo.Courses.Remove(course);//dbo.Entry(students).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
        }

        public void Update_Course(int id,string name , int cost)
        {
            course = (from item in dbo.Courses where item.Id_Course == id select item).Single();
            course.Name = name;
            course.Cost = cost;

            dbo.Entry(course).State = System.Data.Entity.EntityState.Modified;// or without it , it's ok 

            dbo.SaveChanges();



        }


    }
}
