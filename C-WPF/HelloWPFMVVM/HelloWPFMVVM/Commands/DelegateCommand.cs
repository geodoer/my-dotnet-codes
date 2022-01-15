using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloWPFMVVM.Commands
{
    /// <summary>
    /// 委托命令
    /// 将ICommand中的函数，通过委托的方式，暴露出来，方便外界使用
    /// https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.input.icommand?view=net-6.0
    /// </summary>
    class DelegateCommand : ICommand
    {
        /// <summary>
        /// CanExecute状态发生改变时，调用此处理者
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 帮助命令的呼叫者，判断命令是否能执行
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if(this.CanExecuteFunc==null)
            {
                return true;
            }

            return this.CanExecuteFunc(parameter);
        }

        /// <summary>
        /// 命令执行时，所调用的函数
        /// </summary>
        public void Execute(object parameter)
        {
            if(this.ExecuteAction==null)
            {
                return;
            }

            this.ExecuteAction(parameter);
        }

        public Action<object> ExecuteAction { get; set; }
        public Func<object, bool> CanExecuteFunc { get; set; }
    }
}
