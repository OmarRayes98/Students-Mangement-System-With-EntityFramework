using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Cls_OldBill
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();


        public Array Fill_DGV(int id_s)
        {
            return (from bill in dbo.Bills join student in dbo.Students on bill.Id_S equals student.Id_S where student.Id_S == id_s select new {bill.Id_Bill ,bill.Paid,bill.Rest,bill.Date }).ToArray();
        }

        public int Sum_Paid(int id_s)
        {
            return (from student in dbo.Students join bill in dbo.Bills on student.Id_S equals bill.Id_S where bill.Id_S == id_s select (int?)bill.Paid ?? 0).Sum();
        }

        public int Sum_ValueReg (int id_s)
        {
            return (from studentR in dbo.Student_Regisrtation join student in dbo.Students on studentR.Id_S equals student.Id_S where studentR.Id_S == id_s select (int?)studentR.Value_Reg ?? 0).Sum();
        }

        public List<Fill_Name_Rest_Result> Show_Name_Rest (int id_s)
        {
            return dbo.Fill_Name_Rest(id_s).ToList();
        }
    }
}
