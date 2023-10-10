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

            // string information = string.Format("{0}, ({1},{2}),({3},{4})", _shapeContainer[i]._shapeName, temp[0]._x, temp[0]._y, temp[1]._x, temp[1]._y);
            // Console.WriteLine(information);

            PrintTest();
        }

        public string[] GetOneElement(int index)
        {
            string[] element = new string[3];
            element[0] = DELETE;
            element[1] = _shapes.GetElementName(index);
            Coordinate[] temp = _shapes.GetElementCoordinate(index);
            string coordinate = string.Format("({0},{1}),({2},{3})", temp[0]._x, temp[0]._y, temp[1]._x, temp[1]._y);
            element[2] = coordinate;

            return element;
        }

        public int GetContainerLength()
        {
            return _shapes.GetContainerLength();
        }
    }
}
