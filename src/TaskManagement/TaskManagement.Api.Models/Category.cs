//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManagement.Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {

        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string DescriptionCategory { get; set; }
    
        public List<Link> Links{ get; set; }
    }
}
