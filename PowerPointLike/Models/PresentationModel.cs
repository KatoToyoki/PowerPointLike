using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPointLike.Models;

namespace PowerPointLike
{
    public class PresentationModel
    {
        // button(view) ================================================================
        // ControlViewButton _controlViewButton = new ControlViewButton();
        enum Data
        {
            DataDeleteIndex,
            DataNameIndex,
            DataCoordinateIndex
        }
        public int _currentButtonIndex
        {
            get; set;
        }
        public const int DATA_DELETE_INDEX = 0;
        public const int INVALID = -1;
        public const int LENGTH = 4;
        private bool[] _buttonChecked = new bool[LENGTH];

        /// <summary>
        /// Method <c>GetbuttonChecked</c>
        /// thank you, dr.smell, for not letting me use the new syntax
        /// I originally didn't have to do this, thanks A LOT :))))
        /// public bool[] _buttonChecked{
        /// get; set;
        /// }= new bool[3];
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetButtonChecked(int index)
        {
            return _buttonChecked[index];
            // return _controlViewButton.GetButtonChecked(index);
        }

        /// <summary>
        /// Method <c>GetDeleteIndex</c>
        /// to get at which position should the shape be deleted
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        /// <returns>the index</returns>
        public int? GetDeleteIndex(int dataIndex, int deleteIndex)
        {
            if (dataIndex == DATA_DELETE_INDEX)
            {
                return deleteIndex;
            }
            return null;
            // return _controlViewButton.GetDeleteIndex(dataIndex, deleteIndex);
        }

        /// <summary>
        /// Method <c>ResetAllButtonCheck</c>
        /// reset all the button status of isCheck
        /// </summary>
        public void ResetAllButtonCheck()
        {
            for (int i = 0; i < _buttonChecked.Length; i++)
            {
                _buttonChecked[i] = false;
            }
            _currentButtonIndex = INVALID;
            // _controlViewButton.ResetAllButtonCheck();
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// when line buttin is clicked, except for line, all become false;
        /// </summary>
        public void ClickLineButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Line] = true;
            _currentButtonIndex = (int)ShapeIndex.Line;
            _model.ClickToolButton(index);
            // _controlViewButton.ClickLineButton(index);
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// when line buttin is clicked, except for rectangle, all become false;
        /// </summary>
        public void ClickRectangleButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Rectangle] = true;
            _currentButtonIndex = (int)ShapeIndex.Rectangle;
            _model.ClickToolButton(index);

