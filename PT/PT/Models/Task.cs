//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<double> Progress { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Type { get; set; }
    }
}
