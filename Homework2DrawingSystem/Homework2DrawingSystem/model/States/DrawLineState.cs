using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.States
{
    public class DrawLineState : IState
    {
        private FreeLine _hint;
        private IShape _shape1;
        private bool _isPressed = false;
        private readonly Model _model;

        public DrawLineState(Model model)
        {
            _model = model;
        }

        //移動滑鼠
        public void MovedPointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                if (_shape1 != null)
                    _hint.SetSecondLocation(locationX, locationY);
            }
        }

        //按下滑鼠
        public void PressedPointer(double locationX, double locationY)
        {
            IShape shape = _model.GetShape(locationX, locationY);
            if (shape != null)
            {
                _shape1 = shape;
                _hint = (FreeLine)ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.FreeLine);
                _hint.SetFirstLocation(locationX, locationY);
            }
            else
            {
                _hint = null;
                _shape1 = null;
            }
            _isPressed = true;
        }

        //放開滑鼠
        public void ReleasedPointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                IShape shape = _model.GetShape(locationX, locationY);
                if (shape != null && shape != _shape1)
                {
                    Line line = (Line)ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.Line);
                    line.SetShape1(ref _shape1);
                    line.SetShape2(ref shape);
                    _model.CommandManager.Execute(CommandFactory.DrawShapeCommand(line, _model));
                    _model.SelectedShape = line;
                }
            }
            _hint = null;
            _shape1 = null;
            _isPressed = false;
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            if (_isPressed && _hint != null)
                _hint.Draw(graphics);
        }

        //移除Shape
        public void RemoveShape(IShape shape)
        {

        }

        //移除Shape
        public void RemoveShape()
        {
            _hint = null;
        }
    }
}
