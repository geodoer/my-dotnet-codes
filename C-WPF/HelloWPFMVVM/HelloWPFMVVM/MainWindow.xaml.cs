using HelloWPFMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWPFMVVM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// MainWindow实际上就是一个View
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //关联View与ViewModel
            //将MainWindow的数据上下文设置为MainWindowViewModel
            this.DataContext = new MainWindowViewModel();
        }
    }
}
