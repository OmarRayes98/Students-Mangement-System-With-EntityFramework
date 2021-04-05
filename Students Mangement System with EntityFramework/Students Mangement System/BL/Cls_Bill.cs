using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class Cls_Bill
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        Bill bill = new Bill();

        public List<Student> ShowComStudent()
        {
            return (from student in dbo.Students
                    join studentR in dbo.Student_Regisrtation on student.Id_S equals studentR.Id_S
                    orderby student.Id_S descending
                    select student).ToList();
        }
        public Array ShowDGV_Bill()
        {
            return (from bill in dbo.Bills
                    join student in dbo.Students
                    on bill.Id_S equals student.Id_S
                    select new { bill.Id_Bill , student.Name , bill.Paid , bill.Rest , bill.Date} ).ToArray();
        }


        public void Add_Bill(int Paid, int Rest, DateTime date, int ID_S)
        {
            bill = new Bill();

            //to get the sequence number 
            var connection = dbo.Database.Connection;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Next value For Id_Bill;";
            var obj = cmd.ExecuteScalar();

            connection.Close();

            int sequence_ID = (int)obj;
            //end

            bill.Id_Bill = sequence_ID;
            bill.Paid = Paid;
            bill.Rest = Rest;
            bill.Date = date;
            bill.Id_S = ID_S;
            
            dbo.Bills.Add(bill);
            dbo.SaveChanges();

        }

        public void Delete_Bill(int id)
        {
            bill = (from item in dbo.Bills where item.Id_Bill == id select item).FirstOrDefault();
            dbo.Bills.Remove(bill);//dbo.Entry(students).State = System.Data.Entity.EntityState.Deleted;

            dbo.SaveChanges();
        }


        public int Sum_OldPaid (int id_s)
        {
            return (from bill in dbo.Bills join student in dbo.Students on bill.Id_S equals student.Id_S where bill.Id_S == id_s select (int?) bill.Paid ?? 0).Sum();
                           
        }

        //  SqlDataAdapter da = new SqlDataAdapter("select ISNULL(SUM(Value_Reg),0) as 'Result' from Student_Regisrtation inner join Students on Students.Id_S=Student_Regisrtation.Id_S where Student_Regisrtation.Id_S='" + Convert.ToInt32(Com_NameS.SelectedValue) + "'", DB.sqlconnection);
        public int Sum_Total(int id_s)
        {
            return (from studentR in dbo.Student_Regisrtation join student in dbo.Students on studentR.Id_S equals student.Id_S where studentR.Id_S == id_s select (int?) studentR.Value_Reg ?? 0).Sum();

        }

        public Array ShowDGV_Search(string search)
        {
            return (from bill in dbo.Bills
                    join student in dbo.Students
                    on bill.Id_S equals student.Id_S where student.Name.Contains(search) || bill.Date.ToString().Contains(search)
                    select new { bill.Id_Bill, student.Name, bill.Paid, bill.Rest, bill.Date }).ToArray();
        }

        public int Max_Bill()
        {
            return (from max_bill in dbo.Bills select max_bill.Id_Bill).Max();
        }

        public List<Print_LastBill_Result> Last_Bill(int sum_total,int max_bill)
        {
            return dbo.Print_LastBill(sum_total, max_bill).ToList();
        }


    }
}
