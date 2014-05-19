using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace aspectJ
{
	/// <summary>a
	/// addPoint.xaml 的交互逻辑
	/// </summary>
	public partial class addPoint : Window
	{
        pointCutAndAdviceChoose parent;
        public int index = -1;
        public addPoint()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        public void setParent(pointCutAndAdviceChoose _parent)
        {
            parent = _parent;
        }

		private void cancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();// 在此处添加事件处理程序实现。
		}

		private void acceptButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
           
            ComboBoxItem rvcb = new ComboBoxItem();
            rvcb = (ComboBoxItem)returnValueCombox.SelectedItem;
            ComboBoxItem pckc = new ComboBoxItem();
            pckc = (ComboBoxItem)pointCutKindCombox.SelectedItem;
            if (index == -1)
                Pointcuts.AddPointcut(rvcb.Content.ToString(), pointCutTextBox.Text, pckc.Content.ToString(), regexBox.Text);
            else
            {
                Pointcuts.EditPointcut(index,rvcb.Content.ToString(), pointCutTextBox.Text, pckc.Content.ToString(), regexBox.Text);
            }
            this.Close();
            //Pointcuts.pointcuts
            //regexBox.Text = cb.Content.ToString();    
               // 在此处添加事件处理程序实现。
		}
	}
}