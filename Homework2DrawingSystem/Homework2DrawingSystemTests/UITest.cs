using Homework2DrawingSystem.Model.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Homework2DrawingSystem.Tests
{
    [TestClass]
    public class UITest
    {
        private Robot _startUpRobot;
        private string targetAppPath;
        private const string DRAWING_FORM = "DrawingForm";

        // init
        [TestInitialize]
        public void Initialize()
        {
            var projectName = "Homework2DrawingSystem";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "Homework2DrawingSystem.exe");
            _startUpRobot = new Robot(targetAppPath, DRAWING_FORM);
        }

        //清除程式
        [TestCleanup()]
        public void Cleanup()
        {
            _startUpRobot.CleanUp();
        }

        //測試
        [TestMethod]
        public void TestDrawRectangle()
        {
            Rectangle exceptRectangle = new Rectangle();
            exceptRectangle.SetLocation(49, 49, 99, 99);
            _startUpRobot.ClickButton("Rectangle");
            _startUpRobot.DragAndDrop("_canvas", 50, 50, 100, 100);
            _startUpRobot.Sleep(1);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptRectangle.ToString());
        }

        //測試
        [TestMethod]
        public void TestDrawEllipse()
        {
            Ellipse exceptShape = new Ellipse();
            exceptShape.SetLocation(49, 49, 99, 99);
            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 50, 50, 100, 100);
            _startUpRobot.Sleep(1);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptShape.ToString());
        }

        //測試
        [TestMethod]
        public void TestClear()
        {
            Ellipse exceptShape = new Ellipse();
            exceptShape.SetLocation(49, 49, 99, 99);
            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 50, 50, 100, 100);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptShape.ToString());

            Rectangle exceptRectangle = new Rectangle();
            exceptRectangle.SetLocation(49, 100, 99, 199);
            _startUpRobot.ClickButton("Rectangle");
            _startUpRobot.DragAndDrop("_canvas", 50, 101, 100, 200);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptRectangle.ToString());

            _startUpRobot.ClickButton("Mouse");
            _startUpRobot.DragAndDrop("_canvas", 75, 150, 75, 150);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptRectangle.ToString());

            _startUpRobot.DragAndDrop("_canvas", 75, 75, 75, 75);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptShape.ToString());

            _startUpRobot.Sleep(0.3);
            _startUpRobot.ClickButton("Clear");
            _startUpRobot.DragAndDrop("_canvas", 75, 150, 75, 150);
            _startUpRobot.AssertText("_selectedShapeLabel", "Not Selected any Shape");

            _startUpRobot.DragAndDrop("_canvas", 75, 75, 75, 75);
            _startUpRobot.AssertText("_selectedShapeLabel", "Not Selected any Shape");

            _startUpRobot.Sleep(1);
        }

        //測試
        [TestMethod]
        public void TestUndoAndRedo()
        {
            Rectangle exceptRectangle = new Rectangle();
            exceptRectangle.SetLocation(49, 100, 99, 199);

            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 50, 50, 100, 100);
            _startUpRobot.ClickButton("Rectangle");
            _startUpRobot.DragAndDrop("_canvas", 50, 101, 100, 200);

            _startUpRobot.Sleep(1);
            _startUpRobot.ClickButton("Clear");
            _startUpRobot.ClickButton("Mouse");

            _startUpRobot.DragAndDrop("_canvas", 75, 150, 75, 150);
            _startUpRobot.AssertText("_selectedShapeLabel", "Not Selected any Shape");
            _startUpRobot.Sleep(1);
            _startUpRobot.ClickButton("Undo");
            _startUpRobot.DragAndDrop("_canvas", 75, 150, 75, 150);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptRectangle.ToString());
            _startUpRobot.Sleep(1);
            _startUpRobot.ClickButton("Redo");
            _startUpRobot.DragAndDrop("_canvas", 75, 150, 75, 150);
            _startUpRobot.AssertText("_selectedShapeLabel", "Not Selected any Shape");
            _startUpRobot.Sleep(1);
        }

        //測試
        [TestMethod]
        public void TestDrawLine()
        {
            Ellipse ellipse1 = new Ellipse();
            ellipse1.SetLocation(49, 49, 99, 99);
            Ellipse ellipse2 = new Ellipse();
            ellipse2.SetLocation(199, 199, 299, 299);
            IShape shape1 = ellipse1;
            IShape shape2 = ellipse2;

            Line exceptLine = new Line();
            exceptLine.SetShape1(ref shape1);
            exceptLine.SetShape2(ref shape2);

            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 50, 50, 100, 100);
            _startUpRobot.Sleep(1);
            _startUpRobot.DragAndDrop("_canvas", 200, 200, 300, 300);
            _startUpRobot.Sleep(1);
            _startUpRobot.ClickButton("Line");
            _startUpRobot.DragAndDrop("_canvas", 80, 80, 250, 250);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptLine.ToString());
        }

        //測試
        [TestMethod]
        public void TestMoveShape()
        {
            Ellipse ellipse1 = new Ellipse();
            ellipse1.SetLocation(49, 49, 99, 99);
            Ellipse ellipse2 = new Ellipse();
            ellipse2.SetLocation(49, 78, 99, 128);
            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 50, 50, 100, 100);
            _startUpRobot.AssertText("_selectedShapeLabel", ellipse1.ToString());
            _startUpRobot.ClickButton("Mouse");
            _startUpRobot.DragAndDrop("_canvas", 80, 80, 80, 110);
            _startUpRobot.AssertText("_selectedShapeLabel", ellipse2.ToString());
        }

        //測試
        [TestMethod]
        public void TestDrawSnowman()
        {
            Ellipse exceptShape = new Ellipse();//測試頭
            exceptShape.SetLocation(299, 92, 485, 278);

            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 200, 250, 586, 636);//身體
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 300, 93, 486, 279);//頭
            _startUpRobot.Sleep(0.3);

            _startUpRobot.ClickButton("Mouse");
            _startUpRobot.DragAndDrop("_canvas", 350, 150, 350, 150);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptShape.ToString());

            _startUpRobot.ClickButton("Rectangle");
            _startUpRobot.DragAndDrop("_canvas", 275, 50, 511, 133);//帽子上端
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 200, 133, 586, 150);//帽子下端
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 175, 200, 200, 443);//左手
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 586, 200, 611, 443);//右手
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 380, 240, 406, 260);//嘴吧
            _startUpRobot.ClickButton("Ellipse");
            _startUpRobot.DragAndDrop("_canvas", 337, 150, 377, 190);//左眼
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 409, 150, 449, 190);//右眼
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 360, 300, 426, 360);//身體鈕扣1
            _startUpRobot.Sleep(0.3);
            _startUpRobot.DragAndDrop("_canvas", 360, 400, 426, 460);//身體鈕扣2
            _startUpRobot.Sleep(1);


            Rectangle exceptHand = new Rectangle();//測試左手
            exceptShape.SetLocation(174, 199, 199, 442);
            _startUpRobot.ClickButton("Mouse");
            _startUpRobot.DragAndDrop("_canvas", 180, 300, 180, 300);
            _startUpRobot.AssertText("_selectedShapeLabel", exceptHand.ToString());
        }
    }
}
