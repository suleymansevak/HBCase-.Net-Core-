using HBCase.Common.Entities;
using System;

namespace HBCase.Entity
{
    public class Campaign : IEntity
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManupilationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public bool Status { get; set; }
        public int TotalSales { get; set; }
        public DateTime Time { get; set; }
    }
}
