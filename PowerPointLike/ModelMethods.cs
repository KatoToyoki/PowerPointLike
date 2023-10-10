using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _shapes.AddShape(shape);
        }
    }
}
