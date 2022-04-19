using Homework2DrawingSystem.Model.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.States
{
    public static class StateFactory
    {
        public enum StateTypes
        {
            Default,
            DrawLine,
            DrawRectangle,
            DrawEllipse
        }

        //生成一個新的shape
        public static IState GenerateState(StateTypes types, Model model)
        {
            switch (types)
            {
                case StateTypes.Default:
                    return new DefaultState(model);
                case StateTypes.DrawLine:
                    return new DrawLineState(model);
                case StateTypes.DrawRectangle:
                    return new DrawRectangleState(model);
                case StateTypes.DrawEllipse:
                    return new DrawEllipseState(model);
                default:
                    return new DrawLineState(model);
            }
        }
    }
}
