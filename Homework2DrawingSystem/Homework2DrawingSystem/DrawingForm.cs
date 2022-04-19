using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2DrawingSystem
{
    public partial class DrawingForm : Form
    {
        private readonly Model.Model _model;
        private readonly FormPresentationModel _formPresentationModel;
        public DrawingForm(FormPresentationModel formPresentationModel, Model.Model model)
        {
            InitializeComponent();
            _model = model;
            _formPresentationModel = formPresentationModel;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            _model.ModelChanged += HandleModelChanged;
            _formPresentationModel.ButtonEnableChanged += ChangeButtonState;
            _undoToolStripMenuItem.Click += ClickUndoButton;
            _redoToolStripMenuItem.Click += ClickRedoButton;
            _mouseButton.Click += ClickMouseButton;
            _lineButton.Click += ClickLineButton;
            _saveToolStripMenuItem.Click += ClickSaveButton;
            _loadToolStripMenuItem.Click += ClickLoadButton;
        }

        //更新所有按鈕狀態
        private void ChangeButtonState()
        {
            _eclipseButton.Enabled = _formPresentationModel.EllipseButtonEnable;
            _rectangleButton.Enabled = _formPresentationModel.RectangleButtonEnable;
            _undoToolStripMenuItem.Enabled = _formPresentationModel.UndoButtonEnable;
            _redoToolStripMenuItem.Enabled = _formPresentationModel.RedoButtonEnable;
            _mouseButton.Enabled = _formPresentationModel.MouseButtonEnable;
            _lineButton.Enabled = _formPresentationModel.LineButtonEnable;
            _selectedShapeLabel.Text = _formPresentationModel.SelectedShapeText;
        }

        //在canvas按下滑鼠
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
        }

        //在canvas放開滑鼠
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
        }

        //在canvas移動滑鼠
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        //在canvas畫圖
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _formPresentationModel.Draw(e.Graphics);
        }

        //在model變了
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //按下Undo按鈕
        private void ClickUndoButton(object sender, EventArgs e)
        {
            _formPresentationModel.ClickUndo();
        }

        //按下Redo按鈕
        private void ClickRedoButton(object sender, EventArgs e)
        {
            _formPresentationModel.ClickRedo();
        }

        //按下長方形按鈕
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _formPresentationModel.ChangeStateToRectangle();
        }

        //按下橢圓形按鈕
        private void ClickEllipseButton(object sender, EventArgs e)
        {
            _formPresentationModel.ChangeStateToEllipse();
        }

        //按下清除按鈕
        private void ClickClearButton(object sender, EventArgs e)
        {
            _formPresentationModel.ClearAll();
        }

        //按下清除按鈕
        private void ClickMouseButton(object sender, EventArgs e)
        {
            _formPresentationModel.ChangeStateToMouse();
        }

        //按下清除按鈕
        private void ClickLineButton(object sender, EventArgs e)
        {
            _formPresentationModel.ChangeStateToLine();
        }

        //按下儲存按鈕
        private void ClickSaveButton(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要儲存?", "確認訊息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _formPresentationModel.ClickSave();
            }
        }

        //按下讀取按鈕
        private void ClickLoadButton(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要讀取?", "確認訊息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _formPresentationModel.ClickLoad();
            }
        }
    }
}
