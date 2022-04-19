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
    public class DrawRectangleStateTests
    {
        private DrawRectangleState _drawRectangleState;
        private PrivateObject _drawRectangleStatePrivateObject;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            Model _model = new Model();
            _drawRectangleState = new DrawRectangleState(_model);
            _drawRectangleStatePrivateObject = new PrivateObject(_drawRectangleState);
        }

        //測試
        [TestMethod()]
        public void TestDrawRectangleState()
        {
            Assert.AreEqual(_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint").ToString(), new Rectangle().ToString());
        }

        //測試
        [TestMethod()]
        public void TestMovedPointer()
        {
            Rectangle shape = (Rectangle)_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawRectangleState.PressedPointer(10, 11);
            _drawRectangleState.MovedPointer(100, 101);
            shape = (Rectangle)_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint");
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
            Rectangle shape = (Rectangle)_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawRectangleState.PressedPointer(10, 11);
            shape = (Rectangle)_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint");
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
            Rectangle shape = (Rectangle)_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint");
            var (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _drawRectangleState.PressedPointer(1, 1);
            _drawRectangleState.ReleasedPointer(10, 11);
            shape = (Rectangle)_drawRectangleStatePrivateObject.GetFieldOrProperty("_hint");
            (x1, y1, x2, y2) = shape.GetLocation();
            Assert.AreEqual(x1, 1, 0.0001);
            Assert.AreEqual(y1, 1, 0.0001);
            Assert.AreEqual(x2, 10, 0.0001);
            Assert.AreEqual(y2, 11, 0.0001);
        }

        //測試
        [TestMethod()]
        public void TestDraw()
        {
            MockGraphics graphics = new MockGraphics();
            _drawRectangleState.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);

            _drawRectangleState.PressedPointer(10, 11);
            _drawRectangleState.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 1);
        }
    }
}