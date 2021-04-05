using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Users
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        User user = new User();

        public void Add_User(string name, string pwd , string type)
        {

            user.Name = name;
            user.PWD = pwd;
            user.User_Type = type;

            dbo.Users.Add(user);
            dbo.SaveChanges();

        }


        public void Delete_User(int id)
        {
            user = (from item in dbo.Users where item.Id_User == id select item).FirstOrDefault();
            dbo.Users.Remove(user);//dbo.Entry(user).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
        }

        
        public void Update_User(string name,string pwd ,string type ,int id_user)
        {
            user = (from item in dbo.Users where item.Id_User == id_user select item).Single();
            user.Name = name;
            user.PWD = pwd;
            user.User_Type = type;

            dbo.Entry(user).State = System.Data.Entity.EntityState.Modified;// or without it , it's ok 

            dbo.SaveChanges();
        }

        public List<User> Fill_DGV_User()
        {
            return dbo.Users.ToList();
        }
    }
}
