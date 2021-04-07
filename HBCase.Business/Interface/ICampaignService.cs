
using HBCase.Entity;

namespace HBCase.Business.Interface
{
    public interface ICampaignService
    {
        string Create(Campaign campaign);
        string GetByName(string name);
        string TimeIncrease(string campaignName, int hour);
    }
}
