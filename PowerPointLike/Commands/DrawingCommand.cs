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
        Shape _test1;
        Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingCommand"/> class.
        /// </summary>
        public DrawingCommand(Model model, Shape shape)
        {
            _shape = shape.Clone();
            _model = model;
            _test1 = _shape.Clone();
            Console.WriteLine("new draw " + shape._id + " " + _shape._id);
        }

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute()
        {
            // Console.WriteLine("do draw " + _shape.GetOneElementCoordinate() + " --" + _test1.GetOneElementCoordinate());
            Console.WriteLine("do draw " + _shape._id);
            _model._shapes.AddShape(_shape.Clone());
        }

        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        public void ExecuteCancel()
        {
            Console.WriteLine("undo draw " + _shape._id);
            // Console.WriteLine("undo draw " + _shape.GetOneElementCoordinate() + " --" + _test1.GetOneElementCoordinate());
            _model._shapes.PopShape();
        }
    }
}
