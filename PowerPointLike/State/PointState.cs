using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public class PointState : State
    {
        private Shapes _shapes;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingState"/> class.
        /// </summary>
        public PointState(Shapes shapes)
        {
            _shapes = shapes;
            // _index = INVALID;
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of selecting one certain shape
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasPressed(double coordinateX, double coordinateY, int shapeIndex)
        {
            _index = INVALID;
            PressFirst(coordinateX, coordinateY, shapeIndex);
            PickShape(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of dragging the shape to new position
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasMoved(double coordinateX, double coordinateY, int shapeIndex)
        {
            if (!(_firstPoint._x == 0 || _firstPoint._y == 0))
            {
                Console.WriteLine("first changed? in MOVE!!! " + _firstPoint.GetCoordinateString());
            }

            if (_index == INVALID)
            {
                return;
            }

            if (!_startPoint.GetIfIsSame(_firstPoint))
            {
                _firstPoint = _newShapeCoordinateSet._point2;
                _newShapeCoordinateSet._point1 = _firstPoint;
            }

            PressMiddle(coordinateX, coordinateY);
            Console.WriteLine("~~~~~~~~capture point2? " + _newShapeCoordinateSet.GetCoordinateSetString());
            PickShape(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>HandleCanvasReleased</c>
        /// this function is to deal with the situation of the process of releasing select a graph
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasReleased(double coordinateX, double coordinateY, int shapeIndex)
        {

            int deltaX = _newShapeCoordinateSet.GetDeltaX();
            int deltaY = _newShapeCoordinateSet.GetDeltaY();

            Console.WriteLine("look how far " + _newShapeCoordinateSet.GetDeltaX() + " " + _newShapeCoordinateSet.GetDeltaY());

            if (!(_newShapeCoordinateSet._point2._x == 0 && _newShapeCoordinateSet._point2._y == 0))
            {
                Console.WriteLine("===============here?");
                _shapes.ChangeCoordinate(_index, deltaX, deltaY);

                if (_index != -1)
                {
                    Console.WriteLine("changed " + _shapes.GetElementCoordinateString(_index));
                }

                _firstPoint = new Coordinate(0, 0);
                _startPoint = _firstPoint;
                _newShapeCoordinateSet = new CoordinateSet(_firstPoint, _firstPoint);

            }
            else
            {
                Console.WriteLine("just click!!");
            }


            // _index = -1;
            PickShape(coordinateX + deltaX / 2, coordinateY + deltaY / 2);
            Console.WriteLine("end change position " + _index);
        }

        /// <summary>
        /// Method <c>PickShape</c>
        /// to find the picked shape
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void PickShape(double coordinateX, double coordinateY)
        {
            CoordinateSet selectedCoordinate;
            if (_shapes.PickShape(coordinateX, coordinateY, out selectedCoordinate) == null)
            {
                return;
            }

            _index = (int)_shapes.PickShape(coordinateX, coordinateY, out selectedCoordinate);
            _selectedOneCoordinate = selectedCoordinate;
        }
    }
}
