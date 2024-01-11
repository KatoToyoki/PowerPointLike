using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPointLike.Models;

namespace PowerPointLike
{
    public partial class ModalDialog : Form
    {
        Model _model;
        string _shapeName;
        int _dataIndex;
        int _deleteIndex;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shapeName"></param>
        /// <param name="dataIndex"></param>
        /// <param name="deleteIndex"></param>
        public ModalDialog(Model model, string shapeName, int dataIndex, int deleteIndex)
        {
            InitializeComponent();
            _model = model;
            _shapeName = shapeName;
            _dataIndex = dataIndex;
            _deleteIndex = deleteIndex;
        }

        /// <summary>
        /// init components
        /// </summary>
        private void InitializeComponent()
        {
            this._leftTopXValue = new System.Windows.Forms.TextBox();
            this._leftTopXLabel = new System.Windows.Forms.Label();
            this._leftTopYLabel = new System.Windows.Forms.Label();
            this._leftTopYValue = new System.Windows.Forms.TextBox();
            this._rightBottomYLabel = new System.Windows.Forms.Label();
            this._rightBottomYValue = new System.Windows.Forms.TextBox();
            this._rightBottomXLabel = new System.Windows.Forms.Label();
            this._rightBottomXValue = new System.Windows.Forms.TextBox();
            this._modalOkButton = new System.Windows.Forms.Button();
            this._modalCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _leftTopXValue
            // 
            this._leftTopXValue.Location = new System.Drawing.Point(64, 102);
            this._leftTopXValue.Name = "_leftTopXValue";
            this._leftTopXValue.Size = new System.Drawing.Size(100, 25);
            this._leftTopXValue.TabIndex = 0;
            // 
            // _leftTopXLabel
            // 
            this._leftTopXLabel.AutoSize = true;
            this._leftTopXLabel.Location = new System.Drawing.Point(61, 84);
            this._leftTopXLabel.Name = "_leftTopXLabel";
            this._leftTopXLabel.Size = new System.Drawing.Size(89, 15);
            this._leftTopXLabel.TabIndex = 1;
            this._leftTopXLabel.Text = "左上角座標x";
            // 
            // _leftTopYLabel
            // 
            this._leftTopYLabel.AutoSize = true;
            this._leftTopYLabel.Location = new System.Drawing.Point(250, 84);
            this._leftTopYLabel.Name = "_leftTopYLabel";
            this._leftTopYLabel.Size = new System.Drawing.Size(89, 15);
            this._leftTopYLabel.TabIndex = 3;
            this._leftTopYLabel.Text = "左上角座標y";
            // 
            // _leftTopYValue
            // 
            this._leftTopYValue.Location = new System.Drawing.Point(253, 102);
            this._leftTopYValue.Name = "_leftTopYValue";
            this._leftTopYValue.Size = new System.Drawing.Size(100, 25);
            this._leftTopYValue.TabIndex = 2;
            // 
            // _rightBottomYLabel
            // 
            this._rightBottomYLabel.AutoSize = true;
            this._rightBottomYLabel.Location = new System.Drawing.Point(250, 149);
            this._rightBottomYLabel.Name = "_rightBottomYLabel";
            this._rightBottomYLabel.Size = new System.Drawing.Size(89, 15);
            this._rightBottomYLabel.TabIndex = 7;
            this._rightBottomYLabel.Text = "右下角座標y";
            // 
            // _rightBottomYValue
            // 
            this._rightBottomYValue.Location = new System.Drawing.Point(253, 167);
            this._rightBottomYValue.Name = "_rightBottomYValue";
            this._rightBottomYValue.Size = new System.Drawing.Size(100, 25);
            this._rightBottomYValue.TabIndex = 6;
            // 
            // _rightBottomXLabel
            // 
            this._rightBottomXLabel.AutoSize = true;
            this._rightBottomXLabel.Location = new System.Drawing.Point(61, 149);
            this._rightBottomXLabel.Name = "_rightBottomXLabel";
            this._rightBottomXLabel.Size = new System.Drawing.Size(89, 15);
            this._rightBottomXLabel.TabIndex = 5;
            this._rightBottomXLabel.Text = "右下角座標x";
            // 
            // _rightBottomXValue
            // 
            this._rightBottomXValue.Location = new System.Drawing.Point(64, 167);
            this._rightBottomXValue.Name = "_rightBottomXValue";
            this._rightBottomXValue.Size = new System.Drawing.Size(100, 25);
            this._rightBottomXValue.TabIndex = 4;
            // 
            // _modalOkButton
            // 
            this._modalOkButton.Location = new System.Drawing.Point(64, 236);
            this._modalOkButton.Name = "_modalOkButton";
            this._modalOkButton.Size = new System.Drawing.Size(100, 40);
            this._modalOkButton.TabIndex = 8;
            this._modalOkButton.Text = "OK";
            this._modalOkButton.UseVisualStyleBackColor = true;
            this._modalOkButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // _modalCancelButton
            // 
            this._modalCancelButton.Location = new System.Drawing.Point(253, 236);
            this._modalCancelButton.Name = "_modalCancelButton";
            this._modalCancelButton.Size = new System.Drawing.Size(100, 40);
            this._modalCancelButton.TabIndex = 9;
            this._modalCancelButton.Text = "Cancel";
            this._modalCancelButton.UseVisualStyleBackColor = true;
            this._modalCancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // ModalDialog
            // 
            this.ClientSize = new System.Drawing.Size(471, 321);
            this.Controls.Add(this._modalCancelButton);
            this.Controls.Add(this._modalOkButton);
            this.Controls.Add(this._rightBottomYLabel);
            this.Controls.Add(this._rightBottomYValue);
            this.Controls.Add(this._rightBottomXLabel);
            this.Controls.Add(this._rightBottomXValue);
            this.Controls.Add(this._leftTopYLabel);
            this.Controls.Add(this._leftTopYValue);
            this.Controls.Add(this._leftTopXLabel);
            this.Controls.Add(this._leftTopXValue);
            this.Name = "ModalDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label _leftTopXLabel;
        private Label _leftTopYLabel;
        private TextBox _leftTopYValue;
        private Label _rightBottomYLabel;
        private TextBox _rightBottomYValue;
        private Label _rightBottomXLabel;
        private TextBox _rightBottomXValue;
        private Button _modalOkButton;
        private Button _modalCancelButton;
        private TextBox _leftTopXValue;


        /// <summary>
        /// click cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickCancelButton(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// click ok button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOkButton(object sender, EventArgs e)
        {
            if (AreCoordinatesValid(_leftTopXValue.Text, _leftTopYValue.Text, _rightBottomXValue.Text, _rightBottomYValue.Text))
            {
                Coordinate a = new Coordinate(Int32.Parse(_leftTopXValue.Text), Int32.Parse(_leftTopYValue.Text));
                Coordinate b = new Coordinate(Int32.Parse(_rightBottomXValue.Text), Int32.Parse(_rightBottomYValue.Text));
                CoordinateSet newSet = new CoordinateSet(a, b);

                _model.AssignItem(_shapeName, _dataIndex, _deleteIndex, newSet);
                Dispose();
            }
        }

        /// <summary>
        /// check if all coordinate are okay
        /// </summary>
        /// <param name="leftTopX"></param>
        /// <param name="leftTopY"></param>
        /// <param name="rightBottomX"></param>
        /// <param name="rightBottomY"></param>
        /// <returns></returns>
        public static bool AreCoordinatesValid(string leftTopX, string leftTopY, string rightBottomX, string rightBottomY)
        {
            Debug.Assert(leftTopX != null && leftTopY != null && rightBottomX != null && rightBottomY != null, "TextBoxes cannot be null.");

            if (!IsValidCoordinate(leftTopX) || !IsValidCoordinate(leftTopY) ||
                !IsValidCoordinate(rightBottomX) || !IsValidCoordinate(rightBottomY))
            {
                ShowErrorMessage("Invalid coordinate format. Please enter valid numeric values.");
                return false;
            }

            int x1 = ParseCoordinate(leftTopX);
            int y1 = ParseCoordinate(leftTopY);
            int x2 = ParseCoordinate(rightBottomX);
            int y2 = ParseCoordinate(rightBottomY);

            Debug.Assert(x1 < x2, "LeftTop X coordinate must be less than RightBottom X coordinate.");
            Debug.Assert(y1 < y2, "LeftTop Y coordinate must be less than RightBottom Y coordinate.");
            Debug.Assert(x1 != x2, "LeftTop X coordinate can't be the same with RightBottom X coordinate.");
            Debug.Assert(y1 != y2, "LeftTop Y coordinate can't be the same with RightBottom Y coordinate.");

            return true;
        }

        /// <summary>
        /// check if coordinate is vaild
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool IsValidCoordinate(string text)
        {
            Debug.Assert(text != null, "Text cannot be null.");

            if (!int.TryParse(text, out _))
            {
                ShowErrorMessage("Invalid coordinate format. Please enter valid numeric values.");
                return false;
            }

            int parsedValue = int.Parse(text);

            Debug.Assert(parsedValue >= 0, "Coordinates cannot be negative.");
            Debug.Assert(parsedValue % 1 == 0, "Coordinates cannot be float values.");

            return true;
        }

        /// <summary>
        /// try to parse
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static int ParseCoordinate(string text)
        {
            Debug.Assert(text != null, "Text cannot be null.");

            if (!int.TryParse(text, out int parsedValue))
            {
                throw new ArgumentException("Invalid coordinate format. Please enter valid numeric values.", nameof(text));
            }

            return parsedValue;
        }

        /// <summary>
        /// to show message
        /// </summary>
        /// <param name="message"></param>
        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
