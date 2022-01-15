using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SimpleRestaurant.Models;

namespace SimpleRestaurant.Services.Impl
{
    /// <summary>
    /// XML的DishServer
    /// （从XML获取数据）
    /// </summary>
    public class XmlDishService : IDishService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishLIst = new List<Dish>();
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Dishs.xml");
            XDocument xDoc = XDocument.Load(xmlFileName);
            var dishes = xDoc.Descendants("Dish");
            foreach (var d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
                dishLIst.Add(dish);
            }

            return dishLIst;
        }
    }
}
