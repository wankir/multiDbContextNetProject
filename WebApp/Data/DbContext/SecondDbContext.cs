using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entity;
using System.Configuration;

namespace WebApp
{
    public class SecondDbContext : DbContext
    {
        public SecondDbContext() : base(ConfigurationManager.AppSettings["AzDatabase"])
        {
            
        }

        public IDbSet<Transactions> TransactionData { get; set; }
        //public IDbSet<Detail> Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}