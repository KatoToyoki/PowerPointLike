using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{

    public partial class Shape
    {
        /// <summary>
        /// Method <c>RandomCoordinate</c>
        /// to create a random coordinate
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public Coordinate CreateRandomCoordinate(Random random)
        {
            Coordinate coordinate = new Coordinate();
            coordinate._x = random.Next(MAX_WIDTH);
            coordinate._y = random.Next(MAX_HEIGHT);

            return coordinate;
        }

        /// <summary>
        /// Method <c>InitContainer</c>
        /// to put elements in container depends on each Shape and the length
        /// </summary>
        /// <param name="length">the container length</param>
        protected void InitializeContainer(int length)
        {
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                Coordinate element = CreateRandomCoordinate(random);
                _coordinateContainer.Add(element);
            }
        }

        /// <summary>
        /// Method <c>GetOneElementData</c>
        /// get one whole element, including the name and the coordinate
        /// </summary>
        /// <returns>formatted string element data</returns>
        public string GetOneElementData()
        {
            string element = _shapeName + COMMA;
            element += GetOneElementCoordinate();
            return element;
        }

        /// <summary>
        /// Method <c>GetOneElementCoordinate</c>
        /// get one whole element, only coordinate
        /// </summary>
        /// <returns>formatted string of coordinate data</returns>
        public string GetOneElementCoordinate()
        {
            string coordinate = null;
            for (int i = 0; i < _coordinateContainer.Count; i++)
            {
                coordinate += LEFT_BRACKET + _coordinateContainer[i]._x + COMMA + _coordinateContainer[i]._y + RIGHT_BRACKET;
                if (i != _coordinateContainer.Count - 1)
                {
                    coordinate += COMMA;
                }
            }
            return coordinate;
        }
    }
}