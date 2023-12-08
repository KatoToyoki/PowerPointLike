
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
            this._dataViewContainer = new System.Windows.Forms.SplitContainer();
            this._newElementButton = new System.Windows.Forms.Button();
            this._elementsChoicesBox = new System.Windows.Forms.ComboBox();
            this._elementDataGrid = new System.Windows.Forms.DataGridView();
            this._deleteButton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._drawingViewContainer = new System.Windows.Forms.SplitContainer();
            this._drawingDataContainer = new System.Windows.Forms.SplitContainer();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._circleButton = new System.Windows.Forms.ToolStripButton();
            this._mouseButton = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._menu.SuspendLayout();
            this._canvasElementsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataViewContainer)).BeginInit();
            this._dataViewContainer.Panel1.SuspendLayout();
            this._dataViewContainer.Panel2.SuspendLayout();
            this._dataViewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._elementDataGrid)).BeginInit();
            this._toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._drawingViewContainer)).BeginInit();
            this._drawingViewContainer.Panel1.SuspendLayout();
            this._drawingViewContainer.Panel2.SuspendLayout();
            this._drawingViewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._drawingDataContainer)).BeginInit();
            this._drawingDataContainer.Panel1.SuspendLayout();
            this._drawingDataContainer.Panel2.SuspendLayout();
            this._drawingDataContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menu
            // 
            this._menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuInfo});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(1581, 27);
            this._menu.TabIndex = 0;
            this._menu.Text = "menuStrip1";
            // 
            // _menuInfo
            // 
            this._menuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuInfoAbout});
            this._menuInfo.Name = "_menuInfo";
            this._menuInfo.Size = new System.Drawing.Size(53, 23);
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
            this._canvas.Dock = System.Windows.Forms.DockStyle.Top;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(958, 530);
            this._canvas.TabIndex = 2;
            this._canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.ChangeCanvas);
            // 
            // _canvas1
            // 
            this._canvas1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._canvas1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._canvas1.Dock = System.Windows.Forms.DockStyle.Top;
            this._canvas1.Location = new System.Drawing.Point(0, 0);
            this._canvas1.Name = "_canvas1";
            this._canvas1.Size = new System.Drawing.Size(133, 80);
            this._canvas1.TabIndex = 3;
            this._canvas1.UseVisualStyleBackColor = false;
            // 
            // _canvasElementsData
            // 
            this._canvasElementsData.Controls.Add(this._dataViewContainer);
            this._canvasElementsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvasElementsData.Location = new System.Drawing.Point(0, 0);
            this._canvasElementsData.Name = "_canvasElementsData";
            this._canvasElementsData.Size = new System.Drawing.Size(470, 698);
            this._canvasElementsData.TabIndex = 5;
            this._canvasElementsData.TabStop = false;
            this._canvasElementsData.Text = "資料顯示";
            // 
            // _dataViewContainer
            // 
            this._dataViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataViewContainer.Location = new System.Drawing.Point(3, 21);
            this._dataViewContainer.Name = "_dataViewContainer";
            this._dataViewContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _dataViewContainer.Panel1
            // 
            this._dataViewContainer.Panel1.Controls.Add(this._newElementButton);
            this._dataViewContainer.Panel1.Controls.Add(this._elementsChoicesBox);
            // 
            // _dataViewContainer.Panel2
            // 
            this._dataViewContainer.Panel2.Controls.Add(this._elementDataGrid);
            this._dataViewContainer.Size = new System.Drawing.Size(464, 674);
            this._dataViewContainer.SplitterDistance = 55;
            this._dataViewContainer.TabIndex = 3;
            // 
            // _newElementButton
            // 
            this._newElementButton.Location = new System.Drawing.Point(3, 3);
            this._newElementButton.Name = "_newElementButton";
            this._newElementButton.Size = new System.Drawing.Size(114, 51);
            this._newElementButton.TabIndex = 0;
            this._newElementButton.Text = "新增";
            this._newElementButton.UseVisualStyleBackColor = true;
            this._newElementButton.Click += new System.EventHandler(this.AddNewElement);
            // 
            // _elementsChoicesBox
            // 
            this._elementsChoicesBox.FormattingEnabled = true;
            this._elementsChoicesBox.Items.AddRange(new object[] {
            "矩形",
            "線",
            "圓"});
            this._elementsChoicesBox.Location = new System.Drawing.Point(123, 18);
            this._elementsChoicesBox.Name = "_elementsChoicesBox";
            this._elementsChoicesBox.Size = new System.Drawing.Size(228, 23);
            this._elementsChoicesBox.TabIndex = 1;
            // 
            // _elementDataGrid
            // 
            this._elementDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this._elementDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._elementDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._shapeName,
            this._shapeInfo});
            this._elementDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._elementDataGrid.Location = new System.Drawing.Point(0, 0);
            this._elementDataGrid.Name = "_elementDataGrid";
            this._elementDataGrid.RowHeadersWidth = 51;
            this._elementDataGrid.RowTemplate.Height = 27;
            this._elementDataGrid.Size = new System.Drawing.Size(464, 615);
            this._elementDataGrid.TabIndex = 2;
            this._elementDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteElement);
            // 
            // _deleteButton
            // 
            this._deleteButton.HeaderText = "刪除";
            this._deleteButton.MinimumWidth = 6;
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.ReadOnly = true;
            this._deleteButton.Width = 65;
            // 
            // _shapeName
            // 
            this._shapeName.HeaderText = "形狀";
            this._shapeName.MinimumWidth = 6;
            this._shapeName.Name = "_shapeName";
            this._shapeName.ReadOnly = true;
            this._shapeName.Width = 65;
            // 
            // _shapeInfo
            // 
            this._shapeInfo.HeaderText = "資訊";
            this._shapeInfo.MinimumWidth = 6;
            this._shapeInfo.Name = "_shapeInfo";
            this._shapeInfo.ReadOnly = true;
            this._shapeInfo.Width = 125;
            // 
            // _toolBar
            // 
            this._toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._mouseButton,
            this._undoButton,
            this._redoButton});
            this._toolBar.Location = new System.Drawing.Point(0, 27);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Size = new System.Drawing.Size(1581, 27);
            this._toolBar.TabIndex = 6;
            this._toolBar.Text = "toolStrip1";
            // 
            // _drawingViewContainer
            // 
            this._drawingViewContainer.BackColor = System.Drawing.Color.Silver;
            this._drawingViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._drawingViewContainer.Location = new System.Drawing.Point(0, 0);
            this._drawingViewContainer.Name = "_drawingViewContainer";
            // 
            // _drawingViewContainer.Panel1
            // 
            this._drawingViewContainer.Panel1.BackColor = System.Drawing.Color.PowderBlue;
            this._drawingViewContainer.Panel1.Controls.Add(this._canvas1);
            // 
            // _drawingViewContainer.Panel2
            // 
            this._drawingViewContainer.Panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this._drawingViewContainer.Panel2.Controls.Add(this._canvas);
            this._drawingViewContainer.Size = new System.Drawing.Size(1101, 698);
            this._drawingViewContainer.SplitterDistance = 133;
            this._drawingViewContainer.SplitterWidth = 10;
            this._drawingViewContainer.TabIndex = 7;
            this._drawingViewContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveSplitDrawingViewContainer);
            // 
            // _drawingDataContainer
            // 
            this._drawingDataContainer.BackColor = System.Drawing.Color.Silver;
            this._drawingDataContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._drawingDataContainer.Location = new System.Drawing.Point(0, 54);
            this._drawingDataContainer.Name = "_drawingDataContainer";
            // 
            // _drawingDataContainer.Panel1
            // 
            this._drawingDataContainer.Panel1.BackColor = System.Drawing.Color.LightCyan;
            this._drawingDataContainer.Panel1.Controls.Add(this._drawingViewContainer);
            // 
            // _drawingDataContainer.Panel2
            // 
            this._drawingDataContainer.Panel2.BackColor = System.Drawing.Color.PowderBlue;
            this._drawingDataContainer.Panel2.Controls.Add(this._canvasElementsData);
            this._drawingDataContainer.Size = new System.Drawing.Size(1581, 698);
            this._drawingDataContainer.SplitterDistance = 1101;
            this._drawingDataContainer.SplitterWidth = 10;
            this._drawingDataContainer.TabIndex = 8;
            this._drawingDataContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveSplitDrawingDataContainer);
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineButton.Image = global::PowerPointLike.Properties.Resources.line;
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.MergeIndex = 0;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(29, 24);
            this._lineButton.Text = "Line";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleButton.Image = global::PowerPointLike.Properties.Resources.rectangle;
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.MergeIndex = 1;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(29, 24);
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleButton.Image = global::PowerPointLike.Properties.Resources.circle;
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.MergeIndex = 2;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(29, 24);
            this._circleButton.Text = "Circle";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _mouseButton
            // 
            this._mouseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._mouseButton.Image = global::PowerPointLike.Properties.Resources.mouse;
            this._mouseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._mouseButton.Name = "_mouseButton";
            this._mouseButton.Size = new System.Drawing.Size(29, 24);
            this._mouseButton.Text = "toolStripButton1";
            this._mouseButton.ToolTipText = "Mouse";
            this._mouseButton.Click += new System.EventHandler(this.ClickMouseButton);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoButton.Image = global::PowerPointLike.Properties.Resources.undo;
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(29, 24);
            this._undoButton.Text = "Undo";
            this._undoButton.Click += new System.EventHandler(this.ClickUndo);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoButton.Image = global::PowerPointLike.Properties.Resources.redo;
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(29, 24);
            this._redoButton.Text = "Redo";
            this._redoButton.Click += new System.EventHandler(this.ClickRedo);
            // 
            // PowerPointLike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1581, 752);
            this.Controls.Add(this._drawingDataContainer);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._menu);
            this.MainMenuStrip = this._menu;
            this.Name = "PowerPointLike";
            this.Text = "PowerPointLike";
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this._canvasElementsData.ResumeLayout(false);
            this._dataViewContainer.Panel1.ResumeLayout(false);
            this._dataViewContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataViewContainer)).EndInit();
            this._dataViewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._elementDataGrid)).EndInit();
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this._drawingViewContainer.Panel1.ResumeLayout(false);
            this._drawingViewContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._drawingViewContainer)).EndInit();
            this._drawingViewContainer.ResumeLayout(false);
            this._drawingDataContainer.Panel1.ResumeLayout(false);
            this._drawingDataContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._drawingDataContainer)).EndInit();
            this._drawingDataContainer.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStrip _toolBar;
        private System.Windows.Forms.ToolStripButton _lineButton;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _circleButton;
        private System.Windows.Forms.ToolStripButton _mouseButton;
        private System.Windows.Forms.SplitContainer _drawingViewContainer;
        private System.Windows.Forms.SplitContainer _drawingDataContainer;
        private System.Windows.Forms.SplitContainer _dataViewContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeInfo;
        private System.Windows.Forms.ToolStripButton _undoButton;
        private System.Windows.Forms.ToolStripButton _redoButton;
    }
}

