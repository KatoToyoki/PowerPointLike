using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Shapes
    {
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string CIRCLE = "圓";
        const string INFORMATION_TEMPLATE = "{NAME}, ({TOP_LEFT_X},{TOP_LEFT_Y}),({BOTTOM_RIGHT_X},{BOTTOM_RIGHT_Y})";
        private List<Shape> _shapeContainer = new List<Shape>();
        private Factory _factory = new Factory();
    }
}
