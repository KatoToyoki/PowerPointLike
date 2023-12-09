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
        public Line(CoordinateSet coordinateSet, Factory factory)
        {
            _shapeName = LINE;
            _coordinateSet = coordinateSet;
             _factory = factory;
        }

        /// <summary>
        ///  Method <c>Draw</c>
        ///  to draw line
        /// </summary>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_coordinateSet);
        }

        public override Shape Clone()
        {
            // Line newOne = new Line(_coordinateSet.Clone());
            // return newOne;
            // return null;
            Shape newOne = _factory.CreateLine();
            newOne._coordinateSet = this._coordinateSet.Clone();
            return newOne;
        }
    }
}
