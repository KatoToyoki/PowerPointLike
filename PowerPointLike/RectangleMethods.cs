using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;

namespace PowerPointLike.Rectangle
{
    public partial class Rectangle : ShapeAlias.Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Rectangle()
        {
            this._shapeName = RECTANGLE;
            this.SetInitialCoordinate();
        }
    }
}
