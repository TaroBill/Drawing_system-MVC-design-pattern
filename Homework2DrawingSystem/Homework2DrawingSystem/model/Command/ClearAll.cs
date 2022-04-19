using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model.Command
{
    public class ClearAll : ICommand
    {
        private readonly Model _model;
        private readonly List<IShape> _allShapes;

        public ClearAll(Model model)
        {
            _model = model;
            _allShapes = _model.AllShape.ToList();
        }

        //執行畫線
        public void Execute()
        {
            _model.Clear();
        }

        //刪除畫線
        public void CancelExecute()
        {
            _model.AddBack(_allShapes);
        }
    }
}
