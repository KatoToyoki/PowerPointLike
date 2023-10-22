using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Rectangle : Shape
    {
        public const string RECTANGLE = "矩形";
        public const int RECTANGLE_COORDINATE_LENGTH = 2;
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle()
        {
            _shapeName = RECTANGLE;
            InitializeContainer();
        }

        // public override void Draw()
        // {
        // }
    }
}
