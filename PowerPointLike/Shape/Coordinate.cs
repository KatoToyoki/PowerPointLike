using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PowerPointLike
{
    public struct Coordinate
    {
        public const int QUANTITY = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordinate(int coordinateX, int coordinateY)
        {
            _x = coordinateX;
            _y = coordinateY;
        }
        public int _x
        {
            get; set;
        }
        public int _y
        {
            get; set;
        }

        /// <summary>
        /// Method <c>GetCoordinateString</c>
        /// </summary>
        /// <returns>coordinate string</returns>
        public string GetCoordinateString()
        {
            const string COORDINATE = "({0},{1})";
            return string.Format(COORDINATE, _x, _y);
        }

        /// <summary>
        /// Method <c>GetMiddlePoint</c>
        /// Thank you, Dr. Smell, for helping me with making the code more complex
        /// </summary>
        /// <param name="anotherPoint"></param>
        /// <returns></returns>
        public string GetMiddlePoint(Coordinate anotherPoint)
        {
            const string COORDINATE = "({0},{1})";
            return string.Format(COORDINATE, (_x + anotherPoint._x) / QUANTITY, (_y + anotherPoint._y) / QUANTITY);
        }

        /// <summary>
        /// Method <c>GetWidth</c>
        /// Thank you, Dr. Smell, for helping me with making the code more complex
        /// </summary>
        /// <returns>width</returns>
        public int GetWidth(Coordinate anotherPoint)
        {
            return Math.Abs(anotherPoint._x - _x);
        }

        /// <summary>
        /// Method <c>GetHeight</c>
        /// Thank you, Dr. Smell, for helping me with making the code more complex
        /// </summary>
        /// <returns>height</returns>
        public int GetHeight(Coordinate anotherPoint)
        {
            return Math.Abs(anotherPoint._y - _y);
        }
    }

    public struct CoordinateSet
    {
        public Coordinate _point1
        {
            get; set;
        }
        public Coordinate _point2
        {
            get; set;
        }

        /// <summary>
        /// Method <c>GetMiddlePoint</c>
        /// </summary>
        /// <returns>the middle point of the two points</returns>
        public string GetMiddlePoint()
        {
            return _point1.GetMiddlePoint(_point2);
        }

        /// <summary>
        /// Method <c>GetCoordinateSetString</c>
        /// </summary>
        /// <returns>coordinate string of two points</returns>
        public string GetCoordinateSetString()
        {
            const string COORDINATE = "{0},{1}";
            return string.Format(COORDINATE, _point1.GetCoordinateString(), _point2.GetCoordinateString());
        }

        /// <summary>
        /// Method <c>GetWidth</c>
        /// </summary>
        /// <returns>width</returns>
        public int GetWidth()
        {
            return _point1.GetWidth(_point2);
        }

        /// <summary>
        /// Method <c>GetHeight</c>
        /// </summary>
        /// <returns>height</returns>
        public int GetHeight()
        {
            return _point1.GetHeight(_point2);
        }
    }
}
