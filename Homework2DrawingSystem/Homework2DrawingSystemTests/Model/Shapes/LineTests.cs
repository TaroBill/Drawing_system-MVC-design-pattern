using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2DrawingSystem.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2DrawingSystem.Tests;

namespace Homework2DrawingSystem.Shapes.Tests
{
    [TestClass()]
    public class LineTests
    {
        private Line _line;
        private IShape _shape1;
        private IShape _shape2;
        private PrivateObject _privateObject;
        //init
        [TestInitialize()]
        public void Initialize()
        {
            _line = new Line();
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(10, 20, 30, 40);
            _shape1 = rectangle;
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(100, 200, 300, 400);
            _shape2 = ellipse;
            _line.SetShape1(ref _shape1);
            _line.SetShape2(ref _shape2);
            _privateObject = new PrivateObject(_line);
        }

        //test
        [TestMethod()]
        public void TestDraw()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _line.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);
        }

        //test
        [TestMethod()]
        public void TestDrawPriorityLow()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _line.DrawPriorityLow(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);
        }

        //test
        [TestMethod()]
        public void TestDrawPriorityHigh()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _line.DrawPriorityHigh(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 1);
        }

        //test
        [TestMethod()]
        public void TestDrawFrame()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _line.DrawFrame(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);
        }

        //test
        [TestMethod()]
        public void TestContain()
        {
            Assert.IsFalse(_line.Contain(5, 6));
            Assert.IsFalse(_line.Contain(15, 6));
            Assert.IsFalse(_line.Contain(5, 26));
            Assert.IsFalse(_line.Contain(15, 26));
            Assert.IsFalse(_line.Contain(55, 26));
            Assert.IsFalse(_line.Contain(55, 76));
        }

        //test
        [TestMethod()]
        public void TestSetShape1()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(10, 10, 20, 20);
            IShape shape1 = (IShape)_privateObject.GetFieldOrProperty("_shape1");
            Assert.AreNotEqual(ellipse.ToString(), shape1.ToString());
            IShape ellipseShape = ellipse;
            _line.SetShape1(ref ellipseShape);
            shape1 = (IShape)_privateObject.GetFieldOrProperty("_shape1");
            Assert.AreEqual(ellipse.ToString(), shape1.ToString());
        }

        //test
        [TestMethod()]
        public void TestSetShape2()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(10, 10, 20, 20);
            IShape shape2 = (IShape)_privateObject.GetFieldOrProperty("_shape2");
            Assert.AreNotEqual(rectangle.ToString(), shape2.ToString());
            IShape rectangleShape = rectangle;
            _line.SetShape2(ref rectangleShape);
            shape2 = (IShape)_privateObject.GetFieldOrProperty("_shape2");
            Assert.AreEqual(rectangle.ToString(), shape2.ToString());
        }

        //test
        [TestMethod()]
        public void TestGetMidpoint()
        {
            (double x, double y) = _line.GetMidpoint(); //shape1 = (20, 30) shape2 = (200, 300)
            Assert.AreEqual(110, x, 0.0001);
            Assert.AreEqual(165, y, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestMoveOffset()
        {
            try
            {
                _line.MoveOffset(10, 10);
                Assert.Fail();
            }
            catch 
            {

            }
        }

        //test
        [TestMethod()]
        public void TestClone()
        {
            Line cloneLine = (Line) _line.Clone();
            Assert.AreEqual(cloneLine.ToString(), _line.ToString());
            Assert.AreNotEqual(cloneLine, _line);
        }

        //test
        [TestMethod()]
        public void TestToString()
        {
            string exceptString = "Line(" + _shape1.ToString() + "-" + _shape2.ToString() + ")";
            Assert.AreEqual(exceptString, _line.ToString());
        }

        //test
        [TestMethod()]
        public void TestSerialize()
        {
            string exceptString = "Line(" + _shape1.ToString() + "-" + _shape2.ToString() + ")";
            Assert.AreEqual(exceptString, _line.ToString());
        }

        //test
        [TestMethod()]
        public void TestDeserialize()
        {
            Homework2DrawingSystem.Model.Model model = new Homework2DrawingSystem.Model.Model();
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(100, 200, 300, 400);
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(5, 10, 20, 40);
            string exceptString = "Line(" + rectangle.ToString() + "-" + ellipse.ToString() + ")";
            string inputString = "(" + rectangle.ToString() + "-" + ellipse.ToString() + ")";
            model.DrawShape(rectangle);
            model.DrawShape(ellipse);
            Line line = new Line();
            line.Deserialize(inputString, model);
            Assert.AreEqual(exceptString, line.ToString());
        }

        //test
        [TestMethod()]
        public void TestIsSame()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(10, 20, 30, 40);
            IShape shape1 = rectangle;
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(100, 200, 300, 400);
            IShape shape2 = ellipse;
            line.SetShape1(ref shape1);
            line.SetShape2(ref shape2);
            Assert.AreNotEqual(line, _line);
            Assert.IsTrue(_line.IsSame(line.ToString()));
            ellipse.SetFirstLocation(10, 10);
            Assert.IsFalse(_line.IsSame(line.ToString()));
        }

        //test
        [TestMethod()]
        public void TestIsSame1()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(10, 20, 30, 40);
            IShape shape1 = rectangle;
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(100, 200, 300, 400);
            IShape shape2 = ellipse;
            line.SetShape1(ref shape1);
            line.SetShape2(ref shape2);
            Assert.AreNotEqual(line, _line);
            Assert.IsTrue(_line.IsSame(line));
            ellipse.SetFirstLocation(10, 10);
            Assert.IsFalse(_line.IsSame(line));
        }
    }
}