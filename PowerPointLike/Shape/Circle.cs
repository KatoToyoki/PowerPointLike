using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Circle : Shape
    {
        public const string CIRCLE = "圓";

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle(CoordinateSet coordinateSet)
        {
            _shapeName = CIRCLE;
            _coordinateSet = coordinateSet;
        }

        /// <summary>
        ///  Method <c>Draw</c>
        ///  to draw circle
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_coordinateSet);
        }
    }
}
