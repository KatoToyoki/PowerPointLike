﻿using System;
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
        public bool _isScale
        {
            get; set;
        }

        public int _currentItem
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingState"/> class.
        /// </summary>
        public PointState(Shapes shapes)
        {
            _shapes = shapes;
            _isScale = false;
            _isFirstMove = false;
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of selecting one certain shape
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasPressed(double coordinateX, double coordinateY, int shapeIndex, out CoordinateSet selectedOne)
        {

            _index = INVALID;
            PressFirst(coordinateX, coordinateY, shapeIndex);
            PickShape(coordinateX, coordinateY);
            selectedOne = _selectedOneCoordinate;
            _currentItem = _index;
        }

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of dragging the shape to new position
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasMoved(double coordinateX, double coordinateY, int shapeIndex, out CoordinateSet selectedOne)
        {
            PickShape(coordinateX, coordinateY);
            selectedOne = _selectedOneCoordinate;
            if (ViolateMove())
            {
                return;
            }
            PressMiddle(coordinateX, coordinateY);
            _shapes.ChangeCoordinate(_currentItem, _newShapeCoordinateSet.GetDeltaX(), _newShapeCoordinateSet.GetDeltaY());
        }

        /// <summary>
        /// Method <c>HandleCanvasReleased</c>
        /// this function is to deal with the situation of the process of releasing select a graph
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasReleased(double coordinateX, double coordinateY, int shapeIndex, out CoordinateSet selectedOne)
        {
            if (_newShapeCoordinateSet._point2.GetIfIsSame(new Coordinate(0, 0)))
            {
                PickShape(coordinateX, coordinateY);
                selectedOne = _selectedOneCoordinate;
                return;
            }

            _shapes.ChangeCoordinate(_currentItem, _newShapeCoordinateSet.GetDeltaX(), _newShapeCoordinateSet.GetDeltaY());
            ResetThreePoint();
            _isPressed = false;
            _isFirstMove = false;

            PickShape(coordinateX, coordinateY);
            selectedOne = _selectedOneCoordinate;
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

        /// <summary>
        /// Method <c>PressMiddle</c>
        /// common things both draw and select need to do
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeindex</param>
        public void PressMiddle(double coordinateX, double coordinateY)
        {
            if (!_isPressed)
            {
                return;
            }
            if (!_isFirstMove)
            {
                _newShapeCoordinateSet._point2 = new Coordinate((int)coordinateX, (int)coordinateY);
                _isFirstMove = true;
            }
            else
            {
                Coordinate temp = new Coordinate((int)coordinateX, (int)coordinateY);
                _newShapeCoordinateSet._point1 = _newShapeCoordinateSet._point2;
                _newShapeCoordinateSet._point2 = temp;
            }
        }
    }
}
