using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Factory
    {
        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new rectangle element
        /// </summary>
        /// <returns>rectangle element</returns>
        public Shape CreateRectangle()
        {
            Shape rectangle = new Rectangle();
            return rectangle;
        }

        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new line element
        /// </summary>
        /// <returns>line element</returns>
        public Shape CreateLine()
        {
            Shape line = new Line();
            return line;
        }

        /// <summary>
        /// Method <c>CreateCircle</c>
        /// to create a new circle element
        /// </summary>
        /// <returns>circle element</returns>
        public Shape CreateCircle()
        {
            Shape circle = new Circle();
            return circle;
        }
    }
}
