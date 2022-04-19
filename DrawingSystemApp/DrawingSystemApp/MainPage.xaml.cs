using Homework2DrawingSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingSystemApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly Model _model;
        private readonly IGraphics _graphics;
        readonly DrawingPresentationModel _presentationModel;

        public MainPage()
        {
            InitializeComponent();
            _model = new Model();
            _graphics = new WindowsStoreGraphicsAdaptor(_canvas);
            _presentationModel = new DrawingPresentationModel(_model);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clearAllButton.Click += HandleClearButtonClick;
            _rectangleButton.Click += HandleRectangleButtonClick;
            _eclipseButton.Click += HandleEllipseButtonClick;
            _undoButton.Click += HandleUndoButtonClick;
            _redoButton.Click += HandleRedoButtonClick;
            _mouseButton.Click += HandleMouseButtonClick;
            _LineButton.Click += HandleLineButtonClick;
            _model.ModelChanged += HandleModelChanged;
            _presentationModel.ButtonEnableChanged += ChangeButtonState;
            _saveButton.Click += HandleSaveButtonClick;
            _LoadButton.Click += HandleLoadeButtonClick;
        }

        //更新按鈕的狀態
        private void ChangeButtonState()
        {
            _eclipseButton.IsEnabled = _presentationModel.EclipseButtonEnable;
            _rectangleButton.IsEnabled = _presentationModel.RectangleButtonEnable;
            _undoButton.IsEnabled = _presentationModel.UndoButtonEnable;
            _redoButton.IsEnabled = _presentationModel.RedoButtonEnable;
            _LineButton.IsEnabled = _presentationModel.LineButtonEnable;
            _mouseButton.IsEnabled = _presentationModel.MouseButtonEnable;
            _selectedShapeTextBlock.Text = _presentationModel.SelectedShapeText;
        }

        //按下Undo按鈕
        private void HandleUndoButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickUndo();
        }

        //按下Redo按鈕
        private void HandleRedoButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickRedo();
        }

        //按下清除全部按鈕
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClearAll();
        }

        //按下矩形按鈕
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeStateToRectangle();
        }

        //按下橢圓按鈕
        private void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeStateToEllipse();
        }

        //按下橢圓按鈕
        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeStateToLine();
        }

        //按下橢圓按鈕
        private void HandleMouseButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeStateToMouse();
        }

        //按下橢圓按鈕
        private void HandleSaveButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickSave();
        }

        //按下橢圓按鈕
        private void HandleLoadeButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickLoad();
        }

        //在畫布上按下
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //在畫布上放開
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //在畫布上移動
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //在model改變時重畫圖
        public void HandleModelChanged()
        {
            _presentationModel.Draw(_graphics);
        }

    }
}
