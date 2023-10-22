﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class Shapes
    {
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string CIRCLE = "圓";
        private List<Shape> _shapeContainer = new List<Shape>();
        private Factory _factory = new Factory();

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
            else if (shapeName == CIRCLE)
            {
                _shapeContainer.Add(_factory.CreateCircle());
            }
            else
            {
                return;
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
        /// Method <c>GetElementCoordinateString</c>
        /// get the formatted string of coordinate depends in index 
        /// </summary>
        /// <param name="index">the item index in a container</param>
        /// <returns>formatted string of coordinate data</returns>
        public string GetElementCoordinateString(int index)
        {
            return _shapeContainer[index].GetOneElementCoordinate();
        }

        /// <summary>
        /// Method <c>DeleteCertainElement</c>
        /// delete the certain element by index
        /// </summary>
        /// <param name="index">the wanted index</param>
        public void DeleteCertainElement(int index)
        {
            _shapeContainer.RemoveAt(index);
        }

        /// <summary>
        /// Method <c>Draw</c>
        /// to draw all instances in the container
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapeContainer)
            {
                shape.Draw(graphics);
            }
        }

        /// <summary>
        ///  Method <c>DrawShape</c>
        ///  to create a drawn shpae
        /// </summary>
        /// <param name="shapeIndex">to know which shape to draw</param>
        /// <param name="coordinateSet">to set the coordinate</param>
        public void DrawShape(int shapeIndex, CoordinateSet coordinateSet)
        {
            switch (shapeIndex)
            {
                case (int)PresentationModel.ShapeIndex.Line:
                    _shapeContainer.Add(_factory.DrawLine(coordinateSet));
                    break;
                case (int)PresentationModel.ShapeIndex.Rectangle:
                    _shapeContainer.Add(_factory.DrawRectangle(coordinateSet));
                    break;
                case (int)PresentationModel.ShapeIndex.Circle:
                    _shapeContainer.Add(_factory.DrawCircle(coordinateSet));
                    break;
            }
        }

        /// <summary>
        ///  Method <c>CreateTempShape</c>
        ///  create a shape but not added in the container
        /// </summary>
        /// <param name="shapeIndex"></param>
        /// <param name="coordinateSet"></param>
        /// <returns></returns>
        public Shape CreateTempShape(int shapeIndex, CoordinateSet coordinateSet)
        {
            switch (shapeIndex)
            {
                case (int)PresentationModel.ShapeIndex.Line:
                    return _factory.DrawLine(coordinateSet);
                case (int)PresentationModel.ShapeIndex.Rectangle:
                    return _factory.DrawRectangle(coordinateSet);
                case (int)PresentationModel.ShapeIndex.Circle:
                    return _factory.DrawCircle(coordinateSet);
            }
            return null;
        }
    }
}
