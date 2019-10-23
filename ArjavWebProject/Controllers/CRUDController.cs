using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArjavWebProject.Repositories;

namespace ArjavWebProject.Controllers
{
    public abstract class CRUDController<TRepository, TEntity>
        : Controller
        where TRepository:IGenericRepository<TEntity>,new()
        where TEntity:class
    {
        protected IGenericRepository<TEntity> repository;
        public CRUDController()
        {
            repository = new TRepository();
        }

        // GET: CRUD
        public ActionResult Index()
        {
            return View(repository.FindAll());
        }
    }
}