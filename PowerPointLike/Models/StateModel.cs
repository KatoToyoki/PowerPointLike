using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public class StateModel
    {
        private Model _model;
        private ButtonModel _buttonModel;

        public StateModel(Model model, ButtonModel buttonModel)
        {
            _model = model;
            _buttonModel = buttonModel;
        }

        // state ========================================
        /// <summary>
        /// Method <c>ResetStateSelect</c>
        /// reset the state to select
        /// </summary>
        public void ResetStateSelect()
        {
            _model.ClickToolButton(ButtonModel.INVALID);
        }

        /// <summary>
        /// Method <c>PressPointer</c>
        /// let model handle with PressPointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PressPointer(double coordinateX, double coordinateY, Cursor cursor)
        {
            if (!IsDrawReady() && _model.GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return;
            }
            // check if is around right bottom
            _model.PressPointer(coordinateX, coordinateY, _buttonModel._currentButtonIndex);
        }

        /// <summary>
        /// Method <c>MovePointer</c>
        /// let model handle with MovePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MovePointer(double coordinateX, double coordinateY)
        {
            if (!IsDrawReady() && _model.GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return;
            }
            _model.MovePointer(coordinateX, coordinateY, _buttonModel._currentButtonIndex);
        }

        /// <summary>
        /// Method <c>ReleasePointer</c>
        /// let model handle with ReleasePointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ReleasePointer(double coordinateX, double coordinateY)
        {
            if (!IsDrawReady() && _model.GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return;
            }
            _model.ReleasePointer(coordinateX, coordinateY, _buttonModel._currentButtonIndex);
        }

        // draw =========================================
        /// <summary>
        /// Method <c>Draw</c>
        /// let model draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            _model.Draw(graphics);
        }

        /// <summary>
        ///  Method <c>DrawIsReady</c>
        /// if the button index is not line, rectangle or circle(namely, the mouse), can't draw
        /// </summary>
        /// <returns>if the current state is for drawing</returns>
        public bool IsDrawReady()
        {
            if (_buttonModel._currentButtonIndex == State.INVALID)
            {
                return false;
            }
            return true;
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
        public bool IsDraw()
        {
            if (GetCurrentStateIndex() == (int)State.StateIndex.Draw)
            {
                return true;
            }
            return false;
        }

        // select =======================================
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
        /// Method <c>DrawSelectFrame</c>
        /// </summary>
        /// <param name="e"></param>
        public void DrawSelectFrame(PaintEventArgs e)
        {
            CoordinateSet selectedOne = GetSelectedOneCoordinate();
            if (_model.ExistInContainer(selectedOne))
            {
                selectedOne.DrawSelectFrame(e);
            }
        }
    }
}
