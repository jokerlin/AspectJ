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
	/// codeWindow.xaml 的交互逻辑
	/// </summary>
	public partial class codeWindow : Window
	{
        RichTextBox outRichTextBox;
        CodeEditor codeEditor;
        

        public codeWindow()
		{
			this.InitializeComponent();	
			// 在此点之下插入创建对象所需的代码。
		}

		private void button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();// 在此处添加事件处理程序实现。
		}

		private void acceptButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            codeEditor.AppendCode(textRange.Text);
            outRichTextBox.AppendText(textRange.Text);
            this.Close();// 在此处添加事件处理程序实现。
		}

		private void cancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();// 在此处添加事件处理程序实现。
		}
        public void set(ref RichTextBox _richTextBox, ref CodeEditor _codeEditor)
        {
            outRichTextBox = _richTextBox;
            codeEditor = _codeEditor;
        }
	}
}