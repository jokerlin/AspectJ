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
	/// pointCutAndAdviceChoose.xaml 的交互逻辑
	/// </summary>
	public partial class pointCutAndAdviceChoose : Window
	{
        ObservableCollection<PointCutInfo> pointCutList=new ObservableCollection<PointCutInfo>();
        ObservableCollection<AdviceInfo> adviceList = new ObservableCollection<AdviceInfo>();
        public pointCutAndAdviceChoose()
		{
			this.InitializeComponent();
            pointCutList.Clear();
            this.pointCutComboBox.ItemsSource = pointCutList;
            this.pointCutComboBox.DisplayMemberPath = "Name";
            this.pointCutComboBox.SelectedValuePath = "ID";

            this.adviceComboBox.ItemsSource = adviceList;
            this.adviceComboBox.DisplayMemberPath = "Name";
            this.adviceComboBox.SelectedValuePath = "ID";
            
            updata();
            updataAdvice();
            // pointCuts.Clear();
            //this.pointCutComboBox.
            //pointCutList.Add(pc);
            

			// 在此点之下插入创建对象所需的代码。
		}

        public void updata()
        {
            pointCutList.Clear();
            List<Pointcut> List = new List<Pointcut>();
            List = Pointcuts.pointcuts;
            for (int i = 0; i < List.Count; i++)
            {
                PointCutInfo pc = new PointCutInfo(); 
                pc.ID = i;
                pc.Name = List[i].pointcutName;
                pointCutList.Add(pc);
            }
        }

        public void updataAdvice()
        {
            adviceList.Clear();
            List<Advice> List = new List<Advice>();
            List = Advices.advices;
            for (int i = 0; i < List.Count; i++)
            {
                AdviceInfo ad = new AdviceInfo();
                ad.ID = i;
                ad.Name = List[i].adviceName;
                adviceList.Add(ad);
            }
        }
        

		

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pointCutComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = pointCutComboBox.SelectedIndex;
            if (index == -1) return;
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run(Pointcuts.getCode(index));
            p.Inlines.Add(r);
            doc.Blocks.Add(p);
            pointCutRichTextBox.Document = doc;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = pointCutComboBox.SelectedIndex;
            if (index == -1) return;
            Pointcuts.delPointcutByIndex(index);
            updata();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int index = pointCutComboBox.SelectedIndex;
            if (index == -1) return;
            addPoint ap = new addPoint();
            ap.Owner = this;
            
            Pointcut pointcut = new Pointcut();
            pointcut = Pointcuts.pointcuts[index];

            ap.pointCutTextBox.Text = pointcut.pointcutName;
            switch (pointcut.returnValue)
            {
                case "public": ap.returnValueCombox.SelectedIndex = 0;
                    break;
                case "private": ap.returnValueCombox.SelectedIndex = 1;
                    break;
            }
            switch (pointcut.pointcutKind)
            {
                case "Call": ap.pointCutKindCombox.SelectedIndex = 0;
                    break;
                case "Execution": ap.pointCutKindCombox.SelectedIndex = 1;
                    break;
                case "Target": ap.pointCutKindCombox.SelectedIndex = 2;
                    break;
                case "Args": ap.pointCutKindCombox.SelectedIndex = 3;
                    break;
                case "Within": ap.pointCutKindCombox.SelectedIndex = 4;
                    break;
                case "Cflow": ap.pointCutKindCombox.SelectedIndex = 5;
                    break;
            }
            ap.regexBox.Text = pointcut.regex;
            ap.Label.Content = "编辑 pointCut";
            ap.index = index;
            ap.ShowDialog();
            updata();
        }

        private void addButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            addPoint ap = new addPoint();
            ap.Owner = this;
            ap.ShowDialog();// 在此处添加事件处理程序实现。
            updata();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();// 在此处添加事件处理程序实现。
        }

        private void adviceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = adviceComboBox.SelectedIndex;
            if (index == -1) return;
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run(Advices.advices[index].adviceString);
            p.Inlines.Add(r);
            doc.Blocks.Add(p);
            adviceRichTextBox.Document = doc;
        }

        private void addButton1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            addAdvice aa = new addAdvice();
            aa.Owner = this;
            aa.ShowDialog();// 在此处添加事件处理程序实现。
            updataAdvice();
        }

        private void editButton1_Click(object sender, RoutedEventArgs e)
        {
            int index = adviceComboBox.SelectedIndex;
            if (index == -1) return;
            addAdvice aa = new addAdvice();
            aa.Owner = this;
            aa.index = index;

            Advice ad = new Advice();
            ad = Advices.getAdvices(index);
            int i;
            for (i = 0; i < Pointcuts.pointcuts.Count; i++)
            {
                if (Pointcuts.pointcuts[i].pointcutName == ad.advicePointcutName)
                {
                    break;
                }
            }
            if (i < Pointcuts.pointcuts.Count) aa.pointCutComboBox.SelectedIndex = i;
            if (ad.advicePointcutKind == "before") 
                aa.kindComboBox.SelectedIndex = 0;
            else
                aa.kindComboBox.SelectedIndex = 1;

            aa.textBox.Text = ad.adviceCode;

            aa.ShowDialog();
            updataAdvice();

        }

        private void deleteButton1_Click(object sender, RoutedEventArgs e)
        {
            int index = adviceComboBox.SelectedIndex;
            if (index == -1) return;
            Advices.delAdviceByIndex(index);
            updataAdvice();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            AspectGeneration.GenerateAspectCode(Pointcuts.pointcuts, Advices.advices, nameTextBox.Text);
            GenerateAJFile.generateAJFile();
            MessageBox.Show("aspectJ代码自动生成成功");
        }
        
	}

    public class PointCutInfo 
    {
        public int ID
        {
            get; 
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class AdviceInfo
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
    
}