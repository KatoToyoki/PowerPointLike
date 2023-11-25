using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerPointLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PowerPointLike.Models;

namespace PowerPointLike.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        /// <summary>
        /// test if add item works fine
        /// </summary>
        [TestMethod()]
        public void AddItemTest()
        {
            PowerPointLike view = new PowerPointLike(new PresentationModel(new Model()));
            view._presentationModel.AddItem(string.Empty);
            Assert.AreEqual(0, view._presentationModel.GetContainerLength());
            view._presentationModel.AddItem("圓");
            view._presentationModel.AddItem("線");
            view._presentationModel.AddItem("矩形");
            Assert.AreEqual(3, view._presentationModel.GetContainerLength());
        }

        /// <summary>
        /// test if delete item works fine
        /// </summary>
        [TestMethod()]
        public void DeleteCertainElementTest()
        {
            PowerPointLike view = new PowerPointLike(new PresentationModel(new Model()));
            view._presentationModel.AddItem(string.Empty);
            Assert.AreEqual(0, view._presentationModel.GetContainerLength());
            view._presentationModel.AddItem("圓");
            view._presentationModel.AddItem("線");
            view._presentationModel.AddItem("矩形");
            Assert.AreEqual(3, view._presentationModel.GetContainerLength());

            view._presentationModel.DeleteCertainElement(1, 0);
            Assert.AreEqual(3, view._presentationModel.GetContainerLength());
            view._presentationModel.DeleteCertainElement(0, 0);
            Assert.AreEqual(2, view._presentationModel.GetContainerLength());

            view._presentationModel.SetStateSelect();
        }

        /// <summary>
        /// test if draw works fine
        /// </summary>
        [TestMethod()]
        public void DrawTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var mockGraphicsAdaptor = new Mock<IGraphics>();
            
            presentationModel.AddItem("圓");
            presentationModel.AddItem("線");
            presentationModel.AddItem("矩形");
            presentationModel.Draw(mockGraphicsAdaptor.Object);

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            Shape shape1 = new Circle(coordinateSet);
            shape1.Draw(mockGraphicsAdaptor.Object);

            Shape shape2 = new Line(coordinateSet);
            shape2.Draw(mockGraphicsAdaptor.Object);

            Shape shape3 = new Rectangle(coordinateSet);
            shape3.Draw(mockGraphicsAdaptor.Object);

            mockGraphicsAdaptor.Object.DrawLine(coordinateSet);
            mockGraphicsAdaptor.Object.DrawCircle(coordinateSet);
            mockGraphicsAdaptor.Object.DrawRectangle(coordinateSet);
        }

        /// <summary>
        /// test to press
        /// </summary>
        [TestMethod()]
        public void PressMoveReleasePointerTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var mockGraphicsAdaptor = new Mock<IGraphics>();

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(1, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet);

            Assert.AreEqual(3, presentationModel.GetContainerLength());

            presentationModel._model._state._currentStateIndex = 0;
            presentationModel.PressPointer(50, 50);
            presentationModel._model._state._currentStateIndex = 1;
            presentationModel.PressPointer(50, 50);

            presentationModel._model._state._currentStateIndex = 0;
            presentationModel.MovePointer(50, 50);
            presentationModel._model._state._currentStateIndex = 1;
            presentationModel.MovePointer(50, 50);

            presentationModel._model._state._currentStateIndex = 0;
            presentationModel.ReleasePointer(50, 50);
            presentationModel._model._state._currentStateIndex = 1;
            presentationModel.ReleasePointer(50, 50);

            presentationModel.GetModelEvent();
        }

        /// <summary>
        /// test if draw is ready
        /// </summary>
        [TestMethod()]
        public void DrawIsReadyTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var mockGraphicsAdaptor = new Mock<IGraphics>();

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(1, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet);

            Assert.AreEqual(3, presentationModel.GetContainerLength());

            presentationModel._buttonModel._currentButtonIndex = 0;
            Assert.IsTrue(presentationModel.DrawIsReady());

            Assert.IsFalse(presentationModel.GetIfIsDraw());
            presentationModel._model._state._currentStateIndex = 0;
            Assert.IsTrue(presentationModel.GetIfIsDraw());

            Assert.AreEqual(0, presentationModel.GetCurrentStateIndex());

        }

        /// <summary>
        /// test getter
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var mockGraphicsAdaptor = new Mock<IGraphics>();

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(1, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet);

            Assert.AreEqual(3, presentationModel.GetContainerLength());

            presentationModel.GetSelectedOneCoordinate();
            presentationModel.ResetSelectIndex();
            presentationModel.GetContainerLength();
            presentationModel.GetOneElement(0);
            presentationModel.DeleteSelectOne();
            presentationModel.GetAllContainerData();
            presentationModel.GetButtonChecked(0);
            presentationModel.GetButtonChecked(1);
            presentationModel.GetButtonChecked(2);

            presentationModel.ClickLineButton(0);
            presentationModel.ClickCircleButton(1);
            presentationModel.ClickRectangleButton(2);
            presentationModel.ClickMouseButton(-1);

            presentationModel.GetDeleteIndex(0, 0);
            presentationModel.GetDeleteIndex(555, 0);
        }

        /// <summary>
        /// test delete key
        /// </summary>
        [TestMethod()]
        public void KeyTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);
            var mockGraphicsAdaptor = new Mock<IGraphics>();
            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(1, coordinateSet);
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet);

            Assert.AreEqual(3, presentationModel.GetContainerLength());

            var mockSender = new Mock<object>();
            var keyEventArgs = new KeyEventArgs(Keys.Delete);
            view.ClickKey(mockSender.Object, keyEventArgs);

            var bitmap = new Bitmap(500,500);
            var graphics = Graphics.FromImage(bitmap);
            var paintEventArgs = new PaintEventArgs(graphics, new System.Drawing.Rectangle());
            view.ChangeCanvas(mockSender, paintEventArgs);
        }
    }
}