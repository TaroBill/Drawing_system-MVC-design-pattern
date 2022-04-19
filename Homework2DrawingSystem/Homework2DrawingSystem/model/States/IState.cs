using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.States
{
    public interface IState
    {
        //按下左鍵
        void PressedPointer(double locationX, double locationY);

        //移動左鍵
        void MovedPointer(double locationX, double locationY);

        //放開左鍵
        void ReleasedPointer(double locationX, double locationY);

        //畫圖
        void Draw(IGraphics graphics);

        //移除圖形
        void RemoveShape(IShape shape);

        //移除圖形
        void RemoveShape();
    }
}
