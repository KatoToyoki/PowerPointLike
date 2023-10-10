using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;

namespace PowerPointLike.Line
{
    public partial class Line : ShapeAlias.Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Line()
        {
            this._shapeName = LINE;
            this.SetInitialCoordinate();
        }
    }
}
