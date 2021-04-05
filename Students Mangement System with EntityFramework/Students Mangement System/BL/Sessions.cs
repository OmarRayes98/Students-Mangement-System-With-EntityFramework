using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Sessions
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Session session = new Session();

        public void Add_Session(string Days , string Time , int ID_Class)
        {
            session = new Session();

            //to get the sequence number 
            var connection = dbo.Database.Connection;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Next value For Id_Seesion;";
            var obj = cmd.ExecuteScalar();

            connection.Close();

            int sequence_ID = (int)obj;
            //end

            session.Id_Session = sequence_ID;
            session.Day_S = Days;
            session.Time_S = Time;
            session.Id_Class = ID_Class;

            dbo.Sessions.Add(session);
            dbo.SaveChanges();

        }

        public void Delete_Session(int id)
        {
            session = (from item in dbo.Sessions where item.Id_Session == id select item).FirstOrDefault();
            dbo.Sessions.Remove(session);//dbo.Entry(students).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
        }

        public void Update_Session(string Days, string Time, int ID_Class,int ID_Session)
        {
            session = (from item in dbo.Sessions where item.Id_Session == ID_Session select item).Single();
            session.Day_S = Days;
            session.Time_S = Time;
            session.Id_Class = ID_Class;

            dbo.Entry(session).State = System.Data.Entity.EntityState.Modified;// or without it , it's ok 

            dbo.SaveChanges();



        }

        public List<Class> Fill_ChooseClass()
        {
            return (from item in dbo.Classes orderby item.Id_Class descending select item).ToList();

        }

        public Array Fill_Sessions()
        {
            return (from session in dbo.Sessions
                    join classes in dbo.Classes on session.Id_Class equals classes.Id_Class
                    select new { session.Id_Session , classes.Name , session.Day_S , session.Time_S}).ToArray();
        
    }

    }
}
