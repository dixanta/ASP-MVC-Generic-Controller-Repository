using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArjavWebProject.Controllers;
using ArjavWebProject.Models;
using ArjavWebProject.Repositories;
using PagedList;

namespace ArjavWebProject.Areas.Admin.Controllers
{
    public class EnquiryStatusController : 
        CRUDController<EnquiryStatusRepository,EnquiryStatus>
    {
        
        // GET: Admin/EnquiryStatus
        /* ActionResult Index(string by = "id", 
            string order = "asc",int page=1)

        {

            IQueryable<EnquiryStatus> query =
                repository.FindAll();
            query=Sort(query, by, order);
            return View(query.ToPagedList(page,2));
        }*/

        private IQueryable<EnquiryStatus> Sort(IQueryable<EnquiryStatus> query,string by, string order)
        {
            switch (by)
            {
                case "id":
                    query = (order.ToLower().Equals("asc")) ?
                        query.OrderBy(m => m.Id) :
                        query.OrderByDescending(m => m.Id);
                    break;
                case "name":
                    query = (order.ToLower().Equals("asc")) ?
                        query.OrderBy(m => m.Name) :
                        query.OrderByDescending(m => m.Name);
                    break;
                case "color":
                    query = (order.ToLower().Equals("asc")) ?
                        query.OrderBy(m => m.Color) :
                        query.OrderByDescending(m => m.Color);
                    break;
                case "created":
                    query = (order.ToLower().Equals("asc")) ?
                        query.OrderBy(m => m.CreatedDate) :
                        query.OrderByDescending(m => m.CreatedDate);
                    break;

            }
            return query;

        }

        public PartialViewResult Table()
        {
            IQueryable<EnquiryStatus> status =
                repository.FindAll();
            status = status.OrderByDescending(m => m.Id);
            return PartialView(status.ToList());
        }

        // GET: Admin/EnquiryStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryStatus enquiryStatus = repository.FindById((int)id);
            if (enquiryStatus == null)
            {
                return HttpNotFound();
            }
            return View(enquiryStatus);
        }

        // GET: Admin/EnquiryStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EnquiryStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Color")] EnquiryStatus enquiryStatus)
        {
            if (ModelState.IsValid)
            {
                enquiryStatus.CreatedDate = DateTime.Now;
                repository.Save(enquiryStatus);
                return RedirectToAction("Index");
            }

            return View(enquiryStatus);
        }

        // GET: Admin/EnquiryStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryStatus enquiryStatus =
                repository.FindById((int)id);
            if (enquiryStatus == null)
            {
                return HttpNotFound();
            }
            return View(enquiryStatus);
        }

        // POST: Admin/EnquiryStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Color,CreatedDate")] 
        EnquiryStatus enquiryStatus)
        {
            if (ModelState.IsValid)
            {
                //Fetch from db the selected record
                EnquiryStatus status = 
                    repository.FindById(enquiryStatus.Id);

                status.Name = enquiryStatus.Name;
                status.Color = enquiryStatus.Color;

                repository.Save(status);
                return RedirectToAction("Index");
            }
            return View(enquiryStatus);
        }

        // GET: Admin/EnquiryStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryStatus enquiryStatus =
                repository.FindById((int)id);
            if (enquiryStatus == null)
            {
                return HttpNotFound();
            }
            return View(enquiryStatus);
        }

        // POST: Admin/EnquiryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
