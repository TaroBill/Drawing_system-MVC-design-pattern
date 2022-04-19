using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Homework2DrawingSystem.Model;

namespace DrawingSystemApp
{
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        readonly Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            _canvas = canvas;
        }

        //清除
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //畫橢圓
        public void DrawEllipse(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            int sizeX = Math.Abs((int)locationX2 - (int)locationX1);
            int sizeY = Math.Abs((int)locationY2 - (int)locationY1);
            int locationX = Math.Min((int)locationX2, (int)locationX1);
            int locationY = Math.Min((int)locationY2, (int)locationY1);
            Ellipse ellipse = new Ellipse()
            {
                Width = sizeX,
                Height = sizeY,
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(Colors.Orange),
                Margin = new Windows.UI.Xaml.Thickness(locationX, locationY, 0, 0)
            };
            _canvas.Children.Add(ellipse);
        }

        //畫線
        public void DrawLine(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            Line line = new Line()
            {
                X1 = locationX1,
                Y1 = locationY1,
                X2 = locationX2,
                Y2 = locationY2,
                Stroke = new SolidColorBrush(Colors.Black),
            };
            _canvas.Children.Add(line);
        }

        //畫長方形
        public void DrawRectangle(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            int sizeX = Math.Abs((int)locationX2 - (int)locationX1);
            int sizeY = Math.Abs((int)locationY2 - (int)locationY1);
            int locationX = Math.Min((int)locationX2, (int)locationX1);
            int locationY = Math.Min((int)locationY2, (int)locationY1);
            Rectangle rectangle = new Rectangle()
            {
                Width = sizeX,
                Height = sizeY,
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(Colors.DarkGreen),
                Margin = new Windows.UI.Xaml.Thickness(locationX, locationY, 0, 0),
            };
            _canvas.Children.Add(rectangle);
        }

        //畫出長方形邊框
        public void DrawRectangleFrame(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            int sizeX = Math.Abs((int)locationX2 - (int)locationX1);
            int sizeY = Math.Abs((int)locationY2 - (int)locationY1);
            int minLocationX = Math.Min((int)locationX2, (int)locationX1);
            int minLocationY = Math.Min((int)locationY2, (int)locationY1);
            int maxLocationX = Math.Max((int)locationX2, (int)locationX1);
            int maxLocationY = Math.Max((int)locationY2, (int)locationY1);
            Rectangle rectangle = new Rectangle()
            {
                Width = sizeX,
                Height = sizeY,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeDashCap = PenLineCap.Square,
                Margin = new Windows.UI.Xaml.Thickness(minLocationX, minLocationY, 0, 0)
            };
            DrawDot(minLocationX, minLocationY);
            DrawDot(minLocationX, maxLocationY);
            DrawDot(maxLocationX, minLocationY);
            DrawDot(maxLocationX, maxLocationY);
            _canvas.Children.Add(rectangle);
        }

        //畫出橢圓形邊框
        public void DrawEllipseFrame(double locationX1, double locationY1, double locationX2, double locationY2)
        {
            DrawRectangleFrame(locationX1, locationY1, locationX2, locationY2);
        }

        const int TWO = 2;

        //畫點
        private void DrawDot(double locationX, double locationY)
        {
            const float DOT_SIZE = 10.0f;
            Ellipse ellipse = new Ellipse()
            {
                Width = DOT_SIZE,
                Height = DOT_SIZE,
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(Colors.Orange),
                Margin = new Windows.UI.Xaml.Thickness(locationX - DOT_SIZE / TWO, locationY - DOT_SIZE / TWO, 0, 0),
            };
            _canvas.Children.Add(ellipse);
        }
    }
}
