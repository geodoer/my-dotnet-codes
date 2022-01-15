﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant.Models
{
    /// <summary>
    /// 菜品
    /// </summary>
    public class Dish
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public double Score { get; set; }
    }
}
