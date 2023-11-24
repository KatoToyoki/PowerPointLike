using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class ButtonModel
    {
        public enum Data
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

        private Model _model;

        public ButtonModel(Model model)
        {
            _model = model;
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
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// when line buttin is clicked, except for line, all become false;
        /// </summary>
        public void ClickLineButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)PresentationModel.ShapeIndex.Line] = true;
            _currentButtonIndex = (int)PresentationModel.ShapeIndex.Line;
            _model.ClickToolButton(index);
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// when line buttin is clicked, except for rectangle, all become false;
        /// </summary>
        public void ClickRectangleButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)PresentationModel.ShapeIndex.Rectangle] = true;
            _currentButtonIndex = (int)PresentationModel.ShapeIndex.Rectangle;
            _model.ClickToolButton(index);
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// when line buttin is clicked, except for circle, all become false;
        /// </summary>
        public void ClickCircleButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)PresentationModel.ShapeIndex.Circle] = true;
            _currentButtonIndex = (int)PresentationModel.ShapeIndex.Circle;
            _model.ClickToolButton(index);
        }

        /// <summary>
        /// Method <c>ClickMouseButton</c>
        /// when mouse buttin is clicked, except for current button, all become false;
        /// </summary>
        public void ClickMouseButton(int index)
        {
            ResetAllButtonCheck();
            _buttonChecked[(int)PresentationModel.ShapeIndex.Mouse] = true;
            _currentButtonIndex = INVALID;
        }
    }
}
