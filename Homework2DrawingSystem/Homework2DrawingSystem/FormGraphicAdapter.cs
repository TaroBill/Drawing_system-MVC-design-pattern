using Homework2DrawingSystem.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem
{
    public class FormGraphicAdapter : IGraphics
    {
        private readonly Graphics _graphics;
        private const int PEN_WIDTH = 3;
        private const float DOT_WIDTH = 7.0f;

        public FormGraphicAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }
        //清除全部
        public void ClearAll()
        {
            _graphics.Clear(Color.LightGoldenrodYellow);
        }

        //畫線
        public void DrawLine(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            Pen pen = new Pen(Brushes.ForestGreen);
            _graphics.DrawLine(pen, (float)locationX1, (float)locationY1, (float)locationX2, (float)locationY2);
        }

        //畫長方形
        public void DrawRectangle(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            int sizeX = Math.Abs((int)locationX2 - (int)locationX1);
            int sizeY = Math.Abs((int)locationY2 - (int)locationY1);
            int locationX = Math.Min((int)locationX2, (int)locationX1);
            int locationY = Math.Min((int)locationY2, (int)locationY1);
            Pen pen = new Pen(Brushes.Black, PEN_WIDTH);
            _graphics.FillRectangle(Brushes.Tomato, locationX, locationY, sizeX, sizeY);
            _graphics.DrawRectangle(pen, locationX, locationY, sizeX, sizeY);
        }

        //畫橢圓形
        public void DrawEllipse(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            int sizeX = Math.Abs((int)locationX2 - (int)locationX1);
            int sizeY = Math.Abs((int)locationY2 - (int)locationY1);
            int locationX = Math.Min((int)locationX2, (int)locationX1);
            int locationY = Math.Min((int)locationY2, (int)locationY1);
            Pen pen = new Pen(Brushes.Black, PEN_WIDTH);
            _graphics.FillEllipse(Brushes.Orange, locationX, locationY, sizeX, sizeY);
            _graphics.DrawEllipse(pen, locationX, locationY, sizeX, sizeY);
        }

        //畫長方形邊框
        public void DrawRectangleFrame(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            int sizeX = Math.Abs((int)locationX2 - (int)locationX1);
            int sizeY = Math.Abs((int)locationY2 - (int)locationY1);
            int minLocationX = Math.Min((int)locationX2, (int)locationX1);
            int minLocationY = Math.Min((int)locationY2, (int)locationY1);
            int maxLocationX = Math.Max((int)locationX2, (int)locationX1);
            int maxLocationY = Math.Max((int)locationY2, (int)locationY1);

            Pen pen = new Pen(Brushes.Red, PEN_WIDTH)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash,
            };

            _graphics.DrawRectangle(pen, minLocationX, minLocationY, sizeX, sizeY);
            DrawDot(minLocationX, minLocationY);
            DrawDot(minLocationX, maxLocationY);
            DrawDot(maxLocationX, minLocationY);
            DrawDot(maxLocationX, maxLocationY);
        }

        const int TWO = 2;

        //畫點
        private void DrawDot(int locationX, int locationY)
        {
            _graphics.FillEllipse(Brushes.Red, locationX - (DOT_WIDTH / TWO), locationY - (DOT_WIDTH / TWO), DOT_WIDTH, DOT_WIDTH);
        }

        //畫橢圓形邊框
        public void DrawEllipseFrame(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            DrawRectangleFrame(locationX1, locationY1, locationX2, locationY2);
        }
    }
}
