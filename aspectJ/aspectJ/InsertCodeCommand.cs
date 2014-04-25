using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspectJ
{
    class InsertCodeCommand : IUndoCommand
    {
        private CodeManager codeManager;
        private int index;
        private string code;

        public InsertCodeCommand(CodeManager setCodeManager)
        {
            this.codeManager = setCodeManager;
            //this.index = setIndex;
            //this.ch = setCh;
        }

        public void Execute()
        {
            codeManager.InserCode(index, code);
        }

        public void Undo()
        {
            codeManager.RemoveCode(index, code.Length);
        }
    }
}
