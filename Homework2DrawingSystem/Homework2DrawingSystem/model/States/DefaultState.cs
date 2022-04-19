using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.States
{
    public class DefaultState : IState
    {
        private IShape _selectedShape;
        private IShape _hintShape;
        private bool _isPressed = false;
        private double _lastLocationX;
        private double _lastLocationY;
        private double _pressedLocationX;
        private double _pressedLocationY;
        private readonly Model _model;

        public DefaultState(Model model)
        {
            _model = model;
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            if (_selectedShape != null)
            {
                _selectedShape.DrawFrame(graphics);
                if (_isPressed)
                    _hintShape.DrawFrame(graphics);
            }
        }

        //移動滑鼠
        public void MovedPointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                if (_selectedShape != null)
                {
                    double offsetX = locationX - _lastLocationX;
                    double offsetY = locationY - _lastLocationY;
                    _hintShape.MoveOffset(offsetX, offsetY);
                    _lastLocationX = locationX;
                    _lastLocationY = locationY;
                }
            }
        }

        //按下滑鼠
        public void PressedPointer(double locationX, double locationY)
        {
            IShape shape = _model.GetShape(locationX, locationY);
            if (shape != null)
            {
                _hintShape = shape.Clone();
                _selectedShape = shape;
                _model.SelectedShape = shape;
                _lastLocationX = locationX;
                _lastLocationY = locationY;
                _pressedLocationX = locationX;
                _pressedLocationY = locationY;
            }
            else
            {
                _selectedShape = null;
                _model.SelectedShape = null;
            }
            _isPressed = true;
        }

        //放開滑鼠
        public void ReleasedPointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                if (_selectedShape != null)
                {
                    double offsetX = locationX - _pressedLocationX;
                    double offsetY = locationY - _pressedLocationY;
                    _model.CommandManager.Execute(CommandFactory.MoveShapeCommand(_model, _selectedShape, offsetX, offsetY));
                }
            }
            _isPressed = false;
        }

        //移除Shape
        public void RemoveShape(IShape shape)
        {
            if (_selectedShape == shape)
            {
                _hintShape = null;
                _selectedShape = null;
            }
        }

        //移除Shape
        public void RemoveShape()
        {
            _hintShape = null;
            _selectedShape = null;
        }
    }
}
