﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Students_Mangement_System
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Office_TutorialsEntities : DbContext
    {
        public Office_TutorialsEntities()
            : base("name=Office_TutorialsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Specializtion> Specializtions { get; set; }
        public virtual DbSet<Student_Regisrtation> Student_Regisrtation { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<Show_Course_Result> Show_Course(Nullable<int> iD_Class)
        {
            var iD_ClassParameter = iD_Class.HasValue ?
                new ObjectParameter("ID_Class", iD_Class) :
                new ObjectParameter("ID_Class", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Show_Course_Result>("Show_Course", iD_ClassParameter);
        }
    
        public virtual ObjectResult<Fill_Name_Rest_Result> Fill_Name_Rest(Nullable<int> id_s)
        {
            var id_sParameter = id_s.HasValue ?
                new ObjectParameter("id_s", id_s) :
                new ObjectParameter("id_s", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Fill_Name_Rest_Result>("Fill_Name_Rest", id_sParameter);
        }
    
        public virtual int Backup_Office_Tutorials(string pathName)
        {
            var pathNameParameter = pathName != null ?
                new ObjectParameter("PathName", pathName) :
                new ObjectParameter("PathName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Backup_Office_Tutorials", pathNameParameter);
        }
    
        public virtual int Backup_Office_Tutorial(string pathName)
        {
            var pathNameParameter = pathName != null ?
                new ObjectParameter("PathName", pathName) :
                new ObjectParameter("PathName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Backup_Office_Tutorial", pathNameParameter);
        }
    
        public virtual ObjectResult<Print_LastBill_Result> Print_LastBill(Nullable<int> total, Nullable<int> max_Bill)
        {
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(int));
    
            var max_BillParameter = max_Bill.HasValue ?
                new ObjectParameter("Max_Bill", max_Bill) :
                new ObjectParameter("Max_Bill", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Print_LastBill_Result>("Print_LastBill", totalParameter, max_BillParameter);
        }
    }
}