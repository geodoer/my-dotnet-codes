using SimpleRestaurant.Commands;
using SimpleRestaurant.Models;
using SimpleRestaurant.Services;
using SimpleRestaurant.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleRestaurant.ViewModels
{
    public class MainWindowViewModel : NotificationObject
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        /// <summary>
        /// 已选菜品的总个数
        /// </summary>
        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }

        /// <summary>
        /// 商店信息
        /// </summary>
        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.RaisePropertyChanged("Restaurant");
            }
        }

        /// <summary>
        /// 菜单
        /// </summary>
        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChanged("DishMenu");
            }
        }

        public MainWindowViewModel()
        {
            //加载商店信息
            this.LoadRestaurant();
            //加载菜单
            this.LoadDishMenu();
            //命令注册
            this.PlaceOrderCommand = new DelegateCommand();
            this.PlaceOrderCommand.ExecuteAction = new Action<object>(this.PlaceOrderCommandExecute);
            this.SelectMenuItemCommand = new DelegateCommand();
            this.SelectMenuItemCommand.ExecuteAction = new Action<object>(this.SelectMenuItemExecute);
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Crazy大象";
            this.Restaurant.Address = "北京市海淀区万泉河路紫金庄园1号楼11室";
            this.Restaurant.PhoneNumber = "15210365423 or 82650336";
        }

        private void LoadDishMenu()
        {
            XmlDishService xmlData = new XmlDishService();
            var dishes = xmlData.GetAllDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel dishMenuModel = new DishMenuItemViewModel()
                {
                    dish = dish
                };
                DishMenu.Add(dishMenuModel);
            }
        }

        private void PlaceOrderCommandExecute(object parameter)
        {
            var selectDishes = this.DishMenu.Where(p => p.IsSelected == true).Select(p => p.dish.Name).ToList();
            IOrderService orderService = new OrderService();
            orderService.PlaceOrder(selectDishes);
            MessageBox.Show("订餐成功!");
        }

        private void SelectMenuItemExecute(object parameter)
        {
            this.Count = this.DishMenu.Count(p => p.IsSelected == true);
        }
    }
}
