using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPointLike.Shape;

namespace PowerPointLike.Model
{
    public partial class Model
    {
        /// <summary>
        /// Method <c>PrintTest</c>
        /// to print the attributes of each element in the container
        /// </summary>
        public void PrintTest()
        {
            _shapes.PrintContainer();
        }

        /// <summary>
        /// Method <c>AddItem</c>
        /// to call the factory to add new element depends on the chosen element
        /// </summary>
        /// <param name="shape"></param>
        public void AddItem(string shape)
        {
            if (shape == EMPTY_STRING)
            {
                return;
            }
            _shapes.AddShape(shape);

            // print test
            PrintTest();
        }

        /// <summary>
        /// Method <c>GetOneElement</c>
        /// get the delete button, name, and its coordinate in one time
        /// the informatiob is constructed by a string array
        /// </summary>
        /// <param name="index"></param>
        /// <returns>one element info separated in string array</returns>
        public string[] GetOneElement(int index)
        {
            string[] element = new string[DATA_ELEMENT_LENGTH];
            element[DATA_DELETE_INDEX] = DELETE;
            element[DATA_NAME_INDEX] = _shapes.GetElementName(index);
            Coordinate[] temp = _shapes.GetElementCoordinate(index);
            string coordinate = _shapes.GetElementCoordinateString(index);
            element[DATA_COORDINATE_INDEX] = coordinate;
            return element;
        }

        /// <summary>
        /// Method <c>GetContainerLength</c>
        /// to get the shapes container's length
        /// </summary>
        /// <returns>the length of shapes container</returns>
        public int GetContainerLength()
        {
            return _shapes.GetContainerLength();
        }

        /// <summary>
        /// Method <c>GetCurrentElement</c>
        /// to get the current(last) element
        /// </summary>
        /// <returns>the current element, which is a string array contains delete, name, coordinate</returns>
        public string[] GetCurrentElement()
        {
            return GetOneElement(_shapes.GetContainerLength() - 1);
        }
    }
}
