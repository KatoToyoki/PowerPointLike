using System;
using System.Collections.Generic;
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
            Circle
        }
        public const int DATA_DELETE_INDEX = 0;
        public const int INVALID = -1;
        public const int LENGTH = 3;

        private Model _model;
        private int _currentButtonIndex;
        private bool[] _buttonChecked = new bool[LENGTH];

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
        ///  Method <c>GetCurrentElement</c>
        ///  to get the current shape from container
        /// </summary>
        /// <returns>the current shape element</returns>
        public string[] GetCurrentElement()
        {
            return _model.GetCurrentElement();
        }

        /// <summary>
        /// Method <c>DeleteCertainElement</c>
        /// delete the assigned element
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        public void DeleteCertainElement(int dataIndex, int deleteIndex)
        {
            if (dataIndex == DATA_DELETE_INDEX)
            {
                _model.DeleteCertainElement(deleteIndex);
            }
        }

        /// <summary>
        /// Method <c>GetDeleteIndex</c>
        /// to get at which position should the shape be deleted
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        /// <returns>the index</returns>
        public int GetDeleteIndex(int dataIndex, int deleteIndex)
        {
            if (dataIndex == DATA_DELETE_INDEX)
            {
                return deleteIndex;
            }
            return INVALID;
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
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// when line buttin is clicked, except for line, all become false;
        /// </summary>
        public void ClickLineButton()
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Line] = true;
            _currentButtonIndex = (int)ShapeIndex.Line;
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// when line buttin is clicked, except for rectangle, all become false;
        /// </summary>
        public void ClickRectangleButton()
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Rectangle] = true;
            _currentButtonIndex = (int)ShapeIndex.Rectangle;
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// when line buttin is clicked, except for circle, all become false;
        /// </summary>
        public void ClickCircleButton()
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)ShapeIndex.Circle] = true;
            _currentButtonIndex = (int)ShapeIndex.Circle;
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
            _model.MovePointer(coordinateX, coordinateY);
        }

        /// <summary>
        /// Method <c>ReleasePointer</c>
        /// let model handle with ReleasePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ReleasePointer(double coordinateX, double coordinateY)
        {
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
    }
}
