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
        /// Method <c>SetAllCanvasSize</c>
        /// init for all
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetAllCanvasSize(int width, int height)
        {
            _canvasWidth = width;
            _canvasHeight = height;
            _shapes.SetCanvasSize(_canvasWidth, _canvasHeight);
            _shapes._factory.SetCanvasSize(_canvasWidth, _canvasHeight);
        }

        /// <summary>
        /// Method <c>SetCanvasSize</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetCanvasSize(int width, int height)
        {
            _canvasWidth = width;
            _canvasHeight = height;
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
            _shapes.AdjustPositions(_canvasWidth, _canvasHeight);
            _shapes.SetCanvasSize(width, height);
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
