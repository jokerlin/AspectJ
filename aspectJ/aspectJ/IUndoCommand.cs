using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspectJ
{
    // 可撤销的命令借口，所有可撤销的命令都从这里继承
    interface IUndoCommand:ICommand
    {
        void Undo();
    }
}
