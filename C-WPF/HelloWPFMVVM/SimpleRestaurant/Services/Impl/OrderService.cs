using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant.Services.Impl
{
    public class OrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            //简单输出到文件中，模拟成功下单
            File.WriteAllLines(@"order.txt", dishes.ToArray());
        }
    }
}
