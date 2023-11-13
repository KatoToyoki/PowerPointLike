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

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingState"/> class.
        /// </summary>
        public PointState(Shapes shapes)
        {
            _shapes = shapes;
            _index = INVALID;
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
            PressFirst(coordinateX, coordinateY, shapeIndex);

        }

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of dragging the shape to new position
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeIndex</param>
        public override void HandleCanvasMoved(double coordinateX, double coordinateY)
        {
            PressMiddle(coordinateX, coordinateY);
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
            _index = -1;
            PickShape(coordinateX, coordinateY);
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
