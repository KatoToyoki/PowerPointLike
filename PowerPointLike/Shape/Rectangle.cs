﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Rectangle : Shape
    {
        public const string RECTANGLE = "矩形";

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle(CoordinateSet coordinateSet, Factory factory)
        {
            _shapeName = RECTANGLE;
            _coordinateSet = coordinateSet;
            _factory = factory;
        }

        /// <summary>
        ///  Method <c>Draw</c>
        ///  to draw rectangle
        /// </summary>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_coordinateSet);
        }

        /// <summary>
        /// Method <c>GetClone</c>
        /// </summary>
        /// <returns></returns>
        public override Shape GetClone()
        {
            Shape newOne = _factory.CreateRectangle();
            newOne._coordinateSet = this._coordinateSet.GetClone();
            return newOne;
        }
    }
}
