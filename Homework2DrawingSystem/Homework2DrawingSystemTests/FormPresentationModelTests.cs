using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2DrawingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2DrawingSystem.Model.Shapes;
using Homework2DrawingSystem.Model.Command;

namespace Homework2DrawingSystem.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        private Model.Model _model;
        private FormPresentationModel _formPresentationModel;

        //初始化
        [TestInitialize()]
        public void TestInitialize()
        {
            _model = new Model.Model();
            _formPresentationModel = new FormPresentationModel(_model);
        }

        //測試
        [TestMethod()]
        public void TestFormPresentationModel()
        {
            Assert.IsFalse(_formPresentationModel.UndoButtonEnable);
            Assert.IsFalse(_formPresentationModel.RedoButtonEnable);
            Assert.IsTrue(_formPresentationModel.EllipseButtonEnable);
            Assert.IsTrue(_formPresentationModel.RectangleButtonEnable);
            Assert.IsTrue(_formPresentationModel.LineButtonEnable);
            Assert.IsFalse(_formPresentationModel.MouseButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToRectangle()
        {
            Assert.IsTrue(_formPresentationModel.RectangleButtonEnable);
            _formPresentationModel.ChangeStateToRectangle();
            Assert.IsFalse(_formPresentationModel.RectangleButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToEllipse()
        {
            Assert.IsTrue(_formPresentationModel.EllipseButtonEnable);
            _formPresentationModel.ChangeStateToEllipse();
            Assert.IsFalse(_formPresentationModel.EllipseButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToLine()
        {
            Assert.IsTrue(_formPresentationModel.LineButtonEnable);
            _formPresentationModel.ChangeStateToLine();
            Assert.IsFalse(_formPresentationModel.LineButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestChangeStateToMouse()
        {
            _formPresentationModel.ChangeStateToLine();
            Assert.IsTrue(_formPresentationModel.MouseButtonEnable);
            _formPresentationModel.ChangeStateToMouse();
            Assert.IsFalse(_formPresentationModel.MouseButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestClearAll()
        {
            _formPresentationModel.ChangeStateToEllipse();
            Assert.IsFalse(_formPresentationModel.EllipseButtonEnable);
            _formPresentationModel.ClearAll();
            Assert.IsFalse(_formPresentationModel.EllipseButtonEnable);
            Assert.IsTrue(_formPresentationModel.RectangleButtonEnable);
        }

        //測試
        [TestMethod()]
        public void TestClickUndo()
        {
            try
            {
                _formPresentationModel.ClickUndo();
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "指定的引數超出有效值的範圍。");
            }
            _model.CommandManager.Execute(CommandFactory.DrawShapeCommand(new Line(), _model));
            try
            {
                _formPresentationModel.ClickUndo();
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
                _formPresentationModel.ClickRedo();
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "指定的引數超出有效值的範圍。");
            }
            _model.CommandManager.Execute(CommandFactory.DrawShapeCommand(new Line(), _model));
            _model.CommandManager.Execute(CommandFactory.ClearAllCommand(_model));
            _formPresentationModel.ClickUndo();
            try
            {
                _formPresentationModel.ClickRedo();
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
                _formPresentationModel.NotifyButtonEnableChanged();
            }
            catch
            {
                Assert.Fail();
            }
            _formPresentationModel.ButtonEnableChanged += GetButtonChangedEventNotify;
            try
            {
                _formPresentationModel.NotifyButtonEnableChanged();
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.AreEqual("成功獲取按鈕變更事件", exception.Message);
            }
        }

        //成功獲取按鈕變更事件
        public void GetButtonChangedEventNotify()
        {
            throw new Exception("成功獲取按鈕變更事件");
        }
    }
}