using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArjavWebProject.Models;

namespace ArjavWebProject.Repositories
{
    public interface IEnquiryStatusRepository
        :IGenericRepository<EnquiryStatus>
    {
        IQueryable<EnquiryStatus> FindAll();
        void Save(EnquiryStatus enquiryStatus);
        EnquiryStatus FindById(int id);
        bool Delete(int id);
    }

    public class EnquiryStatusRepository :
        IEnquiryStatusRepository
    {
        private CRMDbContext db = new CRMDbContext();
        public bool Delete(int id)
        {
            EnquiryStatus status = FindById(id);
            if (status == null)
            {
                return false;
            }
            db.EnquiryStatus.Remove(status);
            db.SaveChanges();
            return true;
        }

        public IQueryable<EnquiryStatus> FindAll()
        {
            return db.EnquiryStatus.AsQueryable();
        }

        public EnquiryStatus FindById(int id)
        {
            return db.EnquiryStatus.Find(id);
        }

        public void Save(EnquiryStatus enquiryStatus)
        {
            if (enquiryStatus.Id == 0)
            {
                db.EnquiryStatus.Add(enquiryStatus);
            }
            else
            {
                db.Entry(enquiryStatus).State =
                    System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}