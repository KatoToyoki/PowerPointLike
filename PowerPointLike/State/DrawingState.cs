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
        Shapes _shapes;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingState"/> class.
        /// </summary>
        public DrawingState(Shapes shapes)
        {
            _shapes = shapes;
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of the starting of the drawing
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasPressed(double coordinateX, double coordinateY, int shapeIndex)
        {
            ChangeCurrentIndex(shapeIndex);
            PressFirst(coordinateX, coordinateY, shapeIndex);
            _newShape = _shapes.CreateTempShape(shapeIndex, _newShapeCoordinateSet);
        }

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of the process of the drawing
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasMoved(double coordinateX, double coordinateY)
        {
            PressMiddle(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>HandleCanvasReleased</c>
        /// this function is to deal with the situation of the process of the end of the drawing
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasReleased(double coordinateX, double coordinateY, int shapeIndex)
        {
            if (_isPressed)
            {

                CoordinateSet confirmOne = new CoordinateSet();
                confirmOne._point1 = _firstPoint;
                confirmOne._point2 = (new Coordinate((int)coordinateX, (int)coordinateY));
                _shapes.DrawShape(shapeIndex, confirmOne);
            }
        }
    }
}
