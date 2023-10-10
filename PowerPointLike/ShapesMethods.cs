using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;
using RectangleAlias = PowerPointLike.Rectangle;
using LineAlias = PowerPointLike.Line;

namespace PowerPointLike.Shapes
{
    public partial class Shapes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeName"></param>
        public void AddShape(string shapeName)
        {
            if (shapeName == RECTANGLE)
            {
                _shapeContainer.Add(_factory.CreateRectangle());
            }
            else if (shapeName == LINE)
            {
                _shapeContainer.Add(_factory.CreateLine());
            }
        }
    }
}
