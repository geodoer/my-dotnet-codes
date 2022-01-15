using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant.Services
{
    /// <summary>
    /// 点餐Service
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 点餐：将需要点的菜传入
        /// </summary>
        /// <param name="dishes"></param>
        void PlaceOrder(List<string> dishes);
    }
}
