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
        public const int LINE_COORDINATE_LENGTH = 2;
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        public Line()
        {
            _shapeName = LINE;
            InitializeContainer();
        }

        // public override void Draw()
        // {
        // }
    }
}
