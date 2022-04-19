using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model
{
    public interface IGraphics
    {
        //清除所有
        void ClearAll();
        
        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        //畫長方形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //畫橢圓形
        void DrawEllipse(double locationX1, double locationY1, double locationX2, double locationY2);

        //畫長方形
        void DrawRectangleFrame(double x1, double y1, double x2, double y2);

        //畫橢圓形
        void DrawEllipseFrame(double locationX1, double locationY1, double locationX2, double locationY2);
    }
}
