using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBCase.Business.Interface;
using HBCase.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HBCase.API.Controllers
{
    [Produces("application/json")]
    public class CampaignController : Controller
    {
        private ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        //string productCode, int duration, int pmLimit, int targetSalesCount
        [HttpPost("create_campaign")]
        public IActionResult Create(Campaign campaign)
        {
            if (campaign == null)
            {
                return BadRequest();
            }
            var result = _campaignService.Create(campaign);

            return Ok(result);
        }

        [HttpGet("get_campaign_info")]
        public IActionResult Get(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var result = _campaignService.GetByName(name);
            return Ok(result);
        }

        [HttpPost("increase_time")]
        public IActionResult TimeIncrease(string campaignName, int hour)
        {
            if (hour <= 0)
            {
                return BadRequest();
            }
            var result = _campaignService.TimeIncrease(campaignName, hour);

            return Ok(result);
        }
    }
}