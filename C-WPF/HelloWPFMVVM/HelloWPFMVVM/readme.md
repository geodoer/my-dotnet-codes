[toc]

# WPF MVVM的HelloWorld



## MVVM

MVVM是一种设计模式，而WPF只是一个GUI框架，WPF并没有MVVM的组件。但是WPF提供相应的基础组件，能够让我们很方便的实现MVVM设计模式



实现MVVM设计模式，需要涉及到以下内容

1. WPF的数据绑定

2. System.ComponentModel.INotifyPropertyChanged

3. System.Windows.Input.Command



### INotifyPropertyChanged

当属性值更改时，会触发`System.ComponentModel.INotifyPropertyChanged.PropertyChanged`事件

```C#
namespace System.ComponentModel
{
    // 摘要:通知客户端属性值已更改。
    public interface INotifyPropertyChanged
    {
        // 摘要: 在属性值更改时发生。
        event PropertyChangedEventHandler PropertyChanged;
    }
}
```

因此，我们可以继承此接口，定义一个具有通知能力的基类

```C#
    class NotificationObject : INotifyPropertyChanged
    {
        /// 属性更改事件
        public event PropertyChangedEventHandler PropertyChanged;

        /// 触发属性更改的事件
        public void RaisePropertyChanged(string propertyName)
        {
            if(this.PropertyChanged!=null)
            {
                //如果绑定了属性更改的事件，则调用相关处理函数
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
```

此基类将被ViewModel相关类继承，当ViewModel的属性变换时，就会调用`NotificationObject::RaisePropertyChanged`函数，触发属性更改的事件

```C#
 class MainWindowViewModel : NotificationObject
 {
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
}
```

那界面中的UI元素怎么订阅这些事件呢？

- 如果你使用WPF的Data Binding，它自动会帮你订阅属性的更改



### DelegateCommand



## 此项目介绍





## MVVM的优势

优势

1. 前后分开，换一个界面之后，还是可以编译成功的
2. 开闭原则：欢迎客户改变界面，但是后台代码却关闭了修改



比如这两份UI，只要更换xaml的代码即可，不需要改业务层的代码



```xml
<Window x:Class="HelloWPFMVVM.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <Button Content="Save" Command="{Binding SaveCommand}"/>
        <Grid Grid.Row="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>

            <TextBox x:Name="tb1" Grid.Row="0" Background="LightBlue" FontSize="24" Margin="4" Text="{Binding Input1}" />
            <TextBox x:Name="tb2" Grid.Row="1" Background="LightBlue" FontSize="24" Margin="4" Text="{Binding Input2}" />
            <TextBox x:Name="tb3" Grid.Row="2" Background="LightBlue" FontSize="24" Margin="4" Text="{Binding Result}" />
            <Button x:Name="addButton" Grid.Row="3" Content="Add" Width="120" Height="80" Command="{Binding AddCommand}"/>
        </Grid>
    </Grid>
</Window>
```



```xml
<Window x:Class="HelloWPFMVVM.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <Menu>
            <MenuItem Header="_File">
            	<MenuItem Header="_Save" Command="{Binding SaveCommand}"/>
            </MenuItem>
        </Menu>
            
        <Grid Grid.Row="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>

            <Slider x:Name="slider1" Grid.Row="0" Background="LightBlue" FontSize="24" Margin="4" Value="{Binding Input1}" />
            <Slider x:Name="slider2" Grid.Row="1" Background="LightBlue" FontSize="24" Margin="4" Value="{Binding Input2}" />
            <Slider x:Name="slider3" Grid.Row="2" Background="LightBlue" FontSize="24" Margin="4" Value="{Binding Result}" />
            <Button x:Name="addButton" Grid.Row="3" Content="Add" Width="120" Height="80" Command="{Binding AddCommand}"/>
        </Grid>
    </Grid>
</Window>
```

