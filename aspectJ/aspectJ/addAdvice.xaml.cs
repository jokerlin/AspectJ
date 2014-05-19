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
using System.Collections.ObjectModel;

namespace aspectJ
{
	/// <summary>
	/// addAdvice.xaml 的交互逻辑
	/// </summary>
	public partial class addAdvice : Window
	{
        ObservableCollection<PointCutInfo> pointCutList = new ObservableCollection<PointCutInfo>();
        public addAdvice()
		{
			this.InitializeComponent();
            pointCutList.Clear();
            this.pointCutComboBox.ItemsSource = pointCutList;
            this.pointCutComboBox.DisplayMemberPath = "Name";
            this.pointCutComboBox.SelectedValuePath = "ID";


            List<Pointcut> List = new List<Pointcut>();
            List = Pointcuts.pointcuts;
            for (int i = 0; i < List.Count; i++)
            {
                PointCutInfo pc = new PointCutInfo(); ;
                pc.ID = i;
                pc.Name = List[i].pointcutName;
                pointCutList.Add(pc);
            }
			// 在此点之下插入创建对象所需的代码。
		}

		private void cancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();// 在此处添加事件处理程序实现。
		}

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            PointCutInfo pccb = new PointCutInfo();
            pccb = (PointCutInfo)pointCutComboBox.SelectedItem;
            ComboBoxItem kcb = new ComboBoxItem();
            kcb = (ComboBoxItem)kindComboBox.SelectedItem;
            string code = textBox.Text;
            //string code = System.Windows.Markup.XamlWriter.Save(richTextBox.Document);
            Advices.AddAdvice(kcb.Content.ToString(), pccb.Name, code);
            this.Close();
        }
	}
}