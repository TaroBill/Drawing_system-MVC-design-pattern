using Homework2DrawingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Tests
{
    public class MockGraphics : IGraphics
    {
        public MockGraphics()
        {
            ExecuteTimes = 0;
        }

        public int ExecuteTimes
        {
            get; set;
        }

        //假清除
        public void ClearAll()
        {
            ExecuteTimes = 0;
        }

        //假畫橢圓
        public void DrawEllipse(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            ExecuteTimes++;
        }

        //假畫邊框
        public void DrawEllipseFrame(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            ExecuteTimes+=2;
        }

        //假畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            ExecuteTimes++;
        }

        //假畫長方形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            ExecuteTimes++;
        }

        //假畫邊框
        public void DrawRectangleFrame(double x1, double y1, double x2, double y2)
        {
            ExecuteTimes += 2;
        }
    }
}
