using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
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

        public string GetCoordinateString()
        {
            const string COORDINATE = "({0},{1})";
            return string.Format(COORDINATE, _x, _y);
        }
    }

    public struct CoordinateSet
    {
        public Coordinate _point1
        {
            get; set;
        }
        public Coordinate _point2
        {
            get; set;
        }

        public string GetMiddlePoint()
        {
            Coordinate result = new Coordinate();
            result._x = (_point1._x + _point2._x) / 2;
            result._y = (_point1._y + _point2._y) / 2;
            return result.GetCoordinateString();
        }

        public string GetCoordinateSetString()
        {
            const string COORDINATE = "{0},{1}";
            return string.Format(COORDINATE, _point1.GetCoordinateString(), _point2.GetCoordinateString());
        }
    }
}
