using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Model _model;
        private int _currentButtonIndex;

        public bool[] _isbuttonChecked
        {
            get; set;
        } = new bool[3];

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
            for (int i = 0; i < _isbuttonChecked.Length; i++)
            {
                _isbuttonChecked[i] = false;
            }
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// when line buttin is clicked, except for line, all become false;
        /// </summary>
        public void ClickLineButton()
        {
            ResetAllButtonCheck();
            _isbuttonChecked[(int)ShapeIndex.Line] = true;
            _currentButtonIndex = (int)ShapeIndex.Line;
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// when line buttin is clicked, except for rectangle, all become false;
        /// </summary>
        public void ClickRectangleButton()
        {
            ResetAllButtonCheck();
            _isbuttonChecked[(int)ShapeIndex.Rectangle] = true;
            _currentButtonIndex = (int)ShapeIndex.Rectangle;
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// when line buttin is clicked, except for circle, all become false;
        /// </summary>
        public void ClickCircleButton()
        {
            ResetAllButtonCheck();
            _isbuttonChecked[(int)ShapeIndex.Circle] = true;
            _currentButtonIndex = (int)ShapeIndex.Circle;
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            Console.WriteLine("in presentation, before model");
            _model.Draw(new GraphicsAdaptor(graphics));
        }

        public void PointerPressed(double x, double y)
        {

            Console.WriteLine("click canvas, in presentation");
            _model.PointerPressed(x, y, _currentButtonIndex);
        }

        public void PointerMoved(double x, double y)
        {
            _model.PoinerMoved(x, y);
        }

        public void PointerReleased(double x, double y)
        {
            _model.PointerReleased(x, y, _currentButtonIndex);
        }
    }
}
