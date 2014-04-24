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
	/// elementBox.xaml 的交互逻辑
	/// </summary>
	public partial class elementBox : Window
	{

        private SolidColorBrush nameBrush = new SolidColorBrush(Color.FromRgb(51,153,255));
        private SolidColorBrush elementBrush = new SolidColorBrush(Color.FromRgb(150, 203, 255));
        private int position;
        private TreeControl tc;
        private ScrollViewer scrollViewer;

        public elementBox(int _position,TreeControl _tc, ref ScrollViewer _scrollViewer)
		{
			this.InitializeComponent();
            position = _position;
            tc = _tc;
            scrollViewer = _scrollViewer;
			// 在此点之下插入创建对象所需的代码。
		}

		private void button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();// 在此处添加事件处理程序实现。
		}

		private void TextBlock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
   			{
    			this.DragMove();
   			}// 在此处添加事件处理程序实现。
		}

 
        public void setText(String className, String functionName)
        {
            FlowDocument doc = new FlowDocument();
            Paragraph paragraph;
            Run run;

            paragraph = new Paragraph();
            run = new Run("类名 ");
            run.Foreground = nameBrush;
            paragraph.Inlines.Add(run);
            run = new Run(className);
            run.Foreground = Brushes.White;
            paragraph.Inlines.Add(run);
            doc.Blocks.Add(paragraph);

            paragraph = new Paragraph();
            run = new Run("函数名 ");
            run.Foreground = nameBrush;
            paragraph.Inlines.Add(run);
            run = new Run(functionName);
            run.Foreground = Brushes.White;
            paragraph.Inlines.Add(run);
            doc.Blocks.Add(paragraph);

            paragraph = new Paragraph();
            run = new Run("参数列表");
            run.Foreground = nameBrush;
            paragraph.Inlines.Add(run);
            doc.Blocks.Add(paragraph);

            paragraph = new Paragraph();
            run = new Run("topLeftPointCorner ");
            run.Foreground = elementBrush;
            paragraph.Inlines.Add(run);
            run = new Run("(100, 200)");
            run.Foreground = Brushes.White;
            paragraph.Inlines.Add(run);
            doc.Blocks.Add(paragraph);

            paragraph = new Paragraph();
            run = new Run("width ");
            run.Foreground = elementBrush;
            paragraph.Inlines.Add(run);
            run = new Run("100");
            run.Foreground = Brushes.White;
            paragraph.Inlines.Add(run);
            doc.Blocks.Add(paragraph);

            paragraph = new Paragraph();
            run = new Run("height ");
            run.Foreground = elementBrush;
            paragraph.Inlines.Add(run);
            run = new Run("50");
            run.Foreground = Brushes.White;
            paragraph.Inlines.Add(run);
            doc.Blocks.Add(paragraph);
           // 参数列表
           //topLeftPoint Corner (100,200)
           //width 100
            //height 50
            richTextBox.Document = doc;
        }



        private void button2_Click(object sender, RoutedEventArgs e)
        {
            tc.BranchHidden(position, false, ref scrollViewer);
            this.Close();
            // 在此处添加事件处理程序实现。仅显示该分支
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tc.BranchHidden(position, true, ref scrollViewer);
            this.Close();
            // 在此处添加事件处理程序实现。仅显示该函数分支
        }

	}
}