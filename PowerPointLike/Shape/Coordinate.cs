using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace PowerPointLike
{
    public struct Coordinate
    {
        public const int QUANTITY = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordinate(int coordinateX, int coordinateY)
        {
            _x = coordinateX;
            _y = coordinateY;
        }
        public int _x
        {
            get; set;
        }
        public int _y
        {
            get; set;
        }

        /// <summary>
        /// Method <c>GetCoordinateString</c>
        /// </summary>
        /// <returns>coordinate string</returns>
        public string GetCoordinateString()
        {
            const string COORDINATE = "({0},{1})";
            return string.Format(COORDINATE, _x, _y);
        }

        /// <summary>
        /// Method <c>GetMiddlePoint</c>
        /// Thank you, Dr. Smell, for helping me with making the code more complex
        /// </summary>
        /// <param name="anotherPoint"></param>
        /// <returns></returns>
        public string GetMiddlePoint(Coordinate anotherPoint)
        {
            const string COORDINATE = "({0},{1})";
            return string.Format(COORDINATE, (_x + anotherPoint._x) / QUANTITY, (_y + anotherPoint._y) / QUANTITY);
        }

        /// <summary>
        /// Method <c>GetWidth</c>
        /// Thank you, Dr. Smell, for helping me with making the code more complex
        /// </summary>
        /// <returns>width</returns>
        public int GetWidth(Coordinate anotherPoint)
        {
            return Math.Abs(anotherPoint._x - _x);
        }

        /// <summary>
        /// Method <c>GetHeight</c>
        /// Thank you, Dr. Smell, for helping me with making the code more complex
        /// </summary>
        /// <returns>height</returns>
        public int GetHeight(Coordinate anotherPoint)
        {
            return Math.Abs(anotherPoint._y - _y);
        }

        /// <summary>
        /// Method <c>GetIfSelfXBigger</c>
        /// check if my x is bigger
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool GetIfSelfBigger(Coordinate point)
        {
            if (_x > point._x)
            {
                return true;
            }
            return false;
        }
    }

    public struct CoordinateSet
    {
        public Coordinate _point1
        {
            get; set;
        }
        public Coordinate _point2
        {
            get; set;
        }

        public const int TIDY_2 = 2;
        public const int TIDY_4 = 4;
        public const int TIDY_5 = 5;
        public const int TIDY_7 = 7;
        public const int TIDY_12 = 12;
        public const int PEN_WIDTH = 3;

        /// <summary>
        /// Method <c>GetMiddlePoint</c>
        /// </summary>
        /// <returns>the middle point of the two points</returns>
        public string GetMiddlePoint()
        {
            return _point1.GetMiddlePoint(_point2);
        }

        /// <summary>
        /// Method <c>GetCoordinateSetString</c>
        /// </summary>
        /// <returns>coordinate string of two points</returns>
        public string GetCoordinateSetString()
        {
            const string COORDINATE = "{0},{1}";
            return string.Format(COORDINATE, _point1.GetCoordinateString(), _point2.GetCoordinateString());
        }

        /// <summary>
        /// Method <c>GetWidth</c>
        /// </summary>
        /// <returns>width</returns>
        public int GetWidth()
        {
            return _point1.GetWidth(_point2);
        }

        /// <summary>
        /// Method <c>GetHeight</c>
        /// </summary>
        /// <returns>height</returns>
        public int GetHeight()
        {
            return _point1.GetHeight(_point2);
        }

        /// <summary>
        /// Method <c>GetTop</c>
        /// </summary>
        /// <returns>the y coordinate of the most top point</returns>
        public int GetTop()
        {
            return Math.Min(_point1._y, _point2._y);
        }

        /// <summary>
        /// Method <c>GetLeft</c>
        /// </summary>
        /// <returns>the x coordinate of the most left point</returns>
        public int GetLeft()
        {
            return Math.Min(_point1._x, _point2._x);
        }

        /// <summary>
        /// Method <c>GetRight</c>
        /// </summary>
        /// <returns>the x coordinate of the most right point</returns>
        public int GetRight()
        {
            return GetLeft() + GetWidth();
        }

        /// <summary>
        /// Method <c>GetLeft</c>
        /// </summary>
        /// <returns>the x coordinate of the middle</returns>
        public int GetMiddleWidth()
        {
            return GetLeft() + (GetWidth() / TIDY_2);
        }

        /// <summary>
        /// Method <c>GetLeft</c>
        /// </summary>
        /// <returns>the y coordinate of the most bottom point</returns>
        public int GetBottom()
        {
            return GetTop() + GetHeight();
        }

        /// <summary>
        /// Method <c>GetLeft</c>
        /// </summary>
        /// <returns>the y coordinate of the middle</returns>
        public int GetMiddleHeight()
        {
            return GetTop() + (GetHeight() / TIDY_2);
        }

        /// <summary>
        /// Method <c>DrawSelectFrame</c>
        /// to draw the selected frame
        /// </summary>
        /// <param name="e"></param>
        public void DrawSelectFrame(PaintEventArgs e)
        {
            DrawFrame(e);
            DrawDots(e);
        }

        /// <summary>
        /// Method <c>DrawFrame</c>
        /// to draw the framw
        /// </summary>
        /// <param name="e"></param>
        private void DrawFrame(PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red, PEN_WIDTH);
            e.Graphics.DrawRectangle(redPen, GetLeft() - TIDY_2, GetTop() - TIDY_2, GetWidth() + TIDY_4, GetHeight() + TIDY_4);
        }

        /// <summary>
        /// Method <c>DrawDots</c>
        /// to draw the 8 dots
        /// </summary>
        /// <param name="e"></param>

        private void DrawDots(PaintEventArgs e)
        {
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            int right = GetRight() - TIDY_5;
            int left = GetLeft() - TIDY_7;
            int top = GetTop() - TIDY_7;
            int bottom = GetBottom() - TIDY_7;
            int middleWidth = GetMiddleWidth() - TIDY_7;
            int middleHeight = GetMiddleHeight() - TIDY_7;
            e.Graphics.FillEllipse(grayBrush, right, top, TIDY_12, TIDY_12);
            e.Graphics.FillEllipse(grayBrush, right, middleHeight, TIDY_12, TIDY_12);
            e.Graphics.FillEllipse(grayBrush, right, bottom, TIDY_12, TIDY_12);

            e.Graphics.FillEllipse(grayBrush, left, top, TIDY_12, TIDY_12);
            e.Graphics.FillEllipse(grayBrush, left, middleHeight, TIDY_12, TIDY_12);
            e.Graphics.FillEllipse(grayBrush, left, bottom, TIDY_12, TIDY_12);

            e.Graphics.FillEllipse(grayBrush, middleWidth, top, TIDY_12, TIDY_12);
            e.Graphics.FillEllipse(grayBrush, middleWidth, bottom, TIDY_12, TIDY_12);
        }
    }
}
