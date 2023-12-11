using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public partial class Model
    {
        /// <summary>
        /// Method <c>InitialCanvasSize</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void InitialCanvasSize(int width, int height)
        {
            _oldCanvasWidth = width;
            _oldCanvasHeight = height;
            _newCanvasWidth = width;
            _newCanvasHeight = height;
            _shapes.SetCanvasSize(width, height);
            _shapes._factory.SetCanvasSize(width, height);
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
            _shapes.SetCanvasSize(width, height);
            _shapes._factory.SetCanvasSize(width, height);
        }

        /// <summary>
        /// Method <c>ChangeCanvasSize</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void ChangeCanvasSize(int width, int height)
        {
            SetCanvasSize(width, height);
            _shapes.AdjustPositions();
            _commandManager.AdjustPositions();
        }

        /// <summary>
        /// Method <c>GetFactorX</c>
        /// </summary>
        /// <returns></returns>
        public double GetFactorX()
        {
            return (double)_newCanvasWidth / _oldCanvasWidth;
        }

        /// <summary>
        /// Method <c>GetFactorX</c>
        /// </summary>
        /// <returns></returns>
        public double GetFactorY()
        {
            return (double)_newCanvasHeight / _oldCanvasHeight;
        }

        /// <summary>
        /// Method <c>Undo</c>
        /// </summary>
        public void Undo()
        {
            _commandManager.Undo();
        }

        /// <summary>
        /// Method <c>Redo</c>
        /// </summary>
        public void Redo()
        {
            _commandManager.Redo();
        }
    }
}
