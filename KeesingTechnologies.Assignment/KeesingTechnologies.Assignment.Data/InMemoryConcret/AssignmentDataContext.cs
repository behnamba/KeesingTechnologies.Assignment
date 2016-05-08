using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Data.InMemoryConcret
{
    public class AssignmentDataContext : IUnitOfWork
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Image> Images { get; set; }

        IDbSet<TEntity> IUnitOfWork.Set<TEntity>()
        {
            if (typeof(TEntity) == typeof(Document))
            {
                var list = new FakeDbSet<Document>();
                return (IDbSet<TEntity>)list;
            }

            throw new NotImplementedException();
        }

        public void RejectChanges()
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
