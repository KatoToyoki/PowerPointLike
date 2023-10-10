using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;
using FactoryAlias = PowerPointLike.Factory;

namespace PowerPointLike.Shapes
{
    public partial class Shapes
    {
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string INFORMATION_TEMPLATE = "{NAME}, ({TOP_LEFT_X},{TOP_LEFT_Y}),({BOTTOM_RIGHT_X},{BOTTOM_RIGHT_Y})";
        private List<ShapeAlias.Shape> _shapeContainer = new List<ShapeAlias.Shape>();
        private FactoryAlias.Factory _factory = new FactoryAlias.Factory();
    }
}
