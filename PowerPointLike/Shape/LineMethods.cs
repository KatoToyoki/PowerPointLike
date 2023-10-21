using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using ShapeAlias = PowerPointLike.Shape;

namespace PowerPointLike
{
    public partial class Line : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        public Line()
        {
            _shapeName = LINE;
            InitializeContainer(LINE_COORDINATE_LENGTH);
        }
    }
}
