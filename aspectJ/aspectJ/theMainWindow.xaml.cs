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
	/// <summary>
	/// theMainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class theMainWindow : Window
	{
        public CodeManager codemanager;
		public theMainWindow()
		{
			this.InitializeComponent();
            codemanager = new CodeManager();
			// 在此点之下插入创建对象所需的代码。
		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            codeWindow cw = new codeWindow();
            cw.Owner = this;
            cw.ShowDialog();
        }

        private void functionDropButton_Click(object sender, RoutedEventArgs e)
        {
            treeGraph tg = new treeGraph();
      
            tg.Show();
            this.Close(); 
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();// 在此处添加事件处理程序实现。
        }
	}
}