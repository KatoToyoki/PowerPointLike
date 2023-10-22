using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using ShapeAlias = PowerPointLike.Shape;

namespace PowerPointLike
{
    public class Line : Shape
    {
        public const string LINE = "線";

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        public Line(CoordinateSet coordinateSet)
        {
            _shapeName = LINE;
            _coordinateSet = coordinateSet;
        }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_coordinateSet);
        }
    }
}
