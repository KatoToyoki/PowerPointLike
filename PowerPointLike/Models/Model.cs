using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Model
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        enum Data
        {
            DataDeleteIndex,
            DataNameIndex,
            DataCoordinateIndex,
            DataElementLength
        }
        public const string EMPTY_STRING = "";
        public const string DELETE = "刪除";

        // for drawing new shape
        Coordinate _firstPoint;
        private CoordinateSet _newShapeCoordinateSet = new CoordinateSet();
        private Shape _newShape;
        private bool _isPressed = false;
        private Shapes _shapes = new Shapes();

        /// <summary>
        /// Method <c>PrintTest</c>
        /// to print the attributes of each element in the container
        /// </summary>
        public void PrintTest()
        {
            _shapes.PrintContainer();
        }

        /// <summary>
        /// Method <c>AddItem</c>
        /// to call the factory to add new element depends on the chosen element
        /// </summary>
        /// <param name="shape"></param>
        public void AddItem(string shape)
        {
            if (shape == EMPTY_STRING)
            {
                return;
            }
            _shapes.AddShape(shape);
            NotifyModelChanged();

            // print test
            PrintTest();
        }

        /// <summary>
        /// Method <c>GetOneElement</c>
        /// get the delete button, name, and its coordinate in one time
        /// the informatiob is constructed by a string array
        /// </summary>
        /// <param name="index"></param>
        /// <returns>one element info separated in string array</returns>
        public string[] GetOneElement(int index)
        {
            string[] element = new string[(int)Data.DataElementLength];
            element[(int)Data.DataDeleteIndex] = DELETE;
            element[(int)Data.DataNameIndex] = _shapes.GetElementName(index);
            string coordinate = _shapes.GetElementCoordinateString(index);
            element[(int)Data.DataCoordinateIndex] = coordinate;
            return element;
        }

        /// <summary>
        /// Method <c>GetContainerLength</c>
        /// to get the shapes container's length
        /// </summary>
        /// <returns>the length of shapes container</returns>
        public int GetContainerLength()
        {
            return _shapes.GetContainerLength();
        }

        /// <summary>
        /// Method <c>GetCurrentElement</c>
        /// to get the current(last) element
        /// </summary>
        /// <returns>the current element, which is a string array contains delete, name, coordinate</returns>
        public string[] GetCurrentElement()
        {
            return GetOneElement(_shapes.GetContainerLength() - 1);
        }

        /// <summary>
        /// Method <c>DeleteCertainElement</c>
        /// </summary>
        /// <param name="index">the wanted index</param>
        public void DeleteCertainElement(int index)
        {
            _shapes.DeleteCertainElement(index);
            NotifyModelChanged();
        }

        /// <summary>
        /// Method <c>Draw</c>
        /// to draw all instances
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);
        }

        /// <summary>
        /// Method <c>CheckInputValid</c>
        /// to check if it's invalid
        /// </summary>
        /// <param name="x">the x of the coordinate</param>
        /// <param name="y">the y of the coordinate</param>
        /// <returns></returns>
        public bool CheckInputValid(double coordinateX, double coordinateY)
        {
            if (coordinateX > 0 && coordinateY > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Method <c>PressPointer</c>
        ///  when first point is pressed
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shapeIndex">to know which shape to draw</param>
        public void PressPointer(double coordinateX, double coordinateY, int shapeIndex)
        {
            if (!CheckInputValid(coordinateX, coordinateY))
            {
                return;
            }
            _firstPoint._x = (int)coordinateX;
            _firstPoint._y = (int)coordinateY;
            _newShapeCoordinateSet._point1 = _firstPoint;
            _newShape = _shapes.CreateTempShape(shapeIndex, _newShapeCoordinateSet);
            _isPressed = true;
        }

        /// <summary>
        ///  Method <c>MovePointer</c>
        ///  while moving
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePointer(double coordinateX, double coordinateY)
        {
            if (_isPressed)
            {
                Coordinate temp = new Coordinate();
                temp._x = (int)coordinateX;
                temp._y = (int)coordinateY;
                _newShapeCoordinateSet._point2 = temp;
                NotifyModelChanged();
            }
        }

        /// <summary>
        ///  Method <c>ReleasePointer</c>
        ///  when released
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shapeIndex">to know which shape to draw</param>
        public void ReleasePointer(double coordinateX, double coordinateY, int shapeIndex)
        {
            if (_isPressed)
            {
                _isPressed = false;
                CoordinateSet confirmOne = new CoordinateSet();
                confirmOne._point1 = _firstPoint;
                confirmOne._point2 = (new Coordinate((int)coordinateX, (int)coordinateY));
                _shapes.DrawShape(shapeIndex, confirmOne);
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// Method <c>NotifyModelChanged</c>
        /// model is changing
        /// </summary>
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

    }
}