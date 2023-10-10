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
        private List<ShapeAlias.Shape> _shapeContainer = new List<ShapeAlias.Shape>();
        private FactoryAlias.Factory _factory;
    }
}
