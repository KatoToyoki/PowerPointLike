using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;
using ShapesAlias = PowerPointLike.Shapes;

namespace PowerPointLike.Model
{
    public partial class Model
    {
        public const string EMPTY_STRING = "";
        public const string DELETE = "刪除";

        private ShapesAlias.Shapes _shapes = new ShapesAlias.Shapes();
    }
}
