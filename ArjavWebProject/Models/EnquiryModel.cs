using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArjavWebProject.Models
{
    public class Enquiry
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime EnquiryDate { get; set; }
        public EnquiryStatus EnquiryStatus { get; set; }
        public int EnquiryStatusId { get; set; }
    }

    public class EnquiryStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}