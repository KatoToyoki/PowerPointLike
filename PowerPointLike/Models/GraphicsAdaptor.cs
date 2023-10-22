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

        public GraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void DrawLine(CoordinateSet coordinateSet)
        {
            _graphics.DrawLine(_pen, coordinateSet._point1._x, coordinateSet._point1._y, coordinateSet._point2._x, coordinateSet._point2._y);
        }

        public void DrawRectangle(CoordinateSet coordinateSet)
        {
            _graphics.DrawRectangle(_pen, coordinateSet._point1._x, coordinateSet._point1._y, coordinateSet._point2._x, coordinateSet._point2._y);
        }

        public void DrawCircle(CoordinateSet coordinateSet)
        {
            _graphics.DrawEllipse(_pen, coordinateSet._point1._x, coordinateSet._point1._y, coordinateSet._point2._x, coordinateSet._point2._y);
        }
    }
}
