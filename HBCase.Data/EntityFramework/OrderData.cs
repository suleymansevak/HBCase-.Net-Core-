using HBCase.Common.DataAccess;
using HBCase.Data.Interface;
using HBCase.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HBCase.Data.EntityFramework
{
    public class OrderData : EntityRepositoryBase<Order, HBCaseDbContext>, IOrderData
    {
    }
}
