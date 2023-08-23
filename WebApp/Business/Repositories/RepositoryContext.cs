using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Configuration;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using EntityState = System.Data.Entity.EntityState;

namespace WebApp
{
    public class RepositoryContext<TEntity> : IRepositoryContext<TEntity>
        where TEntity : class
    {
        private readonly DbContext _dataContext;

        private IDbSet<TEntity> Dbset
        {
            get { return _dataContext.Set<TEntity>(); }
        }

        public RepositoryContext(DbContext dbContext)
        {
            _dataContext = dbContext;
        }

        public List<TEntity> GetAll()
        {
            try
            {
                var statement =
                Dbset.Distinct(); 
                return statement.ToList();
            }
            catch (Exception ex) {
                return null;
            }
            
        }

        public TEntity GetById(int id)
        {
            return Dbset.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Dbset.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        //public void Delete(int id)
        //{
        //    var entity = GetById(id);
        //    if (entity == null)
        //        throw new ObjectNotFoundException("entity");
        //    Dbset.Remove(entity);
        //}
        
    }
}