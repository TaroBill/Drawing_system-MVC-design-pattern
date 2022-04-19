using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Command
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _undo = new Stack<ICommand>();
        private readonly Stack<ICommand> _redo = new Stack<ICommand>();

        //執行指令
        public void Execute(ICommand command)
        {
            _undo.Push(command);
            _redo.Clear();
            command.Execute();
        }

        //redo
        public void Redo()
        {
            if (_redo.Count < 1)
                throw new ArgumentOutOfRangeException();
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        //undo
        public void Undo()
        {
            if (_undo.Count < 1)
                throw new ArgumentOutOfRangeException();
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.CancelExecute();
        }

        //清除所有儲存的指令
        public void ClearAllCommand()
        {
            _undo.Clear();
            _redo.Clear();
        }

        public int UndoAmount
        {
            get
            {
                return _undo.Count;
            }
        }

        public int RedoAmount
        {
            get
            {
                return _redo.Count;
            }
        }
    }
}
