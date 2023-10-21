using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Circle : Shape
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
