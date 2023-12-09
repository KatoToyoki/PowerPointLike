using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public partial class Factory
    {
        public int _maxWidth
        {
            get; set;
        }
        public int _maxHeight
        {
            get; set;
        }

        private List<Shape> _shapeContainer;

        public Factory(List<Shape> shapeContainer)
        {
            _shapeContainer = shapeContainer;
        }

        /// <summary>
        /// Method <c>RandomCoordinate</c>
        /// to create a random coordinate
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public Coordinate CreateRandomCoordinate(Random random)
        {
            Coordinate coordinate = new Coordinate();
            coordinate._x = random.Next(_maxWidth);
            coordinate._y = random.Next(_maxHeight);
            return coordinate;
        }

        /// <summary>
        /// Method <c>SetCoordinateSet</c>
        /// order the two points with x
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public CoordinateSet SetCoordinateSet(Coordinate point1, Coordinate point2)
        {
            CoordinateSet result = new CoordinateSet();
            if (point1.GetIfSelfBigger(point2))
            {
                result._point1 = point2;
                result._point2 = point1;
            }
            else
            {
                result._point1 = point1;
                result._point2 = point2;
            }

            return result;
        }

        /// <summary>
        /// Method <c>InitializeSet</c>
        /// to set coordinate to the set
        /// </summary>
        /// <param name="length">the container length</param>
        protected CoordinateSet InitializeSet()
        {
            CoordinateSet coordinateSet = new CoordinateSet();
            Coordinate point1 = new Coordinate();
            Coordinate point2 = new Coordinate();
            var random = new Random();
            point1 = CreateRandomCoordinate(random);
            point2 = CreateRandomCoordinate(random);
            coordinateSet = SetCoordinateSet(point1, point2);

            return coordinateSet;
        }

        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new rectangle element
        /// </summary>
        /// <returns>rectangle element</returns>
        public Shape CreateRectangle()
        {
            Shape rectangle = new Rectangle(InitializeSet(), this);
            // rectangle._id = _shapeContainer.Count;
            rectangle._id = GetMaxValue() + 1;
            return rectangle;
        }

        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new line element
        /// </summary>
        /// <returns>line element</returns>
        public Shape CreateLine()
        {
            Shape line = new Line(InitializeSet(), this);
            // line._id = _shapeContainer.Count; 
            line._id = GetMaxValue() + 1;
            return line;
        }

        /// <summary>
        /// Method <c>CreateCircle</c>
        /// to create a new circle element
        /// </summary>
        /// <returns>circle element</returns>
        public Shape CreateCircle()
        {
            Shape circle = new Circle(InitializeSet(), this);
            // circle._id = _shapeContainer.Count;
            circle._id = GetMaxValue() + 1;
            return circle;
        }

        /// <summary>
        /// Method <c>DrawLine</c>
        /// to create a drawn line element
        /// </summary>
        /// <returns>line element</returns>
        public Shape DrawLine(CoordinateSet coordinateSet)
        {
            Shape line = new Line(coordinateSet, this);
            // line._id = _shapeContainer.Count; 
            line._id = GetMaxValue() + 1;
            return line;
        }

        /// <summary>
        /// Method <c>DrawRectangle</c>
        /// to create a drawn rectangle element
        /// </summary>
        /// <returns>rectangle element</returns>
        public Shape DrawRectangle(CoordinateSet coordinateSet)
        {
            Shape rectangle = new Rectangle(coordinateSet, this);
            // rectangle._id = _shapeContainer.Count;
            rectangle._id = GetMaxValue() + 1;
            return rectangle;
        }

        /// <summary>
        /// Method <c>DrawCircle</c>
        /// to create a drawn circle element
        /// </summary>
        /// <returns>circle element</returns>
        public Shape DrawCircle(CoordinateSet coordinateSet)
        {
            Shape circle = new Circle(coordinateSet, this);
            // circle._id = _shapeContainer.Count;
            circle._id = GetMaxValue() + 1;
            return circle;
        }

        /// <summary>
        /// Method <c>SetCanvasSize</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetCanvasSize(int width, int height)
        {
            _maxWidth = width;
            _maxHeight = height;
        }

        /// <summary>
        /// Method <c>GetMaxValue</c>
        /// </summary>
        /// <returns></returns>
        public int GetMaxValue()
        {
            int maxValue = ButtonModel.INVALID;
            if (_shapeContainer.Count == 0)
            {
                return 0;
            }
            for (int i = 0; i < _shapeContainer.Count; i++)
            {
                if (_shapeContainer[i]._id > maxValue)
                {
                    maxValue = _shapeContainer[i]._id;
                }
            }

            return maxValue;
        }
    }
}
