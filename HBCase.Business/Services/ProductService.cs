using HBCase.Business.Interface;
using HBCase.Data.Interface;
using HBCase.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBCase.Business.Services
{
    public class ProductService : IProductService
    {
        private IProductData _productData;
        public ProductService(IProductData productData)
        {
            _productData = productData;
        }
        public string Create(Product product)
        {
            var result = _productData.Create(product);
            if (result > 0)
            {
                return string.Format(" Product created; code {0}, price {1}, stock {2}",
                                   product.ProductCode, product.Price, product.Stock);
            }
            return null;
        }

        public string Get(string productCode)
        {
            var result = _productData.GetByCode(productCode);
            if (result == null)
            {
                return string.Format(" Product {0} Not Found", result.ProductCode);
            }
            return string.Format(" Product {0} info;  price {1}, stock {2}",
                                 result.ProductCode, result.Price, result.Stock);
        }
    }
}
