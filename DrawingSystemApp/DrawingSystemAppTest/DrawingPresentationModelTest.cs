using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2DrawingSystem.Model;
using System;
using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.Shapes;

namespace DrawingSystemApp.Test
{
    [TestClass]
    public class DrawingPresentationModelTest
    {
        private Model _model;
        private DrawingPresentationModel _presentationModel;

        //測試
        [TestInitialize()]
        public void TestInitialize()
        {
            _model = new Model();
            _presentationModel = new DrawingPresentationModel(_model);
        }

        //測試
        [TestMethod()]
        public void TestFormPresentationModel()
        {
            Assert.IsFalse(_presentationModel.UndoButtonEnable);
            Assert.IsFalse(_presentationModel.RedoButtonEnable);
            Assert.IsTrue(_presentationModel.EclipseButtonEnable);
            Assert.IsTrue(_presentationModel.RectangleButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToRectangle()
        {
            Assert.IsTrue(_presentationModel.RectangleButtonEnable);
            _presentationModel.ChangeStateToRectangle();
            Assert.IsFalse(_presentationModel.RectangleButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToEllipse()
        {
            Assert.IsTrue(_presentationModel.EclipseButtonEnable);
            _presentationModel.ChangeStateToEllipse();
            Assert.IsFalse(_presentationModel.EclipseButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToLine()
        {
            Assert.IsTrue(_presentationModel.LineButtonEnable);
            _presentationModel.ChangeStateToLine();
            Assert.IsFalse(_presentationModel.LineButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToMouse()
        {
            _presentationModel.ChangeStateToEllipse();
            Assert.IsTrue(_presentationModel.EclipseButtonEnable);
            Assert.IsTrue(_presentationModel.MouseButtonEnable);
            _presentationModel.ChangeStateToMouse();
            Assert.IsFalse(_presentationModel.MouseButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestClearAll()
        {
            _presentationModel.ChangeStateToEllipse();
            Assert.IsFalse(_presentationModel.EclipseButtonEnable);
            _presentationModel.ClearAll();
            Assert.IsFalse(_presentationModel.EclipseButtonEnable);
            Assert.IsTrue(_presentationModel.RectangleButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestClickUndo()
        {
            try
            {
                _presentationModel.ClickUndo();
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, new ArgumentOutOfRangeException().Message);
            }
            _model.CommandManager.Execute(CommandFactory.DrawShapeCommand(new Line(), _model));
            try
            {
                _presentationModel.ClickUndo();
            }
            catch
            {
                Assert.Fail();
            }
        }

        //測試
        [TestMethod()]
        public void TestClickRedo()
        {
            try
            {
                _presentationModel.ClickRedo();
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, new ArgumentOutOfRangeException().Message);
            }
            _model.CommandManager.Execute(CommandFactory.DrawShapeCommand(new Line(), _model));
            _model.CommandManager.Execute(CommandFactory.ClearAllCommand(_model));
            _presentationModel.ClickUndo();
            try
            {
                _presentationModel.ClickRedo();
            }
            catch
            {
                Assert.Fail();
            }
        }

        //測試
        [TestMethod()]
        public void TestDraw()
        {
            //too easy to test
        }

        //測試
        [TestMethod()]
        public void TestNotifyButtonEnableChanged()
        {
            try
            {
                _presentationModel.NotifyButtonEnableChanged();
            }
            catch
            {
                Assert.Fail();
            }
            _presentationModel.ButtonEnableChanged += GetButtonChangedEventNotify;
            try
            {
                _presentationModel.NotifyButtonEnableChanged();
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Success call Button", exception.Message);
            }
        }

        //測試
        public void GetButtonChangedEventNotify()
        {
            throw new Exception("Success call Button");
        }
    }
}
