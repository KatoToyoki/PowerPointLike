using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        /// <summary>
        /// Method <c>Undo</c>
        /// </summary>
        public void Undo()
        {
            if (_undo.Count <= 0)
            {
                return;
            }
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.ExecuteCancel();
        }

        /// <summary>
        /// Method <c>Redo</c>
        /// </summary>
        public void Redo()
        {
            if (_redo.Count <= 0)
            {
                return;
            }
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        /// <summary>
        /// Method <c>IsRedoEnabled</c>
        /// </summary>
        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        /// <summary>
        /// Method <c>IsUndoEnabled</c>
        /// </summary>
        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
