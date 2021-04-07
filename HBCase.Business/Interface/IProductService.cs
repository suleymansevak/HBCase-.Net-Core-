
using HBCase.Entity;

namespace HBCase.Business.Interface
{
    public interface IProductService
    {
        string Get(string productCode);
        string Create(Product product);
    }
}