            // _controlViewButton.ClickRectangleButton(index);
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// when line buttin is clicked, except for circle, all become false;
        /// </summary>
        public void ClickCircleButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Circle] = true;
            _currentButtonIndex = (int)ShapeIndex.Circle;
            _model.ClickToolButton(index);

            // _controlViewButton.ClickCircleButton(index);
        }

        /// <summary>
        /// Method <c>ClickMouseButton</c>
        /// when mouse buttin is clicked, except for current button, all become false;
        /// </summary>
        public void ClickMouseButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Mouse] = true;
            _currentButtonIndex = INVALID;
            // _controlViewButton.ClickMouseButton(index);
        }

        // presentation model ================================================================
        public enum ShapeIndex
        {
            Line,
            Rectangle,
            Circle,
            Mouse
        }

        private Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationModel"/> class.
        /// </summary>
        /// <param name="model">the member model</param>
        public PresentationModel(Model model)
        {
            _model = model;
            ResetAllButtonCheck();
        }

        /// <summary>
        /// Method <c>AddItem</c>
        /// add the assigned shape to the shape container
        /// </summary>
        /// <param name="shape">the assigned shape</param>
        public void AddItem(string shape)
        {
            _model.AddItem(shape);
        }

        /// <summary>
        /// Method <c>DeleteCertainElement</c>
        /// delete the assigned element
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        public void DeleteCertainElement(int dataIndex, int deleteIndex)
        {
            // if (dataIndex == (int)_controlViewButton.DATA_DELETE_INDEX)
            if (dataIndex == (int)DATA_DELETE_INDEX)
            {
                _model.DeleteCertainElement(deleteIndex);
            }
        }

        /// <summary>
        /// Method <c>SetStateSelect</c>
        /// reset the state to select
        /// </summary>
        public void SetStateSelect()
        {
            // _model.ClickToolButton(_controlViewButton.INVALID);
            _model.ClickToolButton(INVALID);
        }

        /// <summary>
        /// Method <c>Draw</c>
        /// let model draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new GraphicsAdaptor(graphics));
        }

        /// <summary>
        /// Method <c>PressPointer</c>
        /// let model handle with PressPointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PressPointer(double coordinateX, double coordinateY)
        {
            if (!DrawIsReady() && _model.GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return;
            }
            // _model.PressPointer(coordinateX, coordinateY, _controlViewButton._currentButtonIndex);
            _model.PressPointer(coordinateX, coordinateY, _currentButtonIndex);
        }

        /// <summary>
        /// Method <c>MovePointer</c>
        /// let model handle with MovePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePointer(double coordinateX, double coordinateY)
        {
            if (!DrawIsReady() && _model.GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return;
            }
            // _model.MovePointer(coordinateX, coordinateY, _controlViewButton._currentButtonIndex);
            _model.MovePointer(coordinateX, coordinateY, _currentButtonIndex);
        }

        /// <summary>
        /// Method <c>ReleasePointer</c>
        /// let model handle with ReleasePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ReleasePointer(double coordinateX, double coordinateY)
        {
            if (!DrawIsReady() && _model.GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return;
            }
            // _model.ReleasePointer(coordinateX, coordinateY, _controlViewButton._currentButtonIndex);
            _model.ReleasePointer(coordinateX, coordinateY, _currentButtonIndex);
        }

        /// <summary>
        ///  Method <c>GetModelEvent</c>
        /// in order to get _modelChanged
        /// </summary>
        /// <returns></returns>
        public Model GetModelEvent()
        {
            return _model;
        }

        /// <summary>
        ///  Method <c>DrawIsReady</c>
        /// if the button index is not line, rectangle or circle(namely, the mouse), can't draw
        /// </summary>
        /// <returns>if the current state is for drawing</returns>
        public bool DrawIsReady()
        {
            if (_currentButtonIndex == INVALID)
            {
                return false;
            }
            return true;
            // return _controlViewButton.DrawIsReady();
        }

        /// <summary>
        ///  Method <c>GetCurrentStateIndex</c>
        /// </summary>
        /// <returns>current state index</returns>
        public int GetCurrentStateIndex()
        {
            return _model.GetCurrentStateIndex();
        }

        /// <summary>
        /// Method <c>GetIfIsDraw</c>
        /// </summary>
        /// <returns></returns>
        public bool GetIfIsDraw()
        {
            if (GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method <c>GetSelectIndex</c>
        /// </summary>
        /// <returns>the selected shape's index in the container</returns>
        public int? GetSelectIndex()
        {
            return _model.GetSelectIndex();
        }

        /// <summary>
        /// Method <c>GetSelectedOneCoordinate</c>
        /// </summary>
        /// <returns>the selected shape's coordinate</returns>
        public CoordinateSet GetSelectedOneCoordinate()
        {
            return _model.GetSelectedOneCoordinate();
        }

        /// <summary>
        /// Method <c>ResetSelectIndex</c>
        /// </summary>
        public void ResetSelectIndex()
        {
            _model.ResetSelectIndex();
        }

        /// <summary>
        /// Method <c>GetContainerLength</c>
        /// to get the shapes container's length
        /// </summary>
        /// <returns>the length of shapes container</returns>
        public int GetContainerLength()
        {
            return _model.GetContainerLength();
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
            return _model.GetOneElement(index);
        }

        /// <summary>
        /// Method <c>DeleteSelectOne</c>
        /// </summary>
        /// <param name="index"></param>
        public void DeleteSelectOne()
        {
            _model.DeleteSelectOne();
        }

        /// <summary>
        /// Method <c>GetAllContainerData</c>
        /// </summary>
        /// <returns></returns>
        public List<string[]> GetAllContainerData()
        {
            List<string[]> tableData = new List<string[]>();

            for (int i = 0; i < GetContainerLength(); i++)
            {
                string[] element = GetOneElement(i);
                tableData.Add(new string[] { element[(int)Data.DataDeleteIndex], element[(int)Data.DataNameIndex], element[(int)Data.DataCoordinateIndex] });
            }

            return tableData;
            // return _controlViewButton.GetAllContainerData();
        }
    }
}
