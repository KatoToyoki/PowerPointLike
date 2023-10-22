using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public interface IGraphics
    {
        void DrawLine(CoordinateSet coordinateSet);
        void DrawRectangle(CoordinateSet coordinateSet);
        void DrawCircle(CoordinateSet coordinateSet);
    }
}
