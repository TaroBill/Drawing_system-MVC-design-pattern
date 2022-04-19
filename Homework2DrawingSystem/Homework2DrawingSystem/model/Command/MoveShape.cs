using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Command
{
    public class MoveShape : ICommand
    {
        private readonly IShape _shape;
        private readonly double _offSetX;
        private readonly double _offSetY;
        private readonly Model _model;

        public MoveShape(IShape shape, double offSetX, double offSetY, Model model)
        {
            _model = model;
            _shape = shape;
            _offSetX = offSetX;
            _offSetY = offSetY;
        }

        //取消移動
        public void CancelExecute()
        {
            _shape.MoveOffset(0 - _offSetX, 0 - _offSetY);
            _model.NotifyModelChanged();
        }

        //移動
        public void Execute()
        {
            _shape.MoveOffset(_offSetX, _offSetY);
            _model.NotifyModelChanged();
        }
    }
}
