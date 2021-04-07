using HBCase.Common.DataAccess;
using HBCase.Entity;

namespace HBCase.Data.Interface
{
    public interface IProductData : IEntityRepository<Product>
    {
        Product GetByCode(string productCode);
    }
}
