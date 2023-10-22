using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Model
    {
        enum Data
        {
            DataDeleteIndex,
            DataNameIndex,
            DataCoordinateIndex,
            DataElementLength
        }

        public const string EMPTY_STRING = "";
        public const string DELETE = "刪除";
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
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
        }

        public void Draw(IGraphics graphics)
        {
            Console.WriteLine("in model, before each");
            _shapes.Draw(graphics);
        }

        public bool CheckInputValid(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                return true;
            }
            return false;
        }

        public void PointerPressed(double x, double y, int shapeIndex)
        {

            Console.WriteLine("click canvas, in model");
            if (!CheckInputValid(x, y))
            {
                return;
            }
            _firstPoint._x = (int)x;
            _firstPoint._y = (int)y;

            _newShapeCoordinateSet._point1 = _firstPoint;

            switch (shapeIndex)
            {
                case (int)PresentationModel.ShapeIndex.Line:
                    _newShape = new Line(_newShapeCoordinateSet);
                    break;
                case (int)PresentationModel.ShapeIndex.Rectangle:
                    _newShape = new Rectangle(_newShapeCoordinateSet);
                    break;
                case (int)PresentationModel.ShapeIndex.Circle:
                    _newShape = new Circle(_newShapeCoordinateSet);
                    break;
            }

            _isPressed = true;
        }

        public void PoinerMoved(double x, double y)
        {
            if (_isPressed)
            {
                Coordinate temp = new Coordinate();
                temp._x = (int)x;
                temp._y = (int)y;
                _newShapeCoordinateSet._point2 = temp;
                NotifyModelChanged();
            }
        }

        public void PointerReleased(double x, double y, int shapeIndex)
        {
            if (_isPressed)
            {
                _isPressed = false;
                CoordinateSet confirmOne = new CoordinateSet();
                confirmOne._point1 = _firstPoint;
                confirmOne._point2 = (new Coordinate((int)x, (int)y));
                _shapes.DrawShape(shapeIndex, confirmOne);
                NotifyModelChanged();
            }
        }

        void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }
    }
}