using HBCase.Business.Interface;
using HBCase.Data.Interface;
using HBCase.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBCase.Business.Services
{
    public class CampaignService : ICampaignService
    {
        private ICampaignData _campaignData;
        private IProductData _productData;
        public CampaignService(ICampaignData campaignData, IProductData productData)
        {
            _campaignData = campaignData;
            _productData = productData;
        }
        public string Create(Campaign campaign)
        {
            var result = _campaignData.Create(campaign);
            if (result > 0)
            {
                return string.Format("Campaign created; name {0}, product {1}, duration {2},limit {3}, target sales count {4}",
                    campaign.Name, campaign.ProductCode, campaign.Duration, campaign.PriceManupilationLimit, campaign.TargetSalesCount);
            }
            return null;
        }

        public string GetByName(string name)
        {
            var result = _campaignData.GetByName(name);
            if (result == null)
            {
                return string.Format(" Campaign {0} Not Found", result.Name);
            }
            return string.Format(" Campaign {0} info;  Status {1}, Target Sales {2},Total Sales {3}",
                                 result.Name, result.Status, result.TargetSalesCount, result.TotalSales);
        }

        public string TimeIncrease(string campaignName, int hour)
        {
            string newTime;
            var campaign = _campaignData.GetByName(campaignName);
            if (campaign.Status)
            {
                newTime = campaign.Time.AddHours(hour).ToShortTimeString();
                campaign.Time = Convert.ToDateTime(newTime);
                _campaignData.Update(campaign);
                ReduceProductPrice(campaign.ProductCode, hour, campaign.Duration, campaign.PriceManupilationLimit);
            }
            else
            {
                return string.Format("Campaign {0} could not found ", campaign.Name);
            }
            return string.Format("Time is {0}", newTime);

        }

        private void ReduceProductPrice(string productCode, int hour, int duration, int limit)
        {
            var product = _productData.Get(x => x.ProductCode == productCode);
            if (product.Price >= product.CurrentPrice + limit)
            {
                product.CurrentPrice = product.Price;
            }
            else
            {
                product.CurrentPrice -= hour * duration;
            }
            _productData.Update(product);

        }
    }
}
