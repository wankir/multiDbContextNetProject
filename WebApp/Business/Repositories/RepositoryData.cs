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
using System.Data.Entity.Infrastructure;
using Entity;

namespace WebApp
{
    public class RepositoryData : RepositoryContext<Transactions>
    {
        public RepositoryData(DbContext dbContext)
        : base(dbContext)
        {
        }

        public List<Transactions> GetActive()
        {
            //.Where(c => c.Flag == true)
            var entities = GetAll();

            return entities;
        }

        public Transactions GetByIdData(int id)
        {
            var entity = GetById(id);
            return entity;
        }

        public void InsertData(Transactions item)
        {
            try
            {
                Insert(item);
                //return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateData(int id, Transactions item)
        {
            try
            {
                Update(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                //return _dbContext.Entry(item).Entity;
            }

            //private bool RecordExists(int id)
            //{
            //    return _dbContext.TransactionData.Any(m => Convert.ToInt32(m.Id) == id);
            //}
        }
    }
}