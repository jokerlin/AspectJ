using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspectJ
{
    //// 命令接口，所有能被编辑器接受命令都从这里继承
    public interface ICommand
    {
        void Execute();
    }
}
