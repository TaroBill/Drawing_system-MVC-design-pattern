
namespace Homework2DrawingSystem
{
    partial class DrawingForm
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
            this._rectangleButton = new System.Windows.Forms.Button();
            this._eclipseButton = new System.Windows.Forms.Button();
            this._clearAllButton = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._lineButton = new System.Windows.Forms.Button();
            this._mouseButton = new System.Windows.Forms.Button();
            this._canvas = new Homework2DrawingSystem.DoubleBufferPanel();
            this._selectedShapeLabel = new System.Windows.Forms.Label();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip.SuspendLayout();
            this._canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rectangleButton
            // 
            this._rectangleButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._rectangleButton.Location = new System.Drawing.Point(327, 30);
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(156, 57);
            this._rectangleButton.TabIndex = 0;
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.UseVisualStyleBackColor = true;
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _eclipseButton
            // 
            this._eclipseButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._eclipseButton.Location = new System.Drawing.Point(599, 30);
            this._eclipseButton.Name = "_eclipseButton";
            this._eclipseButton.Size = new System.Drawing.Size(156, 57);
            this._eclipseButton.TabIndex = 1;
            this._eclipseButton.Text = "Ellipse";
            this._eclipseButton.UseVisualStyleBackColor = true;
            this._eclipseButton.Click += new System.EventHandler(this.ClickEllipseButton);
            // 
            // _clearAllButton
            // 
            this._clearAllButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._clearAllButton.Location = new System.Drawing.Point(1121, 30);
            this._clearAllButton.Name = "_clearAllButton";
            this._clearAllButton.Size = new System.Drawing.Size(156, 57);
            this._clearAllButton.TabIndex = 2;
            this._clearAllButton.Text = "Clear";
            this._clearAllButton.UseVisualStyleBackColor = true;
            this._clearAllButton.Click += new System.EventHandler(this.ClickClearButton);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undoToolStripMenuItem,
            this._redoToolStripMenuItem,
            this._saveToolStripMenuItem,
            this._loadToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1350, 27);
            this._menuStrip.TabIndex = 4;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _undoToolStripMenuItem
            // 
            this._undoToolStripMenuItem.Enabled = false;
            this._undoToolStripMenuItem.Name = "_undoToolStripMenuItem";
            this._undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this._undoToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this._undoToolStripMenuItem.Text = "Undo";
            // 
            // _redoToolStripMenuItem
            // 
            this._redoToolStripMenuItem.Enabled = false;
            this._redoToolStripMenuItem.Name = "_redoToolStripMenuItem";
            this._redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this._redoToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this._redoToolStripMenuItem.Text = "Redo";
            // 
            // _lineButton
            // 
            this._lineButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._lineButton.Location = new System.Drawing.Point(877, 30);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(156, 57);
            this._lineButton.TabIndex = 5;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            // 
            // _mouseButton
            // 
            this._mouseButton.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._mouseButton.Location = new System.Drawing.Point(85, 30);
            this._mouseButton.Name = "_mouseButton";
            this._mouseButton.Size = new System.Drawing.Size(156, 57);
            this._mouseButton.TabIndex = 6;
            this._mouseButton.Text = "Mouse";
            this._mouseButton.UseVisualStyleBackColor = true;
            // 
            // _canvas
            // 
            this._canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._canvas.Controls.Add(this._selectedShapeLabel);
            this._canvas.Location = new System.Drawing.Point(12, 102);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(1326, 627);
            this._canvas.TabIndex = 3;
            // 
            // _selectedShapeLabel
            // 
            this._selectedShapeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._selectedShapeLabel.AutoSize = true;
            this._selectedShapeLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._selectedShapeLabel.Location = new System.Drawing.Point(16, 593);
            this._selectedShapeLabel.Name = "_selectedShapeLabel";
            this._selectedShapeLabel.Size = new System.Drawing.Size(0, 16);
            this._selectedShapeLabel.TabIndex = 0;
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(54, 23);
            this._saveToolStripMenuItem.Text = "Save";
            // 
            // _loadToolStripMenuItem
            // 
            this._loadToolStripMenuItem.Name = "_loadToolStripMenuItem";
            this._loadToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this._loadToolStripMenuItem.Text = "Load";
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this._mouseButton);
            this.Controls.Add(this._lineButton);
            this.Controls.Add(this._canvas);
            this.Controls.Add(this._clearAllButton);
            this.Controls.Add(this._eclipseButton);
            this.Controls.Add(this._rectangleButton);
            this.Controls.Add(this._menuStrip);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._canvas.ResumeLayout(false);
            this._canvas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _rectangleButton;
        private System.Windows.Forms.Button _eclipseButton;
        private System.Windows.Forms.Button _clearAllButton;
        private DoubleBufferPanel _canvas;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _redoToolStripMenuItem;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Button _mouseButton;
        private System.Windows.Forms.Label _selectedShapeLabel;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _loadToolStripMenuItem;
    }
}

