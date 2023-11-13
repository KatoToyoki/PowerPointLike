using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Factory
    {
        public const int MAX_WIDTH = 600;
        public const int MAX_HEIGHT = 500;

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
        /// Method <c>SetCoordinateSet</c>
        /// order the two points with x
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private CoordinateSet SetCoordinateSet(Coordinate point1, Coordinate point2)
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
            Shape rectangle = new Rectangle(InitializeSet());
            return rectangle;
        }

        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new line element
        /// </summary>
        /// <returns>line element</returns>
        public Shape CreateLine()
        {
            Shape line = new Line(InitializeSet());
            return line;
        }

        /// <summary>
        /// Method <c>CreateCircle</c>
        /// to create a new circle element
        /// </summary>
        /// <returns>circle element</returns>
        public Shape CreateCircle()
        {
            Shape circle = new Circle(InitializeSet());
            return circle;
        }

        /// <summary>
        /// Method <c>DrawLine</c>
        /// to create a drawn line element
        /// </summary>
        /// <returns>line element</returns>
        public Shape DrawLine(CoordinateSet coordinateSet)
        {
            Shape line = new Line(coordinateSet);
            return line;
        }

        /// <summary>
        /// Method <c>DrawRectangle</c>
        /// to create a drawn rectangle element
        /// </summary>
        /// <returns>rectangle element</returns>
        public Shape DrawRectangle(CoordinateSet coordinateSet)
        {
            Shape rectangle = new Rectangle(coordinateSet);
            return rectangle;
        }

        /// <summary>
        /// Method <c>DrawCircle</c>
        /// to create a drawn circle element
        /// </summary>
        /// <returns>circle element</returns>
        public Shape DrawCircle(CoordinateSet coordinateSet)
        {
            Shape circle = new Circle(coordinateSet);
            return circle;
        }
    }
}
