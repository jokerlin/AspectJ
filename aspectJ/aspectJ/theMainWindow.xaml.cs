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
using System.Windows.Forms;
using System.Threading;
namespace aspectJ
{
	/// <summary>
	/// theMainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class theMainWindow : Window
	{
        public CodeManager codemanager;
        CodeEditor codeEditor;
		public theMainWindow()
		{
			this.InitializeComponent();
            undoButton.Command = System.Windows.Input.ApplicationCommands.Undo;
            undoButton.IsEnabled = true;
            codemanager = new CodeManager();
            codeEditor = new CodeEditor();
			// 在此点之下插入创建对象所需的代码。
            
           

		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            codeWindow cw = new codeWindow();
            cw.Owner = this;
            cw.set(ref richTextBox, ref codeEditor);
            cw.ShowDialog();
        }

        private void functionDropButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingWindow lw = new LoadingWindow();
            lw.Show();
            lw.Owner = this;

            GetCalls getCalls = new GetCalls();
            getCalls.Run();
            treeGraph tg = new treeGraph();
            lw.Close();
            tg.Owner = this;
            tg.ShowDialog();
            
            
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Close();// 在此处添加事件处理程序实现。
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            codeEditor.Undo();
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择Java源码所在的文件夹";
            folderBrowserDialog.ShowNewFolderButton = true;
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            string folderName = folderBrowserDialog.SelectedPath;
            Program.functionlist(folderName);
            for (int i = 0; i < Program.fl.Count; i++)
            {
               // ResourceDictionary resourceDictionary = new ResourceDictionary();
                //resourceDictionary.Source=new Uri("
                ListBoxItem lbi = new ListBoxItem() { Content = Program.fl[i], Style = Resources["ListBoxItemStyle2"] as Style};
                srcList.Items.Add(lbi);
                
                
            }
        }

        private void cutOpenButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            pointCutAndAdviceChoose pcaac = new pointCutAndAdviceChoose();
            pcaac.ShowDialog();
            // 在此处添加事件处理程序实现。
        }

        private void doButton_Click(object sender, RoutedEventArgs e)
        {
            //GenerateAJFile.generateAJFile();
        }
	}
}