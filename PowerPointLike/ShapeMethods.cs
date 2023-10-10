using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike.Shape
{

    public partial class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        public Shape()
        {
            SetInitialCoordinate();
        }

        /// <summary>
        /// Method <c>SetInitCoordinate</c> 
        /// randomly get position to the given shape and store the top-left and bottom-right.
        /// </summary>
        public void SetInitialCoordinate()
        {
            var random = new Random();
            for (int i = 0; i < _shapeCoordinate.Length; i++)
            {
                _shapeCoordinate[i]._x = random.Next(MAX_RANGE);
                _shapeCoordinate[i]._y = random.Next(MAX_RANGE);
            }
        }

        /// <summary>
        /// Method <c>GetCoordinate</c>
        /// the getter of the coordinate of the shape
        /// </summary>
        /// <returns>the current coordinate of the shape</returns>
        public Coordinate[] GetCoordinate()
        {
            return _shapeCoordinate;
        }

        /// <summary>
        /// Method <c>GetOneElementData</c>
        /// get one whole element, including the name and the coordinate
        /// </summary>
        /// <returns>formatted string element data</returns>
        public string GetOneElementData()
        {
            string element = _shapeName + COMMA + LEFT_BRACKET + _shapeCoordinate[TOP_LEFT_POSITION]._x + LEFT_BRACKET + _shapeCoordinate[TOP_LEFT_POSITION]._y + RIGHT_BRACKET + COMMA + LEFT_BRACKET + _shapeCoordinate[BOTTOM_RIGHT_POSITION]._x + COMMA + _shapeCoordinate[BOTTOM_RIGHT_POSITION]._y + RIGHT_BRACKET;
            return element;
        }

        /// <summary>
        /// Method <c>GetOneElementCoordinate</c>
        /// get one whole element, only coordinate
        /// </summary>
        /// <returns>formatted string of coordinate data</returns>
        public string GetOneElementCoordinate()
        {
            string coordinate = LEFT_BRACKET + _shapeCoordinate[TOP_LEFT_POSITION]._x + LEFT_BRACKET + _shapeCoordinate[TOP_LEFT_POSITION]._y + RIGHT_BRACKET + COMMA + LEFT_BRACKET + _shapeCoordinate[BOTTOM_RIGHT_POSITION]._x + COMMA + _shapeCoordinate[BOTTOM_RIGHT_POSITION]._y + RIGHT_BRACKET;
            return coordinate;
        }
    }

}
