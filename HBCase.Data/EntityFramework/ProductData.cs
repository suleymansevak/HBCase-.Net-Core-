using HBCase.Common.DataAccess;
using HBCase.Data.Interface;
using HBCase.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HBCase.Data.EntityFramework
{
    public class ProductData : EntityRepositoryBase<Product, HBCaseDbContext>, IProductData
    {
        public Product GetByCode(string productCode)
        {
            var result = Get(x => x.ProductCode == productCode);
            return result;
        }
    }
}
