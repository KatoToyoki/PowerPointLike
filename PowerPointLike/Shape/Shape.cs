using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPointLike.Models;

namespace PowerPointLike
{
    public abstract class Shape
    {
        public string _shapeName
        {
            get; set;
        }

        public CoordinateSet _coordinateSet
        {
            get; set;
        } = new CoordinateSet();

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

        public void SetCoordinate(CoordinateSet set)
        {
            _coordinateSet = set;
        }
    }
}