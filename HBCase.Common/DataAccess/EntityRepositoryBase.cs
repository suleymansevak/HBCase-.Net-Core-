using HBCase.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HBCase.Common.DataAccess
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public int Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                var result = context.SaveChanges();
                return result;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> entity)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(entity);
            }
        }
        public int Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
                return 1;
            }
        }

    }
}
