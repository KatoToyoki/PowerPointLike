using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class DrawingCommand : ICommand
    {
        Shape _shape;
        Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingCommand"/> class.
        /// </summary>
        public DrawingCommand(Model model, Shape shape)
        {
            _shape = shape.GetClone();
            _model = model;
        }

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute()
        {
            _model._shapes.AddShape(_shape.GetClone());
            _model.PrintTest();
        }

        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        public void ExecuteCancel()
        {
            _model._shapes.PopShape();
            _model.PrintTest();
        }
    }
}
