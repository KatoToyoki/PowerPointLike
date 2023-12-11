using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class Shapes
    {
        /// <summary>
        /// Method <c>ScaleCoordinate</c>
        /// to set new Coordinate
        /// </summary>
        /// <param name="index"></param>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void ScaleCoordinate(int index, double coordinateX, double coordinateY)
        {
            if (_shapeContainer.Count == 0)
            {
                return;
            }
            if (index == State.INVALID)
            {
                return;
            }
            _shapeContainer[index].SetCoordinate(_shapeContainer[index]._coordinateSet.ScaleOffset((int)coordinateX, (int)coordinateY));
        }

        /// <summary>
        /// Method <c>ExistInContainer</c>
        /// to check if the item is exist
        /// </summary>
        /// <param name="coordinateSet"></param>
        /// <returns></returns>
        public bool ExistInContainer(CoordinateSet coordinateSet)
        {
            foreach (Shape shape in _shapeContainer)
            {
                if (shape._coordinateSet.GetIfIsSame(coordinateSet))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method <c>AdjustPositions</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void AdjustPositions()
        {
            double factorX = ((double)_newCanvasWidth / _oldCanvasWidth);
            double factorY = ((double)_newCanvasHeight / _oldCanvasHeight);

            foreach (var shape in _shapeContainer)
            {
                shape.AdjustPosition(factorX, factorY);
            }
        }

        /// <summary>
        /// Method <c>SetCanvasSize</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetCanvasSize(int width, int height)
        {
            _oldCanvasWidth = _newCanvasWidth;
            _oldCanvasHeight = _newCanvasHeight;
            _newCanvasWidth = width;
            _newCanvasHeight = height;
        }

        /// <summary>
        /// Method <c>ExchangeShape</c>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="shape"></param>
        public void ExchangeShape(Shape oldOne, Shape newOne)
        {
            List<int> index = new List<int>();
            for (int i = 0; i < _shapeContainer.Count; i++)
            {
                if (_shapeContainer[i]._coordinateSet.IsCoordinateSetSame(oldOne))
                {
                    index.Add(i);
                }
            }

            for (int i = 0; i < index.Count; i++)
            {
                _shapeContainer[index[i]] = newOne.GetClone();
            }
        }

        /// <summary>
        /// Method <c>CloneAndReplace</c>
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        /// <returns></returns>
        public Shape CloneAndReplace(double coordinateX, double coordinateY)
        {
            int index = (int)GetIndex(coordinateX, coordinateY);

            Shape originalShape = _shapeContainer[index];
            Shape clonedShape = originalShape.GetClone();

            _shapeContainer.RemoveAt(index);
            _shapeContainer.Insert(index, clonedShape);

            return clonedShape;
        }

        /// <summary>
        /// Method <c>GetIndex</c>
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        /// <returns></returns>
        public int? GetIndex(double coordinateX, double coordinateY)
        {
            for (int i = 0; i < GetContainerLength(); i++)
            {
                CoordinateSet temp = GetShape(i).GetCoordinateSet();

                if (GetIfIsBetween(temp._point1._x, temp._point2._x, coordinateX) &&
                    GetIfIsBetween(temp._point1._y, temp._point2._y, coordinateY))
                {
                    return i;
                }
            }
            return null;
        }
    }
}
