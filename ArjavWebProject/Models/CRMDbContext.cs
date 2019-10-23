using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArjavWebProject.Models
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext() : base("ConnString")
        {

        }

        public DbSet<EnquiryStatus>
            EnquiryStatus { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }

    }
};