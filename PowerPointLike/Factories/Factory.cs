using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Factory
    {
        public const int MAX_WIDTH = 445;
        public const int MAX_HEIGHT = 320;

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
        /// Method <c>InitializeSet</c>
        /// to set coordinate to the set
        /// </summary>
        /// <param name="length">the container length</param>
        protected CoordinateSet InitializeSet()
        {
            CoordinateSet coordinateSet = new CoordinateSet();
            var random = new Random();
            coordinateSet._point1 = CreateRandomCoordinate(random);
            coordinateSet._point2 = CreateRandomCoordinate(random);
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
