using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Data.Base;
using KeesingTechnologies.Assignment.Data.EntityFramework.EFConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Data.EntityFramework
{
    public class AssignmentDataContext : DbContext, IUnitOfWork
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // load the configurations 
            modelBuilder.Configurations.Add(new DocumentConfig());
            modelBuilder.Configurations.Add(new ImageConfig());
        }

        IDbSet<TEntity> IUnitOfWork.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        public void RejectChanges()
        {
            throw new NotImplementedException();
        }
    }
}
