using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class DataGridViewCommand : ICommand
    {
        public enum Command
        {
            Add,
            Delete
        }
        int _command;
        int _dataIndex;
        int _deleteIndex;
        Model _model;
        Shape _shape;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewCommand"/> class.
        /// </summary>
        public DataGridViewCommand(Shape shape, int dataIndex, int deleteIndex, Model model, int command)
        {
            _dataIndex = dataIndex;
            _deleteIndex = deleteIndex;
            _model = model;
            _command = command;
            _shape = shape;
        }

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute()
        {
            if (_command == (int)Command.Add)
            {
                _model._shapes.AddShape(_shape.GetClone(), _deleteIndex - 1);
            }
            else if (_command == (int)Command.Delete)
            {
                _model._shapes.DeleteCertainElement(_dataIndex, _deleteIndex);
            }
        }

        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        public void ExecuteCancel()
        {
            if (_command == (int)Command.Add)
            {
                _model._shapes.DeleteCertainElement(_dataIndex, _deleteIndex - 1);
            }
            else if (_command == (int)Command.Delete)
            {
                _model._shapes.AddShape(_shape.GetClone(), _deleteIndex);
            }
        }
    }
}
