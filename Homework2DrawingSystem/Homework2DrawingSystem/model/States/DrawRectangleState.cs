using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.States
{
    public class DrawRectangleState : IState
    {
        private Rectangle _hint;
        private bool _isPressed = false;
        private readonly Model _model;

        public DrawRectangleState(Model model)
        {
            _model = model;
            _hint = (Rectangle)ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.Rectangle);
        }

        //移動滑鼠
        public void MovedPointer(double locationX, double locationY)
        {
            if (_isPressed)
                _hint.SetSecondLocation(locationX, locationY);
        }

        //按下滑鼠
        public void PressedPointer(double locationX, double locationY)
        {
            _hint = (Rectangle)ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.Rectangle);
            _hint.SetFirstLocation(locationX, locationY);
            _isPressed = true;
        }

        //放開滑鼠
        public void ReleasedPointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                Rectangle rectangle = (Rectangle)ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.Rectangle);
                _hint.SetSecondLocation(locationX, locationY);
                var (locationX1, locationY1, locationX2, locationY2) = _hint.GetLocation();
                rectangle.SetLocation(locationX1, locationY1, locationX2, locationY2);
                _model.CommandManager.Execute(CommandFactory.DrawShapeCommand(rectangle, _model));
                _model.SelectedShape = rectangle;
            }

            _isPressed = false;
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            if (_isPressed)
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
