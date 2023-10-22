using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public abstract class Shape
    {
        public const int MAX_WIDTH = 890;
        public const int MAX_HEIGHT = 640;
        public const string COMMA = ",";

        public string _shapeName
        {
            get; set;
        }

        protected CoordinateSet _coordinateSet = new CoordinateSet();


        /// <summary>
        /// Method <c>RandomCoordinate</c>
        /// to create a random coordinate
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public Coordinate CreateRandomCoordinate(Random random)
        {
            Coordinate coordinate = new Coordinate();
            coordinate._x = random.Next(MAX_WIDTH);
            coordinate._y = random.Next(MAX_HEIGHT);
            return coordinate;
        }

        /// <summary>
        /// Method <c>InitContainer</c>
        /// to put elements in container depends on each Shape and the length
        /// </summary>
        /// <param name="length">the container length</param>
        protected void InitializeContainer()
        {
            var random = new Random();
            _coordinateSet._point1 = CreateRandomCoordinate(random);
            _coordinateSet._point2 = CreateRandomCoordinate(random);
        }

        /// <summary>
        /// Method <c>GetOneElementData</c>
        /// get one whole element, including the name and the coordinate
        /// </summary>
        /// <returns>formatted string element data</returns>
        public virtual string GetOneElementData()
        {
            return _shapeName + _coordinateSet.GetCoordinateSetString();
        }

        /// <summary>
        /// Method <c>GetOneElementCoordinate</c>
        /// get one whole element, only coordinate
        /// </summary>
        /// <returns>formatted string of coordinate data</returns>
        public virtual string GetOneElementCoordinate()
        {
            return _coordinateSet.GetCoordinateSetString();
        }
    }
}