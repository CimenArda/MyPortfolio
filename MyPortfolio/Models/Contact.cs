//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPortfolio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<int> CategoryID { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
