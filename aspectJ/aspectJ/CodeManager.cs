using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace aspectJ
{
    public class CodeManager
    {
        private Stack<IUndoCommand> undoCommands; // 保存执行后，可以撤销的命令
        private Stack<IUndoCommand> redoCommands; // 保存撤销后，可以重做的命令

        private StringBuilder text; // 保存代码的地方

        public string Text
        {
            get
            {
                return text.ToString();
            }
        }

        public CodeManager()
        {
            undoCommands = new Stack<IUndoCommand>();
            redoCommands = new Stack<IUndoCommand>();

            text = new StringBuilder();
        }
        // 执行命令，并且添加命令到堆栈中
        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            redoCommands.Clear(); // 当输入一个新的命令后，要清除可重做的命令。因为重做命令应该只是在撤销命令执行后，才能使用的。
            if (cmd is IUndoCommand)
            {
                undoCommands.Push(cmd as IUndoCommand);
            }
            else
            {
                undoCommands.Clear();
            }
        }
        // 撤销
        public void Undo()
        {
            if (undoCommands.Count == 0)
            {
                MessageBox.Show("不能撤销了");
                return;
            }

            IUndoCommand cmd = undoCommands.Pop();
            cmd.Undo();
            redoCommands.Push(cmd);
        }
        // 重做
        public void Redo()
        {
            if (redoCommands.Count == 0)
            {
                MessageBox.Show("不能重做了");
                return;
            }
            IUndoCommand cmd = redoCommands.Pop();
            cmd.Execute();
            undoCommands.Push(cmd);
        }
        // 具体的对文本的操作函数
        public void InserCode(int index, string code)
        {
            text.Insert(index, code);
        }

        public void RemoveCode(int index, int length)
        {
            text.Remove(index, length);
        }

        public char GetCode(int index)
        {
            return text[index];
        }
    }
}
