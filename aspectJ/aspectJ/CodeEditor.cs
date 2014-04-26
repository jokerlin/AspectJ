using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspectJ
{
    public class CodeEditor
    {
        public CodeManager codemanager;
        public CodeEditor()
        {
            codemanager = new CodeManager();
        }

        private void InsertCode(int index, string code)
        {
            InsertCodeCommand cmd = new InsertCodeCommand(codemanager);
            codemanager.Execute(cmd);
        }

        public void AppendCode(string code)
        {
            InsertCode(codemanager.Text.Length, code);
        }

        public void Undo()
        {
            codemanager.Undo();
        }
        public void Redo()
        {
            codemanager.Redo();
        }
    }
}
