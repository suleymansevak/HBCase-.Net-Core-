using HBCase.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HBCase.Common.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> entity);
        int Create(T entity);
        int Update(T entity);
    }
}
