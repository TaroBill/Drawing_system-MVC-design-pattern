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
    public class DrawEllipseStateTests
    {
        private DrawEllipseState _drawEllipseState;
        private PrivateObject _drawEllipseStatePrivateObject;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            Model _model = new Model();
            _drawEllipseState = new DrawEllipseState(_model);
            _drawEllipseStatePrivateObject = new PrivateObject(_drawEllipseState);
        } 

        //測試
        [TestMethod()]
        public void TestDrawEllipseState()
        {
            Assert.AreEqual(_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint").ToString(), new Ellipse().ToString());
        }

        //測試
        [TestMethod()]
        public void TestMovedPointer()
        {
            Ellipse shape = (Ellipse)_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawEllipseState.PressedPointer(10, 11);
            _drawEllipseState.MovedPointer(100, 101);
            shape = (Ellipse)_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint");
            (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 10, 0.0001);
            Assert.AreEqual(y1, 11, 0.0001);
            Assert.AreEqual(x2, 100, 0.0001);
            Assert.AreEqual(y2, 101, 0.0001);
        }

        //測試
        [TestMethod()]
        public void TestPressedPointer()
        {
            Ellipse shape = (Ellipse)_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawEllipseState.PressedPointer(10, 11);
            shape = (Ellipse)_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint");
            (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 10, 0.0001);
            Assert.AreEqual(y1, 11, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
        }

        //測試
        [TestMethod()]
        public void TestReleasedPointer()
        {
            Ellipse shape = (Ellipse)_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawEllipseState.PressedPointer(10, 11);
            _drawEllipseState.ReleasedPointer(100, 110);
            shape = (Ellipse)_drawEllipseStatePrivateObject.GetFieldOrProperty("_hint");
            (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 10, 0.0001);
            Assert.AreEqual(y1, 11, 0.0001);
            Assert.AreEqual(x2, 100, 0.0001);
            Assert.AreEqual(y2, 110, 0.0001);
        }

        //測試
        [TestMethod()]
        public void TestDraw()
        {
            MockGraphics graphics = new MockGraphics();
            _drawEllipseState.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);

            _drawEllipseState.PressedPointer(10, 11);
            _drawEllipseState.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 1);
        }
    }
}