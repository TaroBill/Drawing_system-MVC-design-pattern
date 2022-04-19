using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2DrawingSystem.Model.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2DrawingSystem.Model.Shapes;
using Homework2DrawingSystem.Tests;

namespace Homework2DrawingSystem.Model.States.Tests
{
    [TestClass()]
    public class DrawLineStateTests
    {
        private DrawLineState _drawLineState;
        private PrivateObject _drawLineStatePrivateObject;
        private Model _model;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            Model model = new Model();
            _drawLineState = new DrawLineState(model);
            _model = model;
            Rectangle rectangle = (Rectangle) ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.Rectangle);
            rectangle.SetLocation(100, 100, 200, 200);
            Ellipse ellipse = (Ellipse)ShapeFactory.GenerateShape(ShapeFactory.ShapeTypes.Ellipse);
            ellipse.SetLocation(500, 500, 600, 600);
            _model.DrawShape(rectangle);
            _model.DrawShape(ellipse);
            _drawLineStatePrivateObject = new PrivateObject(_drawLineState);
        }

        //測試
        [TestMethod()]
        public void TestDrawLineState()
        {

        }

        //測試
        [TestMethod()]
        public void TestMovedPointer()
        {
            _drawLineState.PressedPointer(150, 110);
            FreeLine shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 150, 0.0001);
            Assert.AreEqual(y1, 110, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawLineState.MovedPointer(10, 11);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 150, 0.0001);
            Assert.AreEqual(y1, 110, 0.0001);
            Assert.AreEqual(x2, 10, 0.0001);
            Assert.AreEqual(y2, 11, 0.0001);

            _drawLineState.PressedPointer(10, 110);
            _drawLineState.MovedPointer(10, 11);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);
        }

        //測試
        [TestMethod()]
        public void TestPressedPointer()
        {
            FreeLine shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);

            _drawLineState.PressedPointer(10, 11);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);

            _drawLineState.PressedPointer(150, 10);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);

            _drawLineState.PressedPointer(10, 110);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);

            _drawLineState.PressedPointer(150, 110);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 150, 0.0001);
            Assert.AreEqual(y1, 110, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);

            _drawLineState.PressedPointer(300, 110);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);

            _drawLineState.PressedPointer(150, 300);
            shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            Assert.AreEqual(null, shape);
        }

        //測試
        [TestMethod()]
        public void TestReleasedPointer()
        {
            _drawLineState.PressedPointer(150, 110);
            FreeLine shape = (FreeLine)_drawLineStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 150, 0.0001);
            Assert.AreEqual(y1, 110, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            Assert.AreEqual(2, _model.AllShape.Count());
            _drawLineState.ReleasedPointer(10, 560);
            Assert.AreEqual(2, _model.AllShape.Count());

            _drawLineState.PressedPointer(150, 110);
            _drawLineState.ReleasedPointer(10, 10);
            Assert.AreEqual(2, _model.AllShape.Count());

            _drawLineState.PressedPointer(150, 110);
            _drawLineState.ReleasedPointer(150, 110);
            Assert.AreEqual(2, _model.AllShape.Count());

            _drawLineState.PressedPointer(150, 110);
            _drawLineState.ReleasedPointer(550, 700);
            Assert.AreEqual(2, _model.AllShape.Count());

            _drawLineState.PressedPointer(150, 110);
            _drawLineState.ReleasedPointer(700, 700);
            Assert.AreEqual(2, _model.AllShape.Count());

            _drawLineState.PressedPointer(150, 110);
            _drawLineState.ReleasedPointer(550, 560);
            Assert.AreEqual(3, _model.AllShape.Count());
        }

        //測試
        [TestMethod()]
        public void TestDraw()
        {
            MockGraphics graphics = new MockGraphics();
            _drawLineState.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);

            _drawLineState.PressedPointer(150, 110);
            _drawLineState.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 1);
        }
    }
}