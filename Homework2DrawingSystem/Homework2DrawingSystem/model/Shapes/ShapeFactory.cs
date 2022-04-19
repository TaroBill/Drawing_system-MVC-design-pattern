using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Shapes
{
    public static class ShapeFactory
    {
        public enum ShapeTypes
        {
            Line,
            FreeLine,
            Rectangle,
            Ellipse
        }

        //生成一個新的shape
        public static IShape GenerateShape(ShapeTypes types)
        {
            switch (types)
            {
                case ShapeTypes.Line:
                    return new Line();
                case ShapeTypes.FreeLine:
                    return new FreeLine();
                case ShapeTypes.Rectangle:
                    return new Rectangle();
                case ShapeTypes.Ellipse:
                    return new Ellipse();
                default:
                    return new FreeLine();
            }
        }

        //依靠reflection創建shape
        public static IShape GenerateShape(string name)
        {
            const string ASSEMBLY_NAME = "Homework2DrawingSystem";
            string className = ASSEMBLY_NAME + ".Model.Shapes." + name;
            return (IShape) Assembly.Load(ASSEMBLY_NAME).CreateInstance(className);
        }
    }
}
