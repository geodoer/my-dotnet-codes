using HelloWPFMVVM.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPFMVVM.ViewModels
{
    /// <summary>
    /// MainWindow即是一个View
    /// 此ViewModel即是对MainWindow建模的结果
    /// </summary>
    class MainWindowViewModel : NotificationObject
    {
        /// <summary>
        /// MainWindow中有三个数据属性
        /// </summary>
        #region 数据属性
        private double number1;

        public double Number1
        {
            get { return number1; }
            set
            {
                number1 = value;
                //Input1更改了，触发通知
                this.RaisePropertyChanged("Input1");
            }
        }

        private double number2;

        public double Number2
        {
            get { return number2; }
            set
            {
                number2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                this.RaisePropertyChanged("Result");
            }
        }
        #endregion

        /// <summary>
        /// MainWindow中有两个个命令
        /// 1. 点击Add之后，对Input1与Input2进行相加
        /// 2. 点击Save之后，对相加结果进行保存
        /// </summary>
        #region 命令属性
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        private void Add(object parameter)
        {
            this.Result = this.Number1 + this.Number2;
            //相加之后，会调用Result.Set方法，从而触发Result修改的事件 
        }

        private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }
        #endregion

        public MainWindowViewModel()
        {
            //将AddCommand与Add关联起来
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);

            this.SaveCommand = new DelegateCommand();
            this.SaveCommand.ExecuteAction = new Action<object>(this.Save);
        }
    }
}
