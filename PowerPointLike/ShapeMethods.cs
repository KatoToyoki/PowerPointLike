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
        public Coordinate[] GetCooderinate()
        {
            return _shapeCoordinate;
        }
    }

}
