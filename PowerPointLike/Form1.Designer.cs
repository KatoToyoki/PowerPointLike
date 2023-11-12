
namespace PowerPointLike
{
    partial class PowerPointLike
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._menu = new System.Windows.Forms.MenuStrip();
            this._menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this._menuInfoAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._canvas = new System.Windows.Forms.Panel();
            this._canvas1 = new System.Windows.Forms.Button();
            this._canvasElementsData = new System.Windows.Forms.GroupBox();
            this._elementDataGrid = new System.Windows.Forms.DataGridView();
            this._deleteButton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._elementsChoicesBox = new System.Windows.Forms.ComboBox();
            this._newElementButton = new System.Windows.Forms.Button();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._circleButton = new System.Windows.Forms.ToolStripButton();
            this._mouseButton = new System.Windows.Forms.ToolStripButton();
            this._menu.SuspendLayout();
            this._canvasElementsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._elementDataGrid)).BeginInit();
            this._toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menu
            // 
            this._menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuInfo});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(1441, 27);
            this._menu.TabIndex = 0;
            this._menu.Text = "menuStrip1";
            // 
            // _menuInfo
            // 
            this._menuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuInfoAbout});
            this._menuInfo.Name = "_menuInfo";
            this._menuInfo.Size = new System.Drawing.Size(53, 26);
            this._menuInfo.Text = "說明";
            // 
            // _menuInfoAbout
            // 
            this._menuInfoAbout.Name = "_menuInfoAbout";
            this._menuInfoAbout.Size = new System.Drawing.Size(122, 26);
            this._menuInfoAbout.Text = "關於";
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._canvas.Location = new System.Drawing.Point(140, 67);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(888, 640);
            this._canvas.TabIndex = 2;
            // 
            // _canvas1
            // 
            this._canvas1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._canvas1.Location = new System.Drawing.Point(15, 67);
            this._canvas1.Name = "_canvas1";
            this._canvas1.Size = new System.Drawing.Size(111, 80);
            this._canvas1.TabIndex = 3;
            this._canvas1.UseVisualStyleBackColor = false;
            // 
            // _canvasElementsData
            // 
            this._canvasElementsData.Controls.Add(this._elementDataGrid);
            this._canvasElementsData.Controls.Add(this._elementsChoicesBox);
            this._canvasElementsData.Controls.Add(this._newElementButton);
            this._canvasElementsData.Location = new System.Drawing.Point(1045, 67);
            this._canvasElementsData.Name = "_canvasElementsData";
            this._canvasElementsData.Size = new System.Drawing.Size(374, 662);
            this._canvasElementsData.TabIndex = 5;
            this._canvasElementsData.TabStop = false;
            this._canvasElementsData.Text = "資料顯示";
            // 
            // _elementDataGrid
            // 
            this._elementDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this._elementDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._elementDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._shapeName,
            this._shapeInfo});
            this._elementDataGrid.Location = new System.Drawing.Point(13, 86);
            this._elementDataGrid.Name = "_elementDataGrid";
            this._elementDataGrid.RowHeadersWidth = 51;
            this._elementDataGrid.RowTemplate.Height = 27;
            this._elementDataGrid.Size = new System.Drawing.Size(350, 546);
            this._elementDataGrid.TabIndex = 2;
            this._elementDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteElement);
            // 
            // _deleteButton
            // 
            this._deleteButton.HeaderText = "刪除";
            this._deleteButton.MinimumWidth = 6;
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.ReadOnly = true;
            this._deleteButton.Width = 55;
            // 
            // _shapeName
            // 
            this._shapeName.HeaderText = "形狀";
            this._shapeName.MinimumWidth = 6;
            this._shapeName.Name = "_shapeName";
            this._shapeName.ReadOnly = true;
            this._shapeName.Width = 55;
            // 
            // _shapeInfo
            // 
            this._shapeInfo.HeaderText = "資訊";
            this._shapeInfo.MinimumWidth = 6;
            this._shapeInfo.Name = "_shapeInfo";
            this._shapeInfo.ReadOnly = true;
            this._shapeInfo.Width = 125;
            // 
            // _elementsChoicesBox
            // 
            this._elementsChoicesBox.FormattingEnabled = true;
            this._elementsChoicesBox.Items.AddRange(new object[] {
            "矩形",
            "線",
            "圓"});
            this._elementsChoicesBox.Location = new System.Drawing.Point(135, 44);
            this._elementsChoicesBox.Name = "_elementsChoicesBox";
            this._elementsChoicesBox.Size = new System.Drawing.Size(228, 23);
            this._elementsChoicesBox.TabIndex = 1;
            // 
            // _newElementButton
            // 
            this._newElementButton.Location = new System.Drawing.Point(13, 29);
            this._newElementButton.Name = "_newElementButton";
            this._newElementButton.Size = new System.Drawing.Size(114, 51);
            this._newElementButton.TabIndex = 0;
            this._newElementButton.Text = "新增";
            this._newElementButton.UseVisualStyleBackColor = true;
            this._newElementButton.Click += new System.EventHandler(this.AddNewElement);
            // 
            // _toolBar
            // 
            this._toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._mouseButton});
            this._toolBar.Location = new System.Drawing.Point(0, 27);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Size = new System.Drawing.Size(1441, 27);
            this._toolBar.TabIndex = 6;
            this._toolBar.Text = "toolStrip1";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineButton.Image = global::PowerPointLike.Properties.Resources.line;
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(29, 28);
            this._lineButton.Text = "Line";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleButton.Image = global::PowerPointLike.Properties.Resources.rectangle;
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(29, 28);
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleButton.Image = global::PowerPointLike.Properties.Resources.circle;
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(29, 28);
            this._circleButton.Text = "Circle";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _mouseButton
            // 
            this._mouseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._mouseButton.Image = global::PowerPointLike.Properties.Resources.mouse;
            this._mouseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mouseButton.Name = "_mouseButton";
            this._mouseButton.Size = new System.Drawing.Size(29, 28);
            this._mouseButton.Text = "toolStripButton1";
            this._mouseButton.ToolTipText = "Mouse";
            this._mouseButton.Click += new System.EventHandler(this.ClickMouseButton);
            // 
            // PowerPointLike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1441, 711);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._canvasElementsData);
            this.Controls.Add(this._canvas1);
            this.Controls.Add(this._menu);
            this.Controls.Add(this._canvas);
            this.MainMenuStrip = this._menu;
            this.Name = "PowerPointLike";
            this.Text = "PowerPointLike";
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this._canvasElementsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._elementDataGrid)).EndInit();
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _menuInfo;
        private System.Windows.Forms.ToolStripMenuItem _menuInfoAbout;
        private System.Windows.Forms.Panel _canvas;
        private System.Windows.Forms.Button _canvas1;
        private System.Windows.Forms.GroupBox _canvasElementsData;
        private System.Windows.Forms.ComboBox _elementsChoicesBox;
        private System.Windows.Forms.Button _newElementButton;
        private System.Windows.Forms.DataGridView _elementDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeInfo;
        private System.Windows.Forms.ToolStrip _toolBar;
        private System.Windows.Forms.ToolStripButton _lineButton;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _circleButton;
        private System.Windows.Forms.ToolStripButton _mouseButton;
    }
}

