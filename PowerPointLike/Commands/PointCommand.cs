using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class PointCommand : ICommand
    {
        Shape _oldPositionShape;
        Shape _newPositionShape;
        Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointCommand"/> class.
        /// </summary>
        public PointCommand(Shape oldPositionShape, Shape newPositionShape, Model model)
        {
            _oldPositionShape = oldPositionShape.GetClone();
            _newPositionShape = newPositionShape.GetClone();
            _model = model;
        }

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute()
        {
            _model._shapes.ExchangeShape(_oldPositionShape.GetClone(), _newPositionShape.GetClone());
            _model.PrintTest();
        }

        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        public void ExecuteCancel()
        {
            _model._shapes.ExchangeShape(_newPositionShape.GetClone(), _oldPositionShape.GetClone());
            _model.PrintTest();
        }
    }
}
