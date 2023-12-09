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

        Shape _test1;
        // Shape _ensureOld;
        int _index;
        Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointCommand"/> class.
        /// </summary>
        public PointCommand(Shape oldPositionShape, Shape newPositionShape, Model model)
        {
            _oldPositionShape = oldPositionShape.Clone();
            _newPositionShape = newPositionShape.Clone();
            _test1 = _newPositionShape.Clone();

            _index = oldPositionShape._id;
            _model = model;
            // Console.WriteLine("new point " + _oldPositionShape.GetOneElementCoordinate() + " " + _newPositionShape.GetOneElementCoordinate());
            // Console.WriteLine(_newPositionShape._id + " " + _oldPositionShape._id);
        }

        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("do point " + _oldPositionShape._id + " " + _newPositionShape._id);
            // Console.WriteLine("do new old positions: " + _oldPositionShape.GetOneElementCoordinate() + " " + _newPositionShape.GetOneElementCoordinate() + " --" + _test1.GetOneElementCoordinate());
            _model._shapes.ExchangeShape(_index, _newPositionShape.Clone());
            // CoordinateSet temp = _model._shapes.GetShape(_index)._coordinateSet;
            // if (temp.GetIfIsSame(_newPositionShape._coordinateSet))
            // {
            //     _model._shapes.ExchangeShape(_index, _oldPositionShape);
            // }
            // else
            // {
            //     _model._shapes.ExchangeShape(_index, _newPositionShape);
            // }
        }


        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        public void ExecuteCancel()
        {
            Console.WriteLine("undo point " + _oldPositionShape._id + " " + _newPositionShape._id);
            // Console.WriteLine("undo new old positions: " + _oldPositionShape.GetOneElementCoordinate() + " " + _newPositionShape.GetOneElementCoordinate() + " --" + _test1.GetOneElementCoordinate());
            _model._shapes.ExchangeShape(_index, _oldPositionShape.Clone());
            // CoordinateSet temp = _model._shapes.GetShape(_index)._coordinateSet;
            // if (temp.GetIfIsSame(_newPositionShape._coordinateSet))
            // {
            //     _model._shapes.ExchangeShape(_index, _oldPositionShape);
            // }
            // else
            // {
            //     _model._shapes.ExchangeShape(_index, _newPositionShape);
            // }
            // Shape temp = _newPositionShape.Clone();
            // _newPositionShape = _oldPositionShape.Clone();
            // _oldPositionShape = temp.Clone();
        }
    }
}
