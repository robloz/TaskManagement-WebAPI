//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManagement.Web.Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {

        public int Id { get; set; }
        public string SubjectTask { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public List<Link> Links { get; set; }
    }
}
