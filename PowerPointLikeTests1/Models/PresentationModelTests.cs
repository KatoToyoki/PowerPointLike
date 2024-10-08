﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            view._presentationModel.AddItem(string.Empty, 0, 1);
            Assert.AreEqual(0, view._presentationModel.GetContainerLength());
            view._presentationModel.AddItem("圓", 0, 1);
            view._presentationModel.AddItem("線", 0, 2);
            view._presentationModel.AddItem("矩形", 0, 3);
            Assert.AreEqual(3, view._presentationModel.GetContainerLength());
        }

        /// <summary>
        /// test if delete item works fine
        /// </summary>
        [TestMethod()]
        public void DeleteCertainElementTest()
        {
            PowerPointLike view = new PowerPointLike(new PresentationModel(new Model()));
            view._presentationModel.AddItem(string.Empty, 0, 1);
            Assert.AreEqual(0, view._presentationModel.GetContainerLength());
            view._presentationModel.AddItem("圓", 0, 1);
            view._presentationModel.AddItem("線", 0, 2);
            view._presentationModel.AddItem("矩形", 0, 3);
            Assert.AreEqual(3, view._presentationModel.GetContainerLength());

            view._presentationModel.DeleteCertainElement("圓", 1, 1);
            Assert.AreEqual(3, view._presentationModel.GetContainerLength());
            view._presentationModel.DeleteCertainElement("圓", 0, 1);
            Assert.AreEqual(2, view._presentationModel.GetContainerLength());

            view._presentationModel.ResetStateSelect();
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

            presentationModel.AddItem("圓", 0, 1);
            presentationModel.AddItem("線", 0, 2);
            presentationModel.AddItem("矩形", 0, 3);
            presentationModel.Draw(mockGraphicsAdaptor.Object);

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            Shape shape1 = new Circle(coordinateSet, presentationModel._model._shapes._factory);
            shape1.Draw(mockGraphicsAdaptor.Object);

            Shape shape2 = new Line(coordinateSet, presentationModel._model._shapes._factory);
            shape2.Draw(mockGraphicsAdaptor.Object);

            Shape shape3 = new Rectangle(coordinateSet, presentationModel._model._shapes._factory);
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
            Assert.IsTrue(presentationModel.IsDrawReady());

            Assert.IsFalse(presentationModel.IsDraw());
            presentationModel._model._state._currentStateIndex = 0;
            Assert.IsTrue(presentationModel.IsDraw());

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

            Coordinate a = new Coordinate(0, 0);
            Coordinate b = new Coordinate(0, 1);
            Coordinate c = new Coordinate(0, 1);
            CoordinateSet A = new CoordinateSet(b, a);
            CoordinateSet B = new CoordinateSet(b, c);
            A.GetIfIsSame(B);
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

            var bitmap = new Bitmap(500, 500);
            var graphics = Graphics.FromImage(bitmap);
            var paintEventArgs = new PaintEventArgs(graphics, new System.Drawing.Rectangle());
            view.ChangeCanvas(mockSender, paintEventArgs);

            CoordinateSet coordinateSet2 = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSet2);
            presentationModel._model._shapes.AddShapeInEnd(1, coordinateSet2);
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet2);

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

            presentationModel.DrawSelectFrame(paintEventArgs);
        }

        /// <summary>
        /// test delete key
        /// </summary>
        [TestMethod()]
        public void ScaleTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);
            var mockGraphicsAdaptor = new Mock<IGraphics>();
            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet);

            presentationModel._buttonModel.ClickLineButton(0);
            presentationModel.DetectButtonDraw();
            presentationModel.DetectScale(50, 50);
            presentationModel.DetectScale(97, 97);

            presentationModel._model._state._currentStateIndex = 0;
            presentationModel._stateModel.IsScale(97, 97);

            presentationModel._buttonModel.ClickMouseButton(-1);
            presentationModel.DetectButtonDraw();
            presentationModel._buttonModel._currentButtonIndex = -1;
            presentationModel._model._state._currentStateIndex = 1;

            presentationModel.DetectScale(50, 50);

            presentationModel._model._selectedOneCoordinate = coordinateSet;
            presentationModel.DetectScale(97, 97);

            Assert.AreEqual(1, presentationModel._model._state._currentStateIndex);
        }

        /// <summary>
        /// test delete key
        /// </summary>
        [TestMethod()]
        public void ScaleTest2()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);

            presentationModel._model._shapes.ChangeCoordinate(0, 1, 1);
            presentationModel._model._shapes.ScaleCoordinate(0, 1, 1);

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(2, coordinateSet);
            Assert.AreEqual(1, presentationModel.GetContainerLength());

            presentationModel._model._shapes.ScaleCoordinate(-1, 1, 1);

            presentationModel._model._state._currentStateIndex = (int)State.StateIndex.Select;

            presentationModel.PressPointer(97, 97);

            presentationModel._model._state._isPressed = false;
            presentationModel._model._state._isScale = false;
            presentationModel.MovePointer(95, 95);

            presentationModel._model._state._isPressed = true;
            presentationModel._model._state._isScale = true;
            presentationModel.MovePointer(95, 95);

            CoordinateSet coordinateSetaa = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSetaa);
            presentationModel._model._selectedShape = presentationModel._model._shapes.GetShape(presentationModel._model._shapes.GetContainerLength()-1);
            presentationModel.DetectScale(97, 97);

            presentationModel._model._shapes.AddShapeInEnd(0, coordinateSetaa);
            Shape newShape = presentationModel._model._selectedShape;

            presentationModel.ReleasePointer(90, 90);

            presentationModel.PressPointer(200, 200);
            presentationModel._model._state._isPressed = false;
            presentationModel._model._state._index = -1;
            presentationModel.MovePointer(200, 200);

            presentationModel._model._state._isPressed = true;
            presentationModel._model._state._index = 0;
            presentationModel.MovePointer(200, 200);

            presentationModel.ReleasePointer(300, 300);

            presentationModel._model._shapes.ExchangeShape(presentationModel._model._selectedShape, newShape);
        }

        /// <summary>
        /// test if drawing command works successfully
        /// </summary>
        [TestMethod()]
        public void DrawingCommandTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);
            var mockGraphicsAdaptor = new Mock<IGraphics>();
            var mockSender = new Mock<object>();
            var mockMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 0, 5, 5, 50);
            var mockMouseEventArgs2 = new MouseEventArgs(MouseButtons.Left, 0, 50, 50, 100);
            var mockMouseEventArgs3 = new MouseEventArgs(MouseButtons.Left, 0, 100, 100, 150);

            presentationModel.AddItem("圓", 0, 1);
            presentationModel.AddItem("線", 0, 2);
            presentationModel.AddItem("矩形", 0, 3);
            presentationModel.Draw(mockGraphicsAdaptor.Object);

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            Shape shape1 = new Circle(coordinateSet, presentationModel._model._shapes._factory);
            shape1.Draw(mockGraphicsAdaptor.Object);

            Shape shape2 = new Line(coordinateSet, presentationModel._model._shapes._factory);
            shape2.Draw(mockGraphicsAdaptor.Object);

            Shape shape3 = new Rectangle(coordinateSet, presentationModel._model._shapes._factory);
            shape3.Draw(mockGraphicsAdaptor.Object);

            mockGraphicsAdaptor.Object.DrawLine(coordinateSet);
            mockGraphicsAdaptor.Object.DrawCircle(coordinateSet);
            mockGraphicsAdaptor.Object.DrawRectangle(coordinateSet);

            var mockEventArgs = new EventArgs();

            view._presentationModel._buttonModel._currentButtonIndex = 0;
            view._presentationModel._model._state._currentStateIndex = 0;
            view.HandleCanvasPressed(mockSender, mockMouseEventArgs);
            view.HandleCanvasMoved(mockSender, mockMouseEventArgs2);
            view.HandleCanvasReleased(mockSender, mockMouseEventArgs3);

            view._presentationModel._model._commandManager.Execute(new DrawingCommand(view._presentationModel._model, shape1));
            view._presentationModel._model._commandManager.Execute(new DrawingCommand(view._presentationModel._model, shape2));

            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            var mockSplitterEventArgs = new SplitterEventArgs(100, 100, 500, 500);
            view.MoveSplitDrawingDataContainer(mockSender, mockSplitterEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
        }

        /// <summary>
        /// test if data grid view comamand works successfully
        /// </summary>
        [TestMethod()]
        public void DataGridViewCommandTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);
            var mockGraphicsAdaptor = new Mock<IGraphics>();
            var mockSender = new Mock<object>();
            var mockEventArgs = new EventArgs();
            var mockDataGridViewCellEventArgs = new DataGridViewCellEventArgs(columnIndex: 0, rowIndex: 1);

            view.SetTextOnChoiceBox("圓");
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);

            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            view.DeleteElement(mockSender, mockDataGridViewCellEventArgs);
            view.DeleteElement(mockSender, mockDataGridViewCellEventArgs);

            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            var mockSplitterEventArgs = new SplitterEventArgs(100, 100, 500, 500);
            view.MoveSplitDrawingDataContainer(mockSender, mockSplitterEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
        }

        /// <summary>
        /// test if point command works successfully
        /// </summary>
        [TestMethod()]
        public void ExceptionTest() {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);
            var mockSender = new Mock<object>();
            var mockEventArgs = new EventArgs();
            var mockDataGridViewCellEventArgs = new DataGridViewCellEventArgs(columnIndex: 0, rowIndex: 1);
            var mockMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 0, 5, 5, 50);

            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            var mockGraphicsAdaptor = new Mock<IGraphics>();
            view._presentationModel._model._state.DrawTempShape(mockGraphicsAdaptor.Object);

            view.HandleCanvasPressed(mockSender, mockMouseEventArgs);
            view.HandleCanvasMoved(mockSender, mockMouseEventArgs);
            view.HandleCanvasReleased(mockSender, mockMouseEventArgs);

            presentationModel._model._shapes.DeleteCertainElement(0, 0);
            presentationModel._model._shapes.CreateTempShape("???");

            view.SetTextOnChoiceBox("圓");
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);
            view.AddNewElement(mockSender, mockEventArgs);

            var mockSplitterEventArgs = new SplitterEventArgs(100, 100, 500, 500);
            view.MoveSplitDrawingDataContainer(mockSender, mockSplitterEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view._presentationModel._model._commandManager.AdjustPositions();
            view.ClickRedo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
        }

        /// <summary>
        /// test if point command works successfully
        /// </summary>
        [TestMethod()]
        public void PointCommandTest()
        {
            var mockModel = new Mock<Model>();
            var presentationModel = new PresentationModel(mockModel.Object);
            var view = new PowerPointLike(presentationModel);
            var mockSender = new Mock<object>();
            var mockEventArgs = new EventArgs();
            var mockDataGridViewCellEventArgs = new DataGridViewCellEventArgs(columnIndex: 0, rowIndex: 1);
            var mockMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 0, 5, 5, 50);
            var mockSplitterEventArgs = new SplitterEventArgs(100,100,500,500);

            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            var mockGraphicsAdaptor = new Mock<IGraphics>();
            view._presentationModel._model._state.DrawTempShape(mockGraphicsAdaptor.Object);

            view.HandleCanvasPressed(mockSender, mockMouseEventArgs);
            view.HandleCanvasMoved(mockSender, mockMouseEventArgs);
            view.HandleCanvasReleased(mockSender, mockMouseEventArgs);

            presentationModel.AddItem("圓", 0, 1);
            presentationModel.AddItem("線", 0, 2);
            presentationModel.AddItem("矩形", 0, 3);

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 1), new Coordinate(100, 100));
            Shape shape1 = new Circle(coordinateSet, presentationModel._model._shapes._factory);
            shape1.Draw(mockGraphicsAdaptor.Object);

            Shape shape2 = new Line(coordinateSet, presentationModel._model._shapes._factory);
            shape2.Draw(mockGraphicsAdaptor.Object);

            Shape shape3 = new Rectangle(coordinateSet, presentationModel._model._shapes._factory);
            shape3.Draw(mockGraphicsAdaptor.Object);

            view._presentationModel._model._commandManager.Execute(new PointCommand(shape1, shape2, view._presentationModel._model));
            view._presentationModel._model._commandManager.Execute(new PointCommand(shape2, shape3, view._presentationModel._model));
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            view._presentationModel._model._shapes.AdjustPositions();
            view._presentationModel._model._shapes.GetIndex(-1, -1);

            view._presentationModel._model._state._tempShape = shape3;
            view._presentationModel._model._state.DrawTempShape(mockGraphicsAdaptor.Object);

            view.MoveSplitDrawingDataContainer(mockSender, mockSplitterEventArgs);
            view.ClickUndo(mockSender, mockEventArgs);
            view.ClickRedo(mockSender, mockEventArgs);

            view._presentationModel._model.GetFactorY();
        }
    }
}