using SimpleRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestaurant.ViewModels
{
    /// <summary>
    /// View中单个菜品的建模结果
    /// </summary>
    public class DishMenuItemViewModel : NotificationObject
    {
        //菜品
        public Dish dish { get; set; }

        //此菜品是否被选中
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }
    }
}
