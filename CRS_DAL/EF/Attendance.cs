//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRS_DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public string AttendanceID { get; set; }
        public string ClassID { get; set; }
        public string ParticipantID { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> AttendanceDate { get; set; }
        public string Remark { get; set; }
    }
}
