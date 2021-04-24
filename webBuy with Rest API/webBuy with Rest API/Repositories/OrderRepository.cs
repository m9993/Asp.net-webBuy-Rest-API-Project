﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webBuy_with_Rest_API.Models;

namespace webBuy_with_Rest_API.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public List<Order> GetOrdersListByDate(string date)
        {
            /*return this.context.Orders.Where(i => i.date.Contains("12-Mar-21")).Count();*/
            return this.context.Orders.Where(s => s.date.Contains(date)).ToList();
        }
    }
}