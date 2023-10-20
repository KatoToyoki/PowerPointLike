using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;

namespace PowerPointLike.Rectangle
{
    public partial class Rectangle : ShapeAlias.Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle()
        {
            _shapeName = RECTANGLE;
            InitializeContainer(RECTANGLE_COORDINATE_LENGTH);
        }
    }
}
