using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public struct Coordinate
    {
        public double _x
        {
            get; set;
        }
        public double _y
        {
            get; set;
        }
    }
    public partial class Shape
    {
        public const int MAX_WIDTH = 890;
        public const int MAX_HEIGHT = 640;
        public const int COORDINATE_LENGTH = 2;
        public const int TOP_LEFT_POSITION = 0;
        public const int BOTTOM_RIGHT_POSITION = 1;
        public const string LEFT_BRACKET = "(";
        public const string RIGHT_BRACKET = ")";
        public const string COMMA = ",";

        public string _shapeName
        {
            get; set;
        }

        protected List<Coordinate> _coordinateContainer = new List<Coordinate>();
    }
}
