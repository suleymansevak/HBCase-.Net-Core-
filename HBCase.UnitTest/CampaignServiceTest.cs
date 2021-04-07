using HBCase.Business.Interface;
using HBCase.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HBCase.UnitTest
{
    [TestClass]
    public class CampaignServiceTest
    {
        private ICampaignService _campaignService;
        public CampaignServiceTest(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [TestMethod]
        public void Should_Create()
        {
            Campaign campaign = new Campaign
            {
                ProductCode = "P1",
                Name = "C1",
                Duration = 5,
                PriceManupilationLimit = 20,
                TargetSalesCount = 100,
                Status = true
            };

            var result = _campaignService.Create(campaign);

            Assert.IsNotNull(result);
            Assert.Equals(1, result.Count());
        }

        [TestMethod]
        [Description("GetByName")]
        public void Should_GetByName()
        {
            var name = "C1";

            var result = _campaignService.GetByName(name);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Description("TimeIncrease")]
        public void Should_TimeIncrease()
        {
            string campaignName = "C1";
            int hour = 1;

            var result = _campaignService.TimeIncrease(campaignName, hour);

            Assert.IsNotNull(result);

        }
    }
}
