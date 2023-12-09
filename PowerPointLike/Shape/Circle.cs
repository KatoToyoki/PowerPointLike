﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Circle : Shape
    {
        public const string CIRCLE = "圓";

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle(CoordinateSet coordinateSet, Factory factory)
        {
            _shapeName = CIRCLE;
            _coordinateSet = coordinateSet;
            _factory = factory;
        }

        /// <summary>
        ///  Method <c>Draw</c>
        ///  to draw circle
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_coordinateSet);
        }

        public override Shape Clone()
        {
            // return new Circle(_coordinateSet.Clone());
            Shape newOne = _factory.CreateCircle();
            newOne._coordinateSet = this._coordinateSet.Clone();
            return newOne;
        }
    }
}
