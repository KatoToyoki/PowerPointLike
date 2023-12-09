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
        public int _currentItem
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingState"/> class.
        /// </summary>
        public PointState(Shapes shapes, Model model)
        {
            _shapes = shapes;
            _isScale = false;
            _isFirstMove = false;
            _model = model;
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
            if (_shapes.GetContainerLength() == 0)
            {
                selectedOne = _selectedOneCoordinate;
                return;
            }
            _index = INVALID;
            PressFirst(coordinateX, coordinateY, shapeIndex);
            PickShape(coordinateX, coordinateY);
            selectedOne = _selectedOneCoordinate;
            _currentItem = _index;
            if (_selectedOneCoordinate.IsScale(coordinateX, coordinateY))
            {
                _isScale = true;
            }
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
            selectedOne = _selectedOneCoordinate;
            if (_shapes.GetContainerLength() == 0)
            {
                return;
            }
            if (_tempShape == null)
            {
                return;
            }
            selectedOne = _tempShape._coordinateSet;

            ScaleOrPointMove(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>ScaleOrPointMove</c>
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void ScaleOrPointMove(double coordinateX, double coordinateY)
        {
            if (ViolateMove())
            {
                return;
            }
            if (_isScale)
            {
                ScaleMove(coordinateX, coordinateY);
            }
            else if (!_isScale)
            {
                Move(coordinateX, coordinateY);
            }
        }

        /// <summary>
        /// Method <c>Move</c>
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void Move(double coordinateX, double coordinateY)
        {
            PressMiddle(coordinateX, coordinateY);
            _shapes.ChangeCoordinate(_currentItem, _newShapeCoordinateSet.GetDeltaX(), _newShapeCoordinateSet.GetDeltaY());
        }

        /// <summary>
        /// Method <c>ScaleMove</c>
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void ScaleMove(double coordinateX, double coordinateY)
        {
            PressMiddle(coordinateX, coordinateY);
            _shapes.ScaleCoordinate(_currentItem, _newShapeCoordinateSet.GetDeltaX(), _newShapeCoordinateSet.GetDeltaY());
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
            if (_tempShape == null)
            {
                selectedOne = new CoordinateSet(new Coordinate(0, 0), new Coordinate(0, 0));
                return;
            }

            if (_newShapeCoordinateSet._point2.GetIfIsSame(new Coordinate(0, 0)))
            {
                selectedOne = _tempShape._coordinateSet;
                return;
            }

            ReleaseCoordinate();
            ResetThreePoint();
            selectedOne = _tempShape._coordinateSet;
        }

        /// <summary>
        /// Method <c>ReleaseCoordinate</c>
        /// </summary>
        public void ReleaseCoordinate()
        {
            if (_isScale)
            {
                _tempShape = _shapes.GetShape(_index).GetClone();
                _model._commandManager.Execute(new PointCommand(_originalShape.GetClone(), _tempShape.GetClone(), _model));
            }
            else
            {
                _tempShape = _shapes.GetShape(_index).GetClone();
                _model._commandManager.Execute(new PointCommand(_originalShape.GetClone(), _tempShape.GetClone(), _model));
            }
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
            _originalShape = _shapes.CloneAndReplace(coordinateX, coordinateY);
            _tempShape = _shapes.CloneAndReplace(coordinateX, coordinateY);

            _selectedOneCoordinate = _tempShape._coordinateSet;
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
            if (ViolateSelectMove())
            {
                return;
            }
            if (IsNowScale())
            {
                ScaleFirstMove(coordinateX, coordinateY);
            }
            if (!_isFirstMove)
            {
                MoveFirstMove(coordinateX, coordinateY);
            }
            else
            {
                MoveMiddle(coordinateX, coordinateY);
            }
        }

        /// <summary>
        /// Method <c>ScaleFirstMove</c>
        /// </summary>
        public void ScaleFirstMove(double coordinateX, double coordinateY)
        {
            _newShapeCoordinateSet._point1 = new Coordinate(_selectedOneCoordinate.GetRight(), _selectedOneCoordinate.GetBottom());
            _newShapeCoordinateSet._point2 = new Coordinate((int)coordinateX, (int)coordinateY);
            _isFirstMove = true;
        }

        /// <summary>
        /// Method <c>MoveFirstMove</c>
        /// </summary>
        public void MoveFirstMove(double coordinateX, double coordinateY)
        {
            _newShapeCoordinateSet._point2 = new Coordinate((int)coordinateX, (int)coordinateY);
            _isFirstMove = true;
        }

        /// <summary>
        /// Method <c>MoveMiddle</c>
        /// </summary>
        public void MoveMiddle(double coordinateX, double coordinateY)
        {
            Coordinate temp = new Coordinate((int)coordinateX, (int)coordinateY);
            _newShapeCoordinateSet._point1 = _newShapeCoordinateSet._point2;
            _newShapeCoordinateSet._point2 = temp;
        }
    }
}
