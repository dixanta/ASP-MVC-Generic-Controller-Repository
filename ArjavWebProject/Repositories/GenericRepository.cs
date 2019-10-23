using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArjavWebProject.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity:class
    {
        IQueryable<TEntity> FindAll();
        void Save(TEntity model);
        TEntity FindById(int id);
        bool Delete(int id);
    }
}