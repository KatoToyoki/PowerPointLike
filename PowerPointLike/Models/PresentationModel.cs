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
        public enum ShapeIndex
        {
            Line,
            Rectangle,
            Circle,
            Mouse
        }

        public Model _model
        {
            get; set;
        }

        public ButtonModel _buttonModel
        {
            get; set;
        }

        public DataModel _dataModel
        {
            get; set;
        }

        public StateModel _stateModel
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationModel"/> class.
        /// </summary>
        /// <param name="model">the member model</param>
        public PresentationModel(Model model)
        {
            _model = model;
            _buttonModel = new ButtonModel(_model);
            _dataModel = new DataModel(_model);
            _stateModel = new StateModel(_model, _buttonModel);
            ResetAllButtonCheck();
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
        /// Method <c>ClickKey</c> 
        /// to deal with keyin
        /// </summary>
        /// <param name="e"></param>
        public void ClickKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectOne();
                ResetSelectIndex();
            }
        }

        // data ===============================================================
        /// <summary>
        /// Method <c>AddItem</c>
        /// add the assigned shape to the shape container
        /// </summary>
        /// <param name="shape">the assigned shape</param>
        public void AddItem(string shape)
        {
            _dataModel.AddItem(shape);
        }

        /// <summary>
        /// Method <c>DeleteCertainElement</c>
        /// delete the assigned element
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        public void DeleteCertainElement(int dataIndex, int deleteIndex)
        {
            _dataModel.DeleteCertainElement(dataIndex, deleteIndex);
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
            return _dataModel.GetDeleteIndex(dataIndex, deleteIndex);
        }

        /// <summary>
        /// Method <c>GetContainerLength</c>
        /// to get the shapes container's length
        /// </summary>
        /// <returns>the length of shapes container</returns>
        public int GetContainerLength()
        {
            return _dataModel.GetContainerLength();
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
            return _dataModel.GetOneElement(index);
        }

        /// <summary>
        /// Method <c>DeleteSelectOne</c>
        /// </summary>
        /// <param name="index"></param>
        public void DeleteSelectOne()
        {
            _dataModel.DeleteSelectOne();
        }

        /// <summary>
        /// Method <c>GetAllContainerData</c>
        /// </summary>
        /// <returns></returns>
        public List<string[]> GetAllContainerData()
        {
            return _dataModel.GetAllContainerData();
        }

        // state ==============================================================
        /// <summary>
        /// Method <c>ResetStateSelect</c>
        /// reset the state to select
        /// </summary>
        public void ResetStateSelect()
        {
            _stateModel.ResetStateSelect();
        }

        /// <summary>
        /// Method <c>Draw</c>
        /// let model draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            _stateModel.Draw(graphics);
        }

        /// <summary>
        /// Method <c>PressPointer</c>
        /// let model handle with PressPointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PressPointer(double coordinateX, double coordinateY)
        {
            _stateModel.PressPointer(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>MovePointer</c>
        /// let model handle with MovePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePointer(double coordinateX, double coordinateY)
        {
            _stateModel.MovePointer(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>ReleasePointer</c>
        /// let model handle with ReleasePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ReleasePointer(double coordinateX, double coordinateY)
        {
            _stateModel.ReleasePointer(coordinateX, coordinateY);
        }

        /// <summary>
        ///  Method <c>DrawIsReady</c>
        /// if the button index is not line, rectangle or circle(namely, the mouse), can't draw
        /// </summary>
        /// <returns>if the current state is for drawing</returns>
        public bool IsDrawReady()
        {
            return _stateModel.IsDrawReady();
        }

        /// <summary>
        ///  Method <c>GetCurrentStateIndex</c>
        /// </summary>
        /// <returns>current state index</returns>
        public int GetCurrentStateIndex()
        {
            return _stateModel.GetCurrentStateIndex();
        }

        /// <summary>
        /// Method <c>GetIfIsDraw</c>
        /// </summary>
        /// <returns></returns>
        public bool IsDraw()
        {
            return _stateModel.IsDraw();
        }

        /// <summary>
        /// Method <c>GetSelectedOneCoordinate</c>
        /// </summary>
        /// <returns>the selected shape's coordinate</returns>
        public CoordinateSet GetSelectedOneCoordinate()
        {
            return _stateModel.GetSelectedOneCoordinate();
        }

        /// <summary>
        /// Method <c>ResetSelectIndex</c>
        /// </summary>
        public void ResetSelectIndex()
        {
            _stateModel.ResetSelectIndex();
        }

        /// <summary>
        /// Method <c>DrawSelectFrame</c>
        /// </summary>
        /// <param name="e"></param>
        public void DrawSelectFrame(PaintEventArgs e)
        {
            _stateModel.DrawSelectFrame(e);
        }

        // button ==============================================================
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
            return _buttonModel.GetButtonChecked(index);
        }

        /// <summary>
        /// Method <c>ResetAllButtonCheck</c>
        /// reset all the button status of isCheck
        /// </summary>
        public void ResetAllButtonCheck()
        {
            _buttonModel.ResetAllButtonCheck();
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// when line buttin is clicked, except for line, all become false;
        /// </summary>
        public void ClickLineButton(int index)
        {
            _buttonModel.ClickLineButton(index);
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// when line buttin is clicked, except for rectangle, all become false;
        /// </summary>
        public void ClickRectangleButton(int index)
        {
            _buttonModel.ClickRectangleButton(index);
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// when line buttin is clicked, except for circle, all become false;
        /// </summary>
        public void ClickCircleButton(int index)
        {
            _buttonModel.ClickCircleButton(index);
        }

        /// <summary>
        /// Method <c>ClickMouseButton</c>
        /// when mouse buttin is clicked, except for current button, all become false;
        /// </summary>
        public void ClickMouseButton(int index)
        {
            _buttonModel.ClickMouseButton(index);
        }
    }
}
