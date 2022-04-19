using Homework2DrawingSystem.Model.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework2DrawingSystem
{
    public class FormPresentationModel
    {
        public ButtonEnableEventHandler ButtonEnableChanged
        {
            get; set;
        }
        public delegate void ButtonEnableEventHandler();
        private readonly Model.Model _model;

        public FormPresentationModel(Model.Model model)
        {
            _model = model;
            _model.ModelChanged += CheckCommand;
            _model.ModelChanged += CheckSelectedShape;
        }

        //轉換model的state到長方形
        public void ChangeStateToRectangle()
        {
            ResetAll();
            _model.ChangeState(Model.States.StateFactory.StateTypes.DrawRectangle);
            RectangleButtonEnable = false;
        }

        //轉換model的state到橢圓形
        public void ChangeStateToEllipse()
        {
            ResetAll();
            _model.ChangeState(Model.States.StateFactory.StateTypes.DrawEllipse);
            EllipseButtonEnable = false;
        }

        //轉換model的state到畫線
        public void ChangeStateToLine()
        {
            ResetAll();
            _model.ChangeState(Model.States.StateFactory.StateTypes.DrawLine);
            LineButtonEnable = false;
        }

        //轉換model的state到滑鼠
        public void ChangeStateToMouse()
        {
            ResetAll();
            _model.ChangeState(Model.States.StateFactory.StateTypes.Default);
            MouseButtonEnable = false;
        }

        //轉換model的state
        public void ClearAll()
        {
            _model.CommandManager.Execute(CommandFactory.ClearAllCommand(_model));
        }

        //重製所有的狀態和按鈕
        private void ResetAll()
        {
            RectangleButtonEnable = true;
            EllipseButtonEnable = true;
            MouseButtonEnable = true;
            LineButtonEnable = true;
        }

        //確認指令是否為空
        private void CheckCommand()
        {
            if (_model.CommandManager.UndoAmount < 1)
                UndoButtonEnable = false;
            else
                UndoButtonEnable = true;
            if (_model.CommandManager.RedoAmount < 1)
                RedoButtonEnable = false;
            else
                RedoButtonEnable = true;
        }

        //確認指令是否為空
        public void ClickUndo()
        {
            _model.CommandManager.Undo();
        }

        //確認指令是否為空
        public void ClickRedo()
        {
            _model.CommandManager.Redo();
        }

        //確按下儲存
        public void ClickSave()
        {
            _model.Save();
        }

        //確認指令是否為空
        public void ClickLoad()
        {
            _model.Load();
        }

        //畫
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new FormGraphicAdapter(graphics));
        }

        //通知所有按鈕按鍵更新了
        public void NotifyButtonEnableChanged()
        {
            ButtonEnableChanged?.Invoke();
        }

        //取得選擇的圖形
        private void CheckSelectedShape()
        {
            if (_model.SelectedShape != null)
            {
                SelectedShapeText = _model.SelectedShape.ToString();
            }
            else
            {
                const string SELECTED_NOT_FOUND = "Not Selected any Shape";
                SelectedShapeText = SELECTED_NOT_FOUND;
            }
        }

        private string _selectedShapeText = "";
        public string SelectedShapeText
        {
            get
            {
                return _selectedShapeText;
            }
            set
            {
                _selectedShapeText = value;
                NotifyButtonEnableChanged();
            }
        }

        private bool _undoButtonEnable = false;
        public bool UndoButtonEnable
        {
            get
            {
                return _undoButtonEnable;
            }
            set
            {
                _undoButtonEnable = value;
                NotifyButtonEnableChanged();
            }
        }

        private bool _redoButtonEnable = false;
        public bool RedoButtonEnable
        {
            get
            {
                return _redoButtonEnable;
            }
            set
            {
                _redoButtonEnable = value;
                NotifyButtonEnableChanged();
            }
        }

        private bool _rectangleButtonEnable = true;
        public bool RectangleButtonEnable
        {
            get
            {
                return _rectangleButtonEnable;
            }
            set
            {
                _rectangleButtonEnable = value;
                NotifyButtonEnableChanged();
            }
        }

        private bool _ellipseButtonEnable = true;
        public bool EllipseButtonEnable
        {
            get
            {
                return _ellipseButtonEnable;
            }
            set
            {
                _ellipseButtonEnable = value;
                NotifyButtonEnableChanged();
            }
        }

        private bool _lineButtonEnable = true;
        public bool LineButtonEnable
        {
            get
            {
                return _lineButtonEnable;
            }
            set
            {
                _lineButtonEnable = value;
                NotifyButtonEnableChanged();
            }
        }

        private bool _mouseButtonEnable = false;
        public bool MouseButtonEnable
        {
            get
            {
                return _mouseButtonEnable;
            }
            set
            {
                _mouseButtonEnable = value;
                NotifyButtonEnableChanged();
            }
        }
    }
}
