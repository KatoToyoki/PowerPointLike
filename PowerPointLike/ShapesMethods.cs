using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAlias = PowerPointLike.Shape;
using RectangleAlias = PowerPointLike.Rectangle;
using LineAlias = PowerPointLike.Line;
using PowerPointLike.Shape;

namespace PowerPointLike.Shapes
{
    public partial class Shapes
    {
        /// <summary>
        /// Method <c>AddShape</c>
        /// to create new element depends on the chosen element
        /// </summary>
        /// <param name="shapeName">to decide which element will be create</param>
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

        /// <summary>
        /// Method <c>GetContainerLength</c>
        /// to get the length of the container's length
        /// </summary>
        /// <returns>the length of the container's length</returns>
        public int GetContainerLength()
        {
            return _shapeContainer.Count;
        }

        /// <summary>
        /// Method <c>PrintContainer</c>
        /// print each element in the container
        /// </summary>
        public void PrintContainer()
        {
            for (int i = 0; i < _shapeContainer.Count; i++)
            {
                Coordinate[] temp = new Coordinate[ShapeAlias.Shape.COORDINATE_LENGTH];
                temp = _shapeContainer[i].GetCooderinate();
                string information = string.Format("{0}, ({1},{2}),({3},{4})", _shapeContainer[i]._shapeName, temp[0]._x, temp[0]._y, temp[1]._x, temp[1]._y);
                Console.WriteLine(information);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetElementName(int index)
        {
            return _shapeContainer[index]._shapeName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Coordinate[] GetElementCoordinate(int index)
        {
            return _shapeContainer[index].GetCooderinate();
        }
    }
}
