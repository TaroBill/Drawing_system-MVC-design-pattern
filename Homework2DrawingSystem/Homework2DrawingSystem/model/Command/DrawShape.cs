using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Command
{
    public class DrawShape : ICommand
    {
        private readonly Model _model;
        private readonly IShape _shape;

        public DrawShape(IShape shape, Model model)
        {
            _model = model;
            _shape = shape;
        }

        //執行畫線
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        //刪除畫線
        public void CancelExecute()
        {
            _model.DeleteShape(_shape);
        }
    }
}
