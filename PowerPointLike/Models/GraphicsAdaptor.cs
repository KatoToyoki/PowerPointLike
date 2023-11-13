using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike.Models
{
    class GraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        Pen _pen = new Pen(Brushes.Black);

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicAdaptor"/> class.
        /// </summary>
        /// <param name="model"></param>
        public GraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// Method <c>DrawLine</c>
        /// implement the methods of IGraphic interface
        /// </summary>
        /// <param name="coordinateSet">the two coordinates</param>
        public void DrawLine(CoordinateSet coordinateSet)
        {
            _graphics.DrawLine(_pen, coordinateSet._point1._x, coordinateSet._point1._y, coordinateSet._point2._x, coordinateSet._point2._y);
        }

        /// <summary>
        /// Method <c>DrawRectangle</c>
        /// implement the methods of IGraphic interface
        /// </summary>
        /// <param name="coordinateSet">the two coordinates</param>
        public void DrawRectangle(CoordinateSet coordinateSet)
        {
            _graphics.DrawRectangle(_pen, coordinateSet.GetLeft(), coordinateSet.GetTop(), coordinateSet.GetWidth(), coordinateSet.GetHeight());
        }

        /// <summary>
        /// Method <c>DrawCircle</c>
        /// implement the methods of IGraphic interface
        /// </summary>
        /// <param name="coordinateSet">the two coordinates</param>
        public void DrawCircle(CoordinateSet coordinateSet)
        {
            _graphics.DrawEllipse(_pen, coordinateSet.GetLeft(), coordinateSet.GetTop(), coordinateSet.GetWidth(), coordinateSet.GetHeight());
        }
    }
}
