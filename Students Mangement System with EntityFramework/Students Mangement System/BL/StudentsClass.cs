using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Mangement_System.BL
{
    class StudentsClass
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        public Array Show_Students(int id_class)
        {
            return (from Student_Reg in dbo.Student_Regisrtation
                    join student in dbo.Students on Student_Reg.Id_S equals student.Id_S
                    join classes in dbo.Classes on Student_Reg.Id_Class equals classes.Id_Class
                    join specialization in dbo.Specializtions on student.Id_Specializtion equals specialization.Id_Specializtion
                    where classes.Id_Class == id_class
                    select new {Student_Reg.Id_S,student.Name,student.Phone,specialization.Name_Specializtion, Class_Name = classes.Name,Student_Reg.Value_Reg,Student_Reg.Date_Reg,Student_Reg.Note_Reg}).ToArray();
                    
        }

    }
}
