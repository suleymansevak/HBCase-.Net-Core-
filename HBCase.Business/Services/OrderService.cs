using HBCase.Business.Interface;
using HBCase.Data.EntityFramework;
using HBCase.Data.Interface;
using HBCase.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBCase.Business.Services
{
    public class OrderService : IOrderService
    {
        private IOrderData _orderData;
        private IProductData _productData;
        private ICampaignData _campaignData;
        public OrderService(IOrderData orderData, IProductData productData, ICampaignData campaignData)
        {
            _orderData = orderData;
            _productData = productData;
            _campaignData = campaignData;
        }
        public string Create(Order order)
        {
            var product = ReduceProductStock(order.ProdcutCode, order.Quantity); //Reduce product stock as order quantity
            if (product == null)
            {
                return null;
            }

            order.Price = product.Price;
            order.TotalPrice = order.Price * order.Quantity;

            var result = _orderData.Create(order);
            if (result > 0)
            {
                var campaign = _campaignData.Get(x => x.ProductCode == order.ProdcutCode && x.Status == true);
                if (campaign != null)
                {
                    campaign.TotalSales += order.Quantity; //Add quantity to Campaign TotalSales 
                    if (campaign.TargetSalesCount == campaign.TotalSales)
                    {
                        campaign.Status = false;
                    }
                    _campaignData.Update(campaign);
                }

                return string.Format(" Order created; product {0}, quantity {1}", order.ProdcutCode, order.Quantity);
            }

            return null;
        }
        private Product ReduceProductStock(string productCode, int quantity)
        {
            var product = _productData.GetByCode(productCode);
            if (product != null)
            {
                product.Stock -= quantity;
                _productData.Update(product);
            }
            return product;
        }
    }
}
