//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManagement.Data.SqlServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public Task()
        {
            this.tbl_TaskUser = new HashSet<TaskUser>();
            this.tbl_category = new HashSet<Category>();
        }
    
        public int id { get; set; }
        public string subjectTask { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> idPriority { get; set; }
        public Nullable<int> idStatus { get; set; }
    
        public virtual Priority tbl_priority { get; set; }
        public virtual Status tbl_status { get; set; }
        public virtual ICollection<TaskUser> tbl_TaskUser { get; set; }
        public virtual ICollection<Category> tbl_category { get; set; }
    }
}
