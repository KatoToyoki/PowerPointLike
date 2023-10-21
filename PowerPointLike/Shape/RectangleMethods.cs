using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Rectangle : Shape
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
