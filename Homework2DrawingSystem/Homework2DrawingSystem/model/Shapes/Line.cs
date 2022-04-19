using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Shapes
{
    public class Line : IShape
    {
        private IShape _shape1;
        private IShape _shape2;

        //畫線
        public void Draw(IGraphics graphics)
        {

        }

        //畫線低優先
        public void DrawPriorityLow(IGraphics graphics)
        {

        }

        //畫線高優先
        public void DrawPriorityHigh(IGraphics graphics)
        {
            (double shape1X, double shape1Y) = _shape1.GetMidpoint();
            (double shape2X, double shape2Y) = _shape2.GetMidpoint();
            graphics.DrawLine(shape1X, shape1Y, shape2X, shape2Y);
        }

        //畫出邊框(被選擇時用)
        public void DrawFrame(IGraphics graphics)
        {
            
        }

        //是否在圖形裡
        public bool Contain(double locationX, double locationY)
        {
            return false;
        }

        //設置第一個圖形
        public void SetShape1(ref IShape shape)
        {
            _shape1 = shape;
        }

        //設置第一個圖形
        public void SetShape2(ref IShape shape)
        {
            _shape2 = shape;
        }

        //取得座標
        public (double, double) GetMidpoint()
        {
            (double shape1X, double shape1Y) = _shape1.GetMidpoint();
            (double shape2X, double shape2Y) = _shape2.GetMidpoint();
            return ((shape1X + shape2X) / 2, (shape1Y + shape2Y) / 2);
        }

        //移動偏移量
        public void MoveOffset(double offsetX, double offsetY)
        {
            throw new NotSupportedException();
        }

        //複製
        public IShape Clone()
        {
            return new Line()
            {
                _shape1 = _shape1,
                _shape2 = _shape2,
            };
        }

        //傳回該圖形字串類型資訊
        public override string ToString()
        {
            const string LINE = "Line";
            const string LEFT_QUOTE = "(";
            const string RIGHT_QUOTE = ")";
            const char COMMA = '-';
            return LINE + LEFT_QUOTE + _shape1.ToString() + COMMA + _shape2.ToString() + RIGHT_QUOTE;
        }

        //序列化
        public string Serialize()
        {
            return ToString();
        }

        //反序列化
        public void Deserialize(string inputString, Model model)//格式為(shape1-shape2)
        {
            const char LEFT_QUOTE = '(';
            const char RIGHT_QUOTE = ')';
            const char COMMA = '-';
            char[] deleteArray = { LEFT_QUOTE, RIGHT_QUOTE };
            string removeQuoteString = inputString.Trim(deleteArray);
            removeQuoteString += RIGHT_QUOTE;//只想刪掉一個，補足回來
            string[] shapes = removeQuoteString.Split(COMMA);
            _shape1 = model.FindShape(shapes[0]);
            _shape2 = model.FindShape(shapes[1]);
        }

        //是否相同
        public bool IsSame(string inputString)
        {
            return inputString == ToString();
        }

        //是否相同
        public bool IsSame(IShape shape)
        {
            return IsSame(shape.ToString());
        }
    }
}