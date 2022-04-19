using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Command
{
    public interface ICommand
    {
        //執行指令
        void Execute();

        //取消指令
        void CancelExecute();
    }
}
