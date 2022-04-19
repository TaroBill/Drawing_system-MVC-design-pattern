﻿using Homework2DrawingSystem.Model;
using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingSystemApp
{
    public class DrawingPresentationModel
    {
        public ButtonEnableEventHandler ButtonEnableChanged
        {
            get; set;
        }
        public delegate void ButtonEnableEventHandler();
        private readonly Model _model;

        public DrawingPresentationModel(Model model)
        {
            _model = model;
            _model.ModelChanged += CheckCommand;
            _model.ModelChanged += CheckSelectedShape;
        }

        //轉換model的state到長方形
        public void ChangeStateToRectangle()
        {
            ResetAll();
            _model.ChangeState(StateFactory.StateTypes.DrawRectangle);
            RectangleButtonEnable = false;
        }

        //轉換model的state到橢圓形
        public void ChangeStateToEllipse()
        {
            ResetAll();
            _model.ChangeState(StateFactory.StateTypes.DrawEllipse);
            EclipseButtonEnable = false;
        }

        //轉換model的state到畫線
        public void ChangeStateToLine()
        {
            ResetAll();
            _model.ChangeState(StateFactory.StateTypes.DrawLine);
            LineButtonEnable = false;
        }

        //轉換model的state到滑鼠
        public void ChangeStateToMouse()
        {
            ResetAll();
            _model.ChangeState(StateFactory.StateTypes.Default);
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
            EclipseButtonEnable = true;
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

        //save
        public void ClickSave()
        {
            _model.Save();
        }

        //確認指令是否為空
        public void ClickLoad()
        {
            _model.Load();
        }

        //確認指令是否為空
        public void ClickRedo()
        {
            _model.CommandManager.Redo();
        }

        //畫
        public void Draw(IGraphics graphics)
        {
            _model.Draw(graphics);
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

        private bool _eclipseButtonEnable = true;
        public bool EclipseButtonEnable
        {
            get
            {
                return _eclipseButtonEnable;
            }
            set
            {
                _eclipseButtonEnable = value;
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
