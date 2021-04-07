using HBCase.Common.DataAccess;
using HBCase.Entity;

namespace HBCase.Data.Interface
{
    public interface ICampaignData : IEntityRepository<Campaign>
    {
        Campaign GetByName(string name);
    }
}
