using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Command
{
    public static class CommandFactory
    {
        //private const string ASSEMBLY_NAME = "Homework2DrawingSystem.Model.Command.";

        /*//生成畫線指令
        public static ICommand DrawLineCommand(string command, Shape shape, Model model)
        {
            string className = ASSEMBLY_NAME + command;
            return (ICommand) Assembly.Load(ASSEMBLY_NAME).CreateInstance(className);
        }*/

        //生成畫線指令
        public static ICommand DrawShapeCommand(IShape shape, Model model)
        {
            return new DrawShape(shape, model);
        }

        //清除全部指令
        public static ICommand ClearAllCommand(Model model)
        {
            return new ClearAll(model);
        }

        //移動指令
        public static ICommand MoveShapeCommand(Model model, IShape shape, double offsetX, double offsetY)
        {
            return new MoveShape(shape, offsetX, offsetY, model);
        }
    }
}
