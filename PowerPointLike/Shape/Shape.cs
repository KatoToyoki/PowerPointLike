﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPointLike.Models;

namespace PowerPointLike
{
    public abstract class Shape
    {
        public Factory _factory
        {
            get; set;
        }
        public string _shapeName
        {
            get; set;
        }

        public CoordinateSet _coordinateSet
        {
            get; set;
        }

        public int _id
        {
            get; set;
        }

        /// <summary>
        /// Method <c>GetOneElementData</c>
        /// get one whole element, including the name and the coordinate
        /// </summary>
        /// <returns>formatted string element data</returns>
        public virtual string GetOneElementData()
        {
            return _shapeName + _coordinateSet.GetCoordinateSetString();
        }

        /// <summary>
        /// Method <c>GetOneElementCoordinate</c>
        /// get one whole element, only coordinate
        /// </summary>
        /// <returns>formatted string of coordinate data</returns>
        public virtual string GetOneElementCoordinate()
        {
            return _coordinateSet.GetCoordinateSetString();
        }

        /// <summary>
        ///  Method <c>Draw</c>
        ///  implemented by the derived class
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(IGraphics graphics);

        /// <summary>
        ///  Method <c>GetCoordinateSet</c>
        /// </summary>
        /// <returns>CoordinateSet</returns>
        public CoordinateSet GetCoordinateSet()
        {
            return _coordinateSet;
        }

        /// <summary>
        ///  Method <c>SetCoordinate</c>
        /// </summary>
        /// <param name="set"></param>
        public void SetCoordinate(CoordinateSet set)
        {
            _coordinateSet = set;
        }

        /// <summary>
        /// Method <c>GetClone</c>
        /// </summary>
        /// <returns></returns>
        public abstract Shape GetClone();

        /// <summary>
        /// Method <c>AdjustPosition</c>
        /// </summary>
        /// <param name="factorX"></param>
        /// <param name="factorY"></param>
        public void AdjustPosition(double factorX, double factorY)
        {
            CoordinateSet currentItem = this._coordinateSet;
            int newX1 = (int)(currentItem._point1._x * factorX);
            int newY1 = (int)(currentItem._point1._y * factorY);
            int newX2 = (int)(currentItem._point2._x * factorX);
            int newY2 = (int)(currentItem._point2._y * factorY);

            this._coordinateSet = new CoordinateSet(new Coordinate(newX1, newY1), new Coordinate(newX2, newY2));
        }
    }
}