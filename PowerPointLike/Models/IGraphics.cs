using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    interface IGraphics
    {
        void DrawLine(Coordinate point1, Coordinate point2);
    }
}
