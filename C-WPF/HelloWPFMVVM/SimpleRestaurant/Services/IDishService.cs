using SimpleRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant.Services
{
    /// <summary>
    /// 菜单Service
    /// </summary>
    public interface IDishService
    {
        List<Dish> GetAllDishes();
    }
}
