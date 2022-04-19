using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Homework2DrawingSystem.Model.States;
using Homework2DrawingSystem.Model.Shapes;
using Homework2DrawingSystem.Tests;
using System.IO;

namespace Homework2DrawingSystem.Model.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private Model _model;
        private PrivateObject _modelPrivateObject;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _modelPrivateObject = new PrivateObject(_model);
        }

        //測試
        [TestMethod()]
        public void TestModel()
        {

        }

        //測試
        [TestMethod()]
        public void TestChangeState()
        {
            IState state = (IState) _modelPrivateObject.GetFieldOrProperty("_nowState");
            Assert.AreEqual(state.ToString(), new DefaultState(_model).ToString());
            _model.ChangeState(States.StateFactory.StateTypes.DrawLine);
            state = (IState)_modelPrivateObject.GetFieldOrProperty("_nowState");
            Assert.AreEqual(state.ToString(), new DrawLineState(_model).ToString());
        }

        //測試
        [TestMethod()]
        public void TestPressedPointer()
        {
            _model.PressedPointer(0, 0);
            _model.PressedPointer(0, 1);
            _model.PressedPointer(1, 0);
            _model.PressedPointer(1, 1);
            //too easy to test
        }

        //測試
        [TestMethod()]
        public void TestMovedPointer()
        {
            _model.PressedPointer(10, 10);
            _model.ModelChanged += ModelChanged;
            try
            {
                _model.MovedPointer(10, 11);
            }
            catch(Exception exception)
            {
                Assert.AreEqual(exception.Message, "確定有觸發事件");
            }
        }

        //測試
        [TestMethod()]
        public void TestReleasedPointer()
        {
            _model.PressedPointer(10, 10);
            _model.ModelChanged += ModelChanged;
            try
            {
                _model.ReleasedPointer(10, 11);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "確定有觸發事件");
            }
        }

        //測試
        [TestMethod()]
        public void TestClear()
        {
            Assert.AreEqual(_model.AllShape.Count, 0);
            _model.DrawShape(new Line());
            _model.DrawShape(new Rectangle());
            _model.DrawShape(new Ellipse());
            Assert.AreEqual(_model.AllShape.Count, 3);
            _model.Clear();
            Assert.AreEqual(_model.AllShape.Count, 0);
        }

        //測試
        [TestMethod()]
        public void TestAddBack()
        {
            Assert.AreEqual(_model.AllShape.Count, 0);
            _model.DrawShape(new Line());
            _model.DrawShape(new Rectangle());
            _model.DrawShape(new Ellipse());
            Assert.AreEqual(_model.AllShape.Count, 3);
            List<IShape> shapes = _model.AllShape.ToList();
            _model.Clear();
            Assert.AreEqual(_model.AllShape.Count, 0);
            _model.AddBack(shapes);
            Assert.AreEqual(_model.AllShape.Count, 3);
        }

        //測試
        [TestMethod()]
        public void TestDraw()
        {
            _model.DrawShape(new FreeLine());
            _model.DrawShape(new Rectangle());
            _model.DrawShape(new Ellipse());
            MockGraphics mockGraphics = new MockGraphics();
            _model.Draw(mockGraphics);
            Assert.AreEqual(mockGraphics.ExecuteTimes, 3);
            _model.DrawShape(new Ellipse());
            _model.Draw(mockGraphics);
            Assert.AreEqual(mockGraphics.ExecuteTimes, 4);
            _model.ChangeState(StateFactory.StateTypes.DrawRectangle);
            _model.PressedPointer(10, 10);
            _model.MovedPointer(20, 20);
            _model.Draw(mockGraphics);
            Assert.AreEqual(mockGraphics.ExecuteTimes, 5);
        }

        //測試
        [TestMethod()]
        public void TestDrawShape()
        {
            Line line = new Line();
            Assert.AreEqual(_model.AllShape.Count, 0);
            _model.DrawShape(line);
            Assert.AreEqual(_model.AllShape.Count, 1);
            Assert.AreEqual(_model.AllShape[0], line);
        }

        //測試
        [TestMethod()]
        public void TestDeleteShape()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            _model.AllShape.Add(line);
            _model.AllShape.Add(rectangle);
            Assert.AreEqual(_model.AllShape.Count, 2);
            Assert.AreEqual(_model.AllShape[0], line);
            _model.DeleteShape(line);
            Assert.AreEqual(_model.AllShape.Count, 1);
            Assert.AreEqual(_model.AllShape[0], rectangle);
        }

        //測試
        [TestMethod()]
        public void TestGetShape()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(10, 10, 20, 20);
            _model.DrawShape(rectangle);
            IShape shape = _model.GetShape(5, 5);
            Assert.IsTrue(shape == null);
            shape = _model.GetShape(5, 11);
            Assert.IsTrue(shape == null);
            shape = _model.GetShape(11, 5);
            Assert.IsTrue(shape == null);
            shape = _model.GetShape(11, 11);
            Assert.IsTrue(shape == rectangle);
            shape = _model.GetShape(11, 25);
            Assert.IsTrue(shape == null);
            shape = _model.GetShape(25, 11);
            Assert.IsTrue(shape == null);
            shape = _model.GetShape(25, 25);
            Assert.IsTrue(shape == null);
        }

        //製造shape資料
        private void PrepareShapes()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(10, 10, 20, 20);
            _model.DrawShape(rectangle);
            Rectangle rectangle1 = new Rectangle();
            rectangle1.SetLocation(1, 2, 3, 4);
            _model.DrawShape(rectangle1);
            Rectangle rectangle2 = new Rectangle();
            rectangle2.SetLocation(50, 100, 200, 200);
            _model.DrawShape(rectangle2);
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(10, 20, 40, 40);
            _model.DrawShape(ellipse);
            IShape ellipseShape = ellipse;
            IShape rectangleShape = rectangle2;
            Line line = new Line();
            line.SetShape1(ref ellipseShape);
            line.SetShape2(ref rectangleShape);
            _model.DrawShape(line);
        }

        //測試
        [TestMethod()]
        public void TestSaveAndLoadFile()
        {
            PrepareShapes();
            Assert.AreEqual(5, _model.AllShape.Count());
            _model.SaveToFile();
            _model.Clear();
            Assert.AreEqual(0, _model.AllShape.Count());
            _model.LoadFromFile();
            Assert.AreEqual(5, _model.AllShape.Count());
        }

        //訂閱modelChanged
        private void ModelChanged()
        {
            throw new Exception("確定有觸發事件");
        }
    }
}