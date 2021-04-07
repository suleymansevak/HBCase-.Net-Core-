using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBCase.Business.Interface;
using HBCase.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HBCase.API.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("create_order")]
        public IActionResult Create(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var result = _orderService.Create(order);
            return Ok(result);
        }

    }
}