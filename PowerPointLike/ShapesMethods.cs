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
                // temp = _shapeContainer[i].GetCoordinate();
                // const string informationTemplate = "{NAME}, ({TOP_LEFT_X},{TOP_LEFT_Y}),({BOTTOM_RIGHT_X},{BOTTOM_RIGHT_Y})";
                // string information = string.Format("{NAME}, ({TOP_LEFT_X},{TOP_LEFT_Y}),({BOTTOM_RIGHT_X},{BOTTOM_RIGHT_Y})", _shapeContainer[i]._shapeName, temp[0]._x, temp[0]._y, temp[1]._x, temp[1]._y);
                // string information = string.Format(INFORMATION_TEMPLATE, _shapeContainer[i]._shapeName, temp[0]._x, temp[0]._y, temp[1]._x, temp[1]._y);
                // string printResult = _shapeContainer[i]._shapeName + COMMA + LEFT_BRACKET + temp[0]._x + LEFT_BRACKET + temp[0]._y + RIGHT_BRACKET + COMMA + LEFT_BRACKET + temp[1]._x + COMMA + temp[1]._y + RIGHT_BRACKET;

                Console.WriteLine(_shapeContainer[i].GetOneElementData());
            }
        }

        /// <summary>
        /// Method <c>GetElementName</c>
        /// the getter of the shape's name
        /// </summary>
        /// <param name="index"></param>
        /// <returns>the name of the shape</returns>
        public string GetElementName(int index)
        {
            return _shapeContainer[index]._shapeName;
        }

        /// <summary>
        /// Method <c>GetElementCoordinate</c>
        /// the getter of the two position: top-left and bottom-right positions
        /// </summary>
        /// <param name="index"></param>
        /// <returns>top-left and bottom-right coordinate</returns>
        public Coordinate[] GetElementCoordinate(int index)
        {
            return _shapeContainer[index].GetCoordinate();
        }

        /// <summary>
        /// Method <c>GetElementCoordinateString</c>
        /// get the formatted string of coordinate depends in index 
        /// </summary>
        /// <param name="index">the item index in a container</param>
        /// <returns>formatted string of coordinate data</returns>
        public string GetElementCoordinateString(int index)
        {
            return _shapeContainer[index].GetOneElementCoordinate();
        }
    }
}
