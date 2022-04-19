using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Shapes
{
    public class Rectangle : IShape
    {
        private double _locationX1 = 0;
        private double _locationY1 = 0;

        private double _locationX2 = 0;
        private double _locationY2 = 0;

        //畫出長方形
        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_locationX1, _locationY1, _locationX2, _locationY2);
        }

        //畫低優先
        public void DrawPriorityLow(IGraphics graphics)
        {

        }

        //畫高優先
        public void DrawPriorityHigh(IGraphics graphics)
        {

        }

        //畫出邊框(被選擇時用)
        public void DrawFrame(IGraphics graphics)
        {
            graphics.DrawRectangleFrame(_locationX1, _locationY1, _locationX2, _locationY2);
        }

        //設置座標
        public void SetLocation(double locationX, double locationY, double locationX2, double locationY2)
        {
            _locationX1 = locationX;
            _locationY1 = locationY;

            _locationX2 = locationX2;
            _locationY2 = locationY2;
        }

        //設置座標1
        public void SetFirstLocation(double locationX, double locationY)
        {
            _locationX1 = locationX;
            _locationY1 = locationY;
        }

        //設置座標1
        public void SetSecondLocation(double locationX, double locationY)
        {
            _locationX2 = locationX;
            _locationY2 = locationY;
        }

        //取得座標
        public (double, double, double, double) GetLocation()
        {
            return (_locationX1, _locationY1, _locationX2, _locationY2);
        }

        //取得座標
        public (double, double) GetMidpoint()
        {
            return ((_locationX1 + _locationX2) / 2, (_locationY1 + _locationY2) / 2);
        }

        //是否在圖形裡
        public bool Contain(double locationX, double locationY)
        {
            double minimusX = Math.Min(_locationX1, _locationX2);
            double minimusY = Math.Min(_locationY1, _locationY2);
            double maximusX = Math.Max(_locationX1, _locationX2);
            double maximusY = Math.Max(_locationY1, _locationY2);
            return (locationX >= minimusX && locationX <= maximusX && locationY >= minimusY && locationY <= maximusY);
        }

        //移動偏移量
        public void MoveOffset(double offsetX, double offsetY)
        {
            _locationX1 += offsetX;
            _locationX2 += offsetX;
            _locationY1 += offsetY;
            _locationY2 += offsetY;
        }

        //複製
        public IShape Clone()
        {
            return new Rectangle()
            {
                _locationX1 = _locationX1,
                _locationX2 = _locationX2,
                _locationY1 = _locationY1,
                _locationY2 = _locationY2
            };
        }

        //傳回該圖形字串類型資訊
        public override string ToString()
        {
            const string RECTANGLE = "Rectangle";
            const string LEFT_QUOTE = "(";
            const string RIGHT_QUOTE = ")";
            const string COMMA = ",";
            return RECTANGLE + LEFT_QUOTE + _locationX1 + COMMA + _locationY1 + COMMA + _locationX2 + COMMA + _locationY2 + RIGHT_QUOTE;
        }

        //序列化
        public string Serialize()
        {
            return ToString();
        }

        //反序列化
        public void Deserialize(string inputString, Model model = null)//格式為(locationX1,locationY1,locationX2,locationY2)
        {
            const char LEFT_QUOTE = '(';
            const char RIGHT_QUOTE = ')';
            char[] deleteArray = { LEFT_QUOTE, RIGHT_QUOTE };
            const char COMMA = ',';
            const int ZERO = 0;
            const int ONE = 1;
            const int TWO = 2;
            const int THREE = 3;
            string removeQuoteString = inputString.Trim(deleteArray);
            string[] locations = removeQuoteString.Split(COMMA);
            double.TryParse(locations[ZERO], out _locationX1);
            double.TryParse(locations[ONE], out _locationY1);
            double.TryParse(locations[TWO], out _locationX2);
            double.TryParse(locations[THREE], out _locationY2);
        }

        //是否相同
        public bool IsSame(string inputString)
        {
            return inputString == this.ToString();
        }

        //是否相同
        public bool IsSame(IShape shape)
        {
            return IsSame(shape.ToString());
        }
    }
}