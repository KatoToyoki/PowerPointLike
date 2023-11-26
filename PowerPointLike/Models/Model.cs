﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public class Model
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        enum Data
        {
            DataDeleteIndex,
            DataNameIndex,
            DataCoordinateIndex,
            DataElementLength
        }
        public const string EMPTY_STRING = "";
        public const string DELETE = "刪除";

        public Shapes _shapes
        {
            get; set;
        }
        public State _state
        {
            get; set;
        }

        public CoordinateSet _selectedOneCoordinate
        {
            get; set;
        }

        public Model()
        {
            _shapes = new Shapes();
            _state = new PointState(_shapes);
        }

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
            NotifyModelChanged();

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
            string[] element = new string[(int)Data.DataElementLength];
            element[(int)Data.DataDeleteIndex] = DELETE;
            element[(int)Data.DataNameIndex] = _shapes.GetElementName(index);
            string coordinate = _shapes.GetElementCoordinateString(index);
            element[(int)Data.DataCoordinateIndex] = coordinate;
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
        /// Method <c>DeleteCertainElement</c>
        /// </summary>
        /// <param name="index">the wanted index</param>
        public void DeleteCertainElement(int index)
        {
            _shapes.DeleteCertainElement(index);
            NotifyModelChanged();
        }

        /// <summary>
        /// Method <c>Draw</c>
        /// to draw all instances
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);
        }

        /// <summary>
        /// Method <c>CheckInputValid</c>
        /// to check if it's invalid
        /// </summary>
        /// <param name="x">the x of the coordinate</param>
        /// <param name="y">the y of the coordinate</param>
        /// <returns></returns>
        public bool CheckInputValid(double coordinateX, double coordinateY)
        {
            if (coordinateX > 0 && coordinateY > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Method <c>PressPointer</c>
        ///  when first point is pressed
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shapeIndex">to know which shape to draw</param>
        public void PressPointer(double coordinateX, double coordinateY, int shapeIndex)
        {
            if (!CheckInputValid(coordinateX, coordinateY))
            {
                return;
            }
            CoordinateSet selectedOne = new CoordinateSet(new Coordinate(0, 0), new Coordinate(0, 0));
            _state.HandleCanvasPressed(coordinateX, coordinateY, shapeIndex, out selectedOne);
            _selectedOneCoordinate = selectedOne;
            Console.WriteLine("---in model!! outer!!! " + _selectedOneCoordinate.GetCoordinateSetString());
        }

        /// <summary>
        ///  Method <c>MovePointer</c>
        ///  while moving
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePointer(double coordinateX, double coordinateY, int shapeIndex)
        {

            CoordinateSet selectedOne = new CoordinateSet(new Coordinate(0, 0), new Coordinate(0, 0));
            _state.HandleCanvasMoved(coordinateX, coordinateY, shapeIndex, out selectedOne);
            _selectedOneCoordinate = selectedOne;

            if (_state._isPressed)
            {
                NotifyModelChanged();
            }
        }

        /// <summary>
        ///  Method <c>ReleasePointer</c>
        ///  when released
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shapeIndex">to know which shape to draw</param>
        public void ReleasePointer(double coordinateX, double coordinateY, int shapeIndex)
        {

            CoordinateSet selectedOne = new CoordinateSet(new Coordinate(0, 0), new Coordinate(0, 0));
            _state.HandleCanvasReleased(coordinateX, coordinateY, shapeIndex, out selectedOne);
            _selectedOneCoordinate = selectedOne;
            Console.WriteLine("release have some problem LOCAl MY" + selectedOne.GetCoordinateSetString() + " " + _selectedOneCoordinate.GetCoordinateSetString());

            if (_state._isPressed)
            {
                NotifyModelChanged();
            }
            _state._isPressed = false;

            Console.WriteLine("the select item should exist " + _selectedOneCoordinate.GetCoordinateSetString());
        }

        /// <summary>
        /// Method <c>NotifyModelChanged</c>
        /// model is changing
        /// </summary>
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        /// <summary>
        /// Method <c>ClickToolButton</c> 
        /// update current state index when the button is clicked
        /// </summary>
        /// <param name="index"></param>
        public void ClickToolButton(int index)
        {
            _state = _state.CreateState(index, _shapes);
        }

        /// <summary>
        ///  Method <c>GetCurrentStateIndex</c>
        /// </summary>
        /// <returns>current state index</returns>
        public int GetCurrentStateIndex()
        {
            return _state._currentStateIndex;
        }

        /// <summary>
        /// Method <c>GetSelectIndex</c>
        /// </summary>
        /// <returns>the selected shape's index in the container</returns>
        public int? GetSelectIndex()
        {
            if (_state._index == State.INVALID || GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return null;
            }
            return _state._index;
        }

        /// <summary>
        /// Method <c>GetSelectedOneCoordinate</c>
        /// </summary>
        /// <returns>the selected shape's coordinate</returns>
        public CoordinateSet GetSelectedOneCoordinate()
        {
            return _state._selectedOneCoordinate;
        }

        /// <summary>
        /// Method <c>ResetSelectIndex</c>
        /// </summary>
        public void ResetSelectIndex()
        {
            _state.ResetSelectIndex();
        }

        /// <summary>
        /// Method <c>DeleteSelectOne</c>
        /// </summary>
        /// <param name="index"></param>
        public void DeleteSelectOne()
        {
            if (GetSelectIndex() == null)
            {
                return;
            }
            _shapes.DeleteCertainElement((int)GetSelectIndex());
        }

        /// <summary>
        /// Method <c>ExistInContainer</c>
        /// to check if the item is exist
        /// </summary>
        /// <param name="coordinateSet"></param>
        /// <returns></returns>
        public bool ExistInContainer(CoordinateSet coordinateSet)
        {
            return _shapes.ExistInContainer(coordinateSet);
        }
    }
}