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

        public DrawingCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute()
        {
            _model._shapes.AddShape(_shape);
        }

        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        public void ExecuteCancel()
        {
            _model._shapes.PopShape();
        }
    }
}
