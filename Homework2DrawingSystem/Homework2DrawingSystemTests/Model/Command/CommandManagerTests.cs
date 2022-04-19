using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2DrawingSystem.Model.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2DrawingSystem.Model.Shapes;

namespace Homework2DrawingSystem.Model.Command.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        private Model _model;
        private CommandManager _commandManager;

        //初始化
        [TestInitialize()]
        public void TestInitialize()
        {
            _model = new Model();
            _commandManager = _model.CommandManager;
            PrivateObject commandPrivateObject = new PrivateObject(_commandManager);
            ((Stack<ICommand>)commandPrivateObject.GetFieldOrProperty("_redo")).Push(new DrawShape(new Rectangle(), _model));
            ((Stack<ICommand>)commandPrivateObject.GetFieldOrProperty("_undo")).Push(new DrawShape(new Line(), _model));
            ((Stack<ICommand>)commandPrivateObject.GetFieldOrProperty("_undo")).Push(new DrawShape(new Ellipse(), _model));
        }

        //測試
        [TestMethod()]
        public void TestExecute()
        {
            Assert.AreEqual(2, _commandManager.UndoAmount);
            Assert.AreEqual(1, _commandManager.RedoAmount);
            _commandManager.Execute(new DrawShape(new Ellipse(), _model));
            Assert.AreEqual(3, _commandManager.UndoAmount);
            Assert.AreEqual(0, _commandManager.RedoAmount);
        }

        //測試
        [TestMethod()]
        public void TestRedo()
        {
            Assert.AreEqual(2, _commandManager.UndoAmount);
            Assert.AreEqual(1, _commandManager.RedoAmount);
            _commandManager.Redo();
            Assert.AreEqual(3, _commandManager.UndoAmount);
            Assert.AreEqual(0, _commandManager.RedoAmount);
        }

        //測試
        [TestMethod()]
        public void TestUndo()
        {
            Assert.AreEqual(2, _commandManager.UndoAmount);
            Assert.AreEqual(1, _commandManager.RedoAmount);
            _commandManager.Undo();
            Assert.AreEqual(1, _commandManager.UndoAmount);
            Assert.AreEqual(2, _commandManager.RedoAmount);
        }
    }
}