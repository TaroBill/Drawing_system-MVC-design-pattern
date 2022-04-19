using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Shapes
{
    public interface IShape
    {
        //畫出圖形
        void Draw(IGraphics graphics);

        //較慢畫出圖形(會畫在上層)
        void DrawPriorityLow(IGraphics graphics);

        //畫出圖形(會畫在下層)
        void DrawPriorityHigh(IGraphics graphics);

        //畫出邊框(被選擇時用)
        void DrawFrame(IGraphics graphics);

        //移動
        void MoveOffset(double offsetX, double offsetY);

        //是否在圖形裡
        bool Contain(double locationX, double locationY);

        //取得中點座標
        (double, double) GetMidpoint();

        //序列化
        string Serialize();

        //反序列化
        void Deserialize(string inputString, Model model = null);

        //複製
        IShape Clone();

        //是否相同
        bool IsSame(string inputString);

        //是否相同
        bool IsSame(IShape shape);
    }
}