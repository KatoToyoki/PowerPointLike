using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Circle : Shape
    {
        public const string CIRCLE = "圓";
        public const int CIRCLE_COORDINATE_LENGTH = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle()
        {
            _shapeName = CIRCLE;
            InitializeContainer();
        }

        public override string GetOneElementData()
        {
            return _shapeName + _coordinateSet.GetMiddlePoint();
        }

        public override string GetOneElementCoordinate()
        {
            return _coordinateSet.GetMiddlePoint();
        }

        // public override void Draw()
        // {
        // graphics.DrawCircle();
        // }
    }
}
