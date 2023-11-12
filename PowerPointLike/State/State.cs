using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public abstract class State
    {
        public enum StateIndex
        {
            Draw,
            Select
        }

        public int _currentStateIndex
        {
            get; set;
        }

        protected Coordinate _firstPoint;
        protected CoordinateSet _newShapeCoordinateSet = new CoordinateSet();
        protected Shape _newShape;
        public bool _isPressed
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State()
        {
            _currentStateIndex = (int)StateIndex.Select;
            _isPressed = false;
        }

        /// <summary>
        /// Method <c>ChangeCurrentIndex</c>
        /// depends on the button index to change the state index
        /// </summary>
        /// <param name="index">button index</param>
        public void ChangeCurrentIndex(int index)
        {
            if (index == -1)
            {
                _currentStateIndex = (int)StateIndex.Select;
            }
            else
            {
                _currentStateIndex = (int)StateIndex.Draw;
            }
        }

        /// <summary>
        /// Method <c>CreateState</c>
        /// depends on state index, create corresponding state for it
        /// </summary>
        /// <param name="index">button index</param>
        /// <param name="shapes">the container, will be need with draw event</param>
        /// <returns></returns>
        public State CreateState(int index, Shapes shapes)
        {
            ChangeCurrentIndex(index);

            if (_currentStateIndex == (int)StateIndex.Draw)
            {
                return new DrawingState(shapes);
            }
            else if (_currentStateIndex == (int)StateIndex.Select)
            {
                return new PointState();
            }
            return null;
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of 
        /// 1. the starting of the drawing
        /// 2. select one certain shape
        /// </summary>
        /// <param name="e"></param>
        public abstract void HandleCanvasPressed(double coordinateX, double coordinateY, int shapeIndex);

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of 
        /// 1. the process of the drawing
        /// 2. drag the shape to new position
        /// </summary>
        /// <param name="e"></param>
        public abstract void HandleCanvasMoved(double coordinateX, double coordinateY);

        /// <summary>
        /// Method <c>HandleCanvasReleased</c>
        /// this function is to deal with the situation of 
        /// 1. the end of the drawing
        /// 2. release select a graph
        /// </summary>
        /// <param name="e"></param>
        public abstract void HandleCanvasReleased(double coordinateX, double coordinateY, int shapeIndex);

        /// <summary>
        /// Method <c>PressFirst</c>
        /// common things both draw and select need to do
        /// </summary>
        /// <param name="coordinateX">x</param>
        /// <param name="coordinateY">y</param>
        /// <param name="shapeIndex">shapeindex</param>
        public void PressFirst(double coordinateX, double coordinateY, int shapeIndex)
        {

            _firstPoint._x = (int)coordinateX;
            _firstPoint._y = (int)coordinateY;
            _newShapeCoordinateSet._point1 = _firstPoint;
            _isPressed = true;
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
                Coordinate temp = new Coordinate();
                temp._x = (int)coordinateX;
                temp._y = (int)coordinateY;
                _newShapeCoordinateSet._point2 = temp;
            }
        }
    }
}
