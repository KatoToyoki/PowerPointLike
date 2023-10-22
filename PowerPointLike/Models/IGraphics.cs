using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public interface IGraphics
    {
        /// <summary>
        /// Method <c>DrawLine</c>
        /// to draw Line
        /// </summary>
        /// <param name="coordinateSet">the two coordinates of the shape</param>
        void DrawLine(CoordinateSet coordinateSet);

        /// <summary>
        /// Method <c>Rectangle</c>
        /// to draw Rectangle
        /// </summary>
        /// <param name="coordinateSet">the two coordinates of the shape</param>
        void DrawRectangle(CoordinateSet coordinateSet);

        /// <summary>
        /// Method <c>DrawCircle</c>
        /// to draw Circle
        /// </summary>
        /// <param name="coordinateSet">the two coordinates of the shape</param>
        void DrawCircle(CoordinateSet coordinateSet);
    }
}
