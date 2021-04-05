using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Login
    {
        
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        User Tb_User = new User();

        public List<User> AllUser()
        {
            List<User> query = new List<User>();
            query = dbo.Users.ToList();

            return query;
         
        }

        public User Check_Login (string Name, string PWD)
        {
            Tb_User= (from item in dbo.Users where item.Name == Name && item.PWD == PWD select item).FirstOrDefault();
            return Tb_User;
     
        }
    }
}
