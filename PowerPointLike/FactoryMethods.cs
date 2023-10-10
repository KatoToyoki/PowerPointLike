using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;
using RectangleAlias = PowerPointLike.Rectangle;
using LineAlias = PowerPointLike.Line;

namespace PowerPointLike.Factory
{
    public partial class Factory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShapeAlias.Shape CreateRectangle()
        {
            ShapeAlias.Shape rectangle = new RectangleAlias.Rectangle();
            return rectangle;
        }

        public ShapeAlias.Shape CreateLine()
        {
            ShapeAlias.Shape line = new LineAlias.Line();
            return line;
        }
    }
}
