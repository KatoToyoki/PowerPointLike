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
        public const int DATA_ELEMENT_LENGTH = 3;
        public const int DATA_DELETE_INDEX = 0;
        public const int DATA_NAME_INDEX = 1;
        public const int DATA_COORDINATE_INDEX = 2;
        public const int TOP_LEFT_POSITION = 0;
        public const int BOTTOM_RIGHT_POSITION = 1;
        public const string DELETE = "刪除";
        public const string LEFT_BRACKET = "(";
        public const string RIGHT_BRACKET = ")";
        public const string COMMA = ",";

        private ShapesAlias.Shapes _shapes = new ShapesAlias.Shapes();
    }
}
