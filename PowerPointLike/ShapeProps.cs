using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike.Shape
{
    public struct Coordinate
    {
        public int _x
        {
            get; set;
        }
        public int _y
        {
            get; set;
        }
    }
    public partial class Shape
    {
        public const int MAX_RANGE = 100;
        public const int COORDINATE_LENGTH = 2;

        public string _shapeName
        {
            get; set;
        }

        private Coordinate[] _shapeCoordinate = new Coordinate[COORDINATE_LENGTH];
    }
}
