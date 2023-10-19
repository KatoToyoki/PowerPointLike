using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;
using RectangleAlias = PowerPointLike.Rectangle;
using LineAlias = PowerPointLike.Line;

namespace PowerPointLike.Factory
{
    public partial class Factory
    {
        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new rectangle element
        /// </summary>
        /// <returns>rectangle element</returns>
        public ShapeAlias.Shape CreateRectangle()
        {
            ShapeAlias.Shape rectangle = new RectangleAlias.Rectangle();
            return rectangle;
        }

        /// <summary>
        /// Method <c>CreateRectangle</c>
        /// to create a new line element
        /// </summary>
        /// <returns>line element</returns>
        public ShapeAlias.Shape CreateLine()
        {
            ShapeAlias.Shape line = new LineAlias.Line();
            return line;
        }
    }
}
