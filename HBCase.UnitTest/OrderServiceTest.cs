using HBCase.Business.Interface;
using HBCase.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HBCase.UnitTest
{
    [TestClass]
    public class OrderServiceTest
    {
        private IOrderService _orderService;
        public OrderServiceTest(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [TestMethod]
        [Description("Create")]
        public void Should_Create()
        {
            Order order = new Order
            {
                ProdcutCode = "P1",
                Quantity = 2
            };

            var result = _orderService.Create(order);

            Assert.IsNotNull(result);
        }
    }
}
