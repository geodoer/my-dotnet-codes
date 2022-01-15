using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HelloWPFMVVM.ViewModels
{
    /// <summary>
    /// 具有通知能力的对象（ViewModel的基类）
    /// </summary>
    class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性变换事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if(this.PropertyChanged!=null)
            {
                ///告诉Binding，哪个属性改变了
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
