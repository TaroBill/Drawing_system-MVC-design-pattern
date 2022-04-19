using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2DrawingSystem.Model.Shapes;
using Homework2DrawingSystem.Tests;

namespace Homework2DrawingSystem.Shapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        private Rectangle _rectangle;
        private PrivateObject _privateObject;
        //init
        [TestInitialize()]
        public void Initialize()
        {
            _rectangle = new Rectangle();
            _privateObject = new PrivateObject(_rectangle);
        }

        //使用privateObject取得location
        private (double, double, double, double) GetLocationWithPrivateObject()
        {
            double x1 = (double)_privateObject.GetFieldOrProperty("_locationX1");
            double y1 = (double)_privateObject.GetFieldOrProperty("_locationY1");
            double x2 = (double)_privateObject.GetFieldOrProperty("_locationX2");
            double y2 = (double)_privateObject.GetFieldOrProperty("_locationY2");
            return (x1, y1, x2, y2);
        }

        //使用privateObject設置location
        private void SetLocationWithPrivateObject(double x1, double y1, double x2, double y2)
        {
            _privateObject.SetFieldOrProperty("_locationX1", x1);
            _privateObject.SetFieldOrProperty("_locationY1", y1);
            _privateObject.SetFieldOrProperty("_locationX2", x2);
            _privateObject.SetFieldOrProperty("_locationY2", y2);
        }

        //test
        [TestMethod()]
        public void TestDraw()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _rectangle.Draw(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 1);
        }

        //test
        [TestMethod()]
        public void TestDrawPriorityLow()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _rectangle.DrawPriorityLow(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);
        }

        //test
        [TestMethod()]
        public void TestDrawPriorityHigh()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _rectangle.DrawPriorityHigh(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 0);
        }

        //test
        [TestMethod()]
        public void TestDrawFrame()
        {
            MockGraphics graphics = new MockGraphics();
            Assert.AreEqual(graphics.ExecuteTimes, 0);
            _rectangle.DrawFrame(graphics);
            Assert.AreEqual(graphics.ExecuteTimes, 2);
        }

        //test
        [TestMethod()]
        public void TestSetLocation()
        {
            (double x1, double y1, double x2, double y2) = GetLocationWithPrivateObject();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _rectangle.SetLocation(0.2, 0.3, 0.4, 0.5);
            (x1, y1, x2, y2) = GetLocationWithPrivateObject();
            Assert.AreEqual(x1, 0.2, 0.0001);
            Assert.AreEqual(y1, 0.3, 0.0001);
            Assert.AreEqual(x2, 0.4, 0.0001);
            Assert.AreEqual(y2, 0.5, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestSetFirstLocation()
        {
            (double x1, double y1, double x2, double y2) = GetLocationWithPrivateObject();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _rectangle.SetFirstLocation(0.4, 0.5);
            (x1, y1, x2, y2) = GetLocationWithPrivateObject();
            Assert.AreEqual(x1, 0.4, 0.0001);
            Assert.AreEqual(y1, 0.5, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestSetSecondLocation()
        {
            (double x1, double y1, double x2, double y2) = GetLocationWithPrivateObject();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0, 0.0001);
            Assert.AreEqual(y2, 0, 0.0001);
            _rectangle.SetSecondLocation(0.2, 0.1);
            (x1, y1, x2, y2) = GetLocationWithPrivateObject();
            Assert.AreEqual(x1, 0, 0.0001);
            Assert.AreEqual(y1, 0, 0.0001);
            Assert.AreEqual(x2, 0.2, 0.0001);
            Assert.AreEqual(y2, 0.1, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestGetLocation()
        {
            double x1 = 10.5;
            double y1 = 11.2;
            double x2 = 11.3;
            double y2 = 18.7;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            (double resultX1, double resultY1, double resultX2, double resultY2) = _rectangle.GetLocation();
            Assert.AreEqual(x1, resultX1, 0.0001);
            Assert.AreEqual(y1, resultY1, 0.0001);
            Assert.AreEqual(x2, resultX2, 0.0001);
            Assert.AreEqual(y2, resultY2, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestGetMidpoint()
        {
            double x1 = 10;
            double y1 = 20;
            double x2 = 20;
            double y2 = 40;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            (double resultX, double resultY) = _rectangle.GetMidpoint();
            Assert.AreEqual((x1 + x2) / 2, resultX, 0.0001);
            Assert.AreEqual((y1 + y2) / 2, resultY, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestContain()
        {
            double x1 = 10;
            double y1 = 20;
            double x2 = 20;
            double y2 = 40;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            Assert.IsFalse(_rectangle.Contain(5, 6));
            Assert.IsFalse(_rectangle.Contain(15, 6));
            Assert.IsFalse(_rectangle.Contain(5, 26));
            Assert.IsTrue(_rectangle.Contain(15, 26));
            Assert.IsFalse(_rectangle.Contain(55, 26));
            Assert.IsFalse(_rectangle.Contain(55, 76));
        }

        //test
        [TestMethod()]
        public void TestMoveOffset()
        {
            double x1 = 10;
            double y1 = 20;
            double x2 = 20;
            double y2 = 40;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            _rectangle.MoveOffset(10, 5);
            (double resultX1, double resultY1, double resultX2, double resultY2) = _rectangle.GetLocation();
            Assert.AreEqual(x1 + 10, resultX1, 0.0001);
            Assert.AreEqual(y1 + 5, resultY1, 0.0001);
            Assert.AreEqual(x2 + 10, resultX2, 0.0001);
            Assert.AreEqual(y2 + 5, resultY2, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestClone()
        {
            double x1 = 10.3;
            double y1 = 20.1;
            double x2 = 20.5;
            double y2 = 40.6;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            Rectangle cloneRectangle = (Rectangle)_rectangle.Clone();
            (double resultX1, double resultY1, double resultX2, double resultY2) = cloneRectangle.GetLocation();
            Assert.AreEqual(x1, resultX1, 0.0001);
            Assert.AreEqual(y1, resultY1, 0.0001);
            Assert.AreEqual(x2, resultX2, 0.0001);
            Assert.AreEqual(y2, resultY2, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestToString()
        {
            double x1 = 10.3;
            double y1 = 20.1;
            double x2 = 20.5;
            double y2 = 40.6;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            const string EXCEPT_RESULT = "Rectangle(10.3,20.1,20.5,40.6)";
            Assert.AreEqual(EXCEPT_RESULT, _rectangle.ToString());
        }

        //test
        [TestMethod()]
        public void TestSerialize()
        {
            double x1 = 10.3;
            double y1 = 20.1;
            double x2 = 20.5;
            double y2 = 40.6;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            const string EXCEPT_RESULT = "Rectangle(10.3,20.1,20.5,40.6)";
            Assert.AreEqual(EXCEPT_RESULT, _rectangle.Serialize());
        }

        //test
        [TestMethod()]
        public void TestDeserialize()
        {
            double x1 = 10.3;
            double y1 = 20.1;
            double x2 = 20.5;
            double y2 = 40.6;
            const string INPUT = "(10.3,20.1,20.5,40.6)";
            _rectangle.Deserialize(INPUT);
            (double resultX1, double resultY1, double resultX2, double resultY2) = _rectangle.GetLocation();
            Assert.AreEqual(x1, resultX1, 0.0001);
            Assert.AreEqual(y1, resultY1, 0.0001);
            Assert.AreEqual(x2, resultX2, 0.0001);
            Assert.AreEqual(y2, resultY2, 0.0001);
        }

        //test
        [TestMethod()]
        public void TestIsSame()
        {
            double x1 = 10.3;
            double y1 = 20.1;
            double x2 = 20.5;
            double y2 = 40.6;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            const string EXCEPT_RESULT = "Rectangle(10.3,20.1,20.5,40.6)";
            Assert.IsTrue(_rectangle.IsSame(EXCEPT_RESULT));
            const string EXCEPT_RESULT2 = "Rectangle(0,0,0,0)";
            Assert.IsFalse(_rectangle.IsSame(EXCEPT_RESULT2));
        }

        //test
        [TestMethod()]
        public void TestIsSame2()
        {
            double x1 = 10.3;
            double y1 = 20.1;
            double x2 = 20.5;
            double y2 = 40.6;
            SetLocationWithPrivateObject(x1, y1, x2, y2);
            Rectangle rectangle = new Rectangle();
            rectangle.SetLocation(x1, y1, x2, y2);
            Assert.IsTrue(_rectangle.IsSame(rectangle));
            rectangle.SetLocation(0.2, 0.3, 0.4, 0.5);
            Assert.IsFalse(_rectangle.IsSame(rectangle));
        }
    }
}