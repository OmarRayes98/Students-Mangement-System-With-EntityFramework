using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Specializations
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Specializtion Student_Sp = new Specializtion();
        public void Add_Specialization(string specialization_name)
        {
            Student_Sp.Name_Specializtion = specialization_name;

            dbo.Specializtions.Add(Student_Sp);
            dbo.SaveChanges();
        }

        public List<Specializtion> Fill_ListItems()
        {
            List<Specializtion> query = new List<Specializtion>();
            query = dbo.Specializtions.ToList();

            return query;
        }

        public void Delete_Specialization(int id)
        {
            Student_Sp = (from item in dbo.Specializtions where item.Id_Specializtion == id select item).FirstOrDefault();
            dbo.Specializtions.Remove(Student_Sp);//dbo.Entry(Student_Sp).State = System.Data.Entity.EntityState.Deleted;
            dbo.SaveChanges();
        }


    }
}
