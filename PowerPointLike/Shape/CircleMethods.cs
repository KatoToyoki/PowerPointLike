using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;

namespace PowerPointLike.Circle
{
    public partial class Circle : ShapeAlias.Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle()
        {
            _shapeName = CIRCLE;
            InitializeContainer(CIRCLE_COORDINATE_LENGTH);
        }
    }
}
