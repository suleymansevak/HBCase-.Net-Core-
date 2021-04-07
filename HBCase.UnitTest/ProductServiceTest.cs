using HBCase.Business.Interface;
using HBCase.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HBCase.UnitTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private IProductService _productService;
        public ProductServiceTest(IProductService productService)
        {
            _productService = productService;
        }

        [TestMethod]
        [Description("Create")]
        public void Should_Create()
        {
            Product product = new Product
            {
                ProductCode = "P1",
                Price = 50,
                Stock = 100
            };

            var result = _productService.Create(product);

            Assert.IsNotNull(result);
            Assert.Equals(1, result.Count());
        }

        [TestMethod]
        [Description("Get")]
        public void Should_Get()
        {
            var productCode = "P1";

            var result = _productService.Get(productCode);

            Assert.IsNotNull(result);

        }
    }
}
