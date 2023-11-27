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

        public Cursor _cursor
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
        // Method <c>AddItem</c>
        public void AddItem(string shape)
        {
            _dataModel.AddItem(shape);
        }

        //  Method <c>DeleteCertainElement</c>
        public void DeleteCertainElement(int dataIndex, int deleteIndex)
        {
            _dataModel.DeleteCertainElement(dataIndex, deleteIndex);
        }

        // Method <c>GetDeleteIndex</c>
        public int? GetDeleteIndex(int dataIndex, int deleteIndex)
        {
            return _dataModel.GetDeleteIndex(dataIndex, deleteIndex);
        }

        // Method <c>GetContainerLength</c>
        public int GetContainerLength()
        {
            return _dataModel.GetContainerLength();
        }

        // Method <c>GetOneElement</c>
        public string[] GetOneElement(int index)
        {
            return _dataModel.GetOneElement(index);
        }

        // Method <c>DeleteSelectOne</c>
        public void DeleteSelectOne()
        {
            _dataModel.DeleteSelectOne();
        }

        // Method <c>GetAllContainerData</c>
        public List<string[]> GetAllContainerData()
        {
            return _dataModel.GetAllContainerData();
        }

        // state ==============================================================
        // Method <c>ResetStateSelect</c>
        public void ResetStateSelect()
        {
            _stateModel.ResetStateSelect();
        }

        // Method <c>Draw</c>
        public void Draw(IGraphics graphics)
        {
            _stateModel.Draw(graphics);
        }

        // Method <c>PressPointer</c>
        public void PressPointer(double coordinateX, double coordinateY)
        {
            _stateModel.PressPointer(coordinateX, coordinateY);
        }

        // Method <c>MovePointer</c>
        public void MovePointer(double coordinateX, double coordinateY)
        {
            _stateModel.MovePointer(coordinateX, coordinateY);
        }

        // Method <c>ReleasePointer</c>
        public void ReleasePointer(double coordinateX, double coordinateY)
        {
            _stateModel.ReleasePointer(coordinateX, coordinateY);
        }

        //  Method <c>DrawIsReady</c>
        public bool IsDrawReady()
        {
            return _stateModel.IsDrawReady();
        }

        //  Method <c>GetCurrentStateIndex</c>
        public int GetCurrentStateIndex()
        {
            return _stateModel.GetCurrentStateIndex();
        }

        // Method <c>GetIfIsDraw</c>
        public bool IsDraw()
        {
            return _stateModel.IsDraw();
        }

        // Method <c>GetSelectedOneCoordinate</c>
        public CoordinateSet GetSelectedOneCoordinate()
        {
            return _stateModel.GetSelectedOneCoordinate();
        }

        // Method <c>ResetSelectIndex</c>
        public void ResetSelectIndex()
        {
            _stateModel.ResetSelectIndex();
        }

        // Method <c>DrawSelectFrame</c>
        public void DrawSelectFrame(PaintEventArgs e)
        {
            _stateModel.DrawSelectFrame(e);
        }

        /// <summary>
        /// Method <c>DetectButtonDraw</c>
        /// </summary>
        public void DetectButtonDraw()
        {
            if (_buttonModel._currentButtonIndex != ButtonModel.INVALID)
            {
                _cursor = System.Windows.Forms.Cursors.Cross;
            }
            else
            {
                _cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Method <c>DetectScale</c>
        /// </summary>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void DetectScale(double coordinateX, double coordinateY)
        {
            if (_buttonModel._currentButtonIndex != ButtonModel.INVALID)
            {
                _cursor = System.Windows.Forms.Cursors.Cross;
            }
            else if (_stateModel.IsScale(coordinateX, coordinateY))
            {
                _cursor = System.Windows.Forms.Cursors.SizeNWSE;
            }
            else
            {
                _cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        // button ==============================================================
        // Method <c>GetbuttonChecked</c>
        public bool GetButtonChecked(int index)
        {
            return _buttonModel.GetButtonChecked(index);
        }

        // Method <c>ResetAllButtonCheck</c>
        public void ResetAllButtonCheck()
        {
            _buttonModel.ResetAllButtonCheck();
        }

        // Method <c>ClickLineButton</c>
        public void ClickLineButton(int index)
        {
            _buttonModel.ClickLineButton(index);
        }

        // Method <c>ClickRectangleButton</c>
        public void ClickRectangleButton(int index)
        {
            _buttonModel.ClickRectangleButton(index);
        }

        // Method <c>ClickCircleButton</c>
        public void ClickCircleButton(int index)
        {
            _buttonModel.ClickCircleButton(index);
        }

        // Method <c>ClickMouseButton</c>
        public void ClickMouseButton(int index)
        {
            _buttonModel.ClickMouseButton(index);
        }
    }
}
