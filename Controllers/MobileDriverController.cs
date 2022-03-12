using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Takke.Models;
using Microsoft.Extensions.Configuration;


namespace Takke.Controllers
{
    public class MobileDriverController : Controller
    {

        TakkeContext context;
        private IConfiguration _config;

        public MobileDriverController(TakkeContext _context, IConfiguration config)
        {
            context = _context;
            _config = config;
        }


        public IActionResult acceptOrder(int orderid) {
            Order order = context.Orders.Where(m => m.OrderId==orderid).First();
            order.Status = "1";
            context.Orders.Update(order);
            context.SaveChanges();
            order.Client = null;
            order.Driver = null;
            order.OrderTypeNavigation = null;
            return Ok(new { order = order });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
