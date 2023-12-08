using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public class DrawingState : State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingState"/> class.
        /// </summary>
        public DrawingState(Shapes shapes, Model model)
        {
            _shapes = shapes;
            _model = model;
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of the starting of the drawing
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasPressed(double coordinateX, double coordinateY, int shapeIndex, out CoordinateSet selectedOne)
        {
            ChangeCurrentIndex(shapeIndex);
            PressFirst(coordinateX, coordinateY, shapeIndex);
            _tempShape = _shapes.CreateTempShape(shapeIndex, _newShapeCoordinateSet);
            selectedOne = _selectedOneCoordinate;
        }

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of the process of the drawing
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasMoved(double coordinateX, double coordinateY, int shapeIndex, out CoordinateSet selectedOne)
        {
            PressMiddle(coordinateX, coordinateY);
            _tempShape = _shapes.CreateTempShape(shapeIndex, _newShapeCoordinateSet);
            Console.WriteLine(_tempShape._id);
            selectedOne = _selectedOneCoordinate;
        }

        /// <summary>
        /// Method <c>HandleCanvasReleased</c>
        /// this function is to deal with the situation of the process of the end of the drawing
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasReleased(double coordinateX, double coordinateY, int shapeIndex, out CoordinateSet selectedOne)
        {
            selectedOne = _selectedOneCoordinate;

            if (_isPressed)
            {
                CoordinateSet confirmOne = new CoordinateSet();
                confirmOne._point1 = _firstPoint;
                confirmOne._point2 = (new Coordinate((int)coordinateX, (int)coordinateY));
                _model._commandManager.Execute(new DrawingCommand(_model, _tempShape));
                _oldLength = -1;
                _newLength = -1;
            }
        }

        /// <summary>
        /// Method <c>PressMiddle</c>
        /// common things both draw and select need to do
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeindex</param>
        public void PressMiddle(double coordinateX, double coordinateY)
        {
            if (_isPressed)
            {
                _newShapeCoordinateSet._point2 = new Coordinate((int)coordinateX, (int)coordinateY);
            }
        }
    }
}
