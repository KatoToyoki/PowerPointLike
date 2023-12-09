using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike.Tests
{
    [TestClass()]
    public class ModelTests
    {
        /// <summary>
        /// test add invalid / valid item
        /// </summary>
        [TestMethod()]
        public void AddItemTest()
        {
            Model model = new Model();

            string shape1 = string.Empty;

            model.AddItem(shape1, 0, 1);
            Assert.AreEqual(0, model.GetContainerLength());

            string shape2 = "矩形";
            model.AddItem(shape2, 0, 1);
            Assert.AreEqual(1, model.GetContainerLength());
        }

        /// <summary>
        /// delete existed item
        /// </summary>
        [TestMethod()]
        public void DeleteCertainElementTest()
        {
            Model model = new Model();
            string shape2 = "矩形";

            model.AddItem(shape2, 0, 1);
            Assert.AreEqual(1, model.GetContainerLength());

            model.DeleteCertainElement(shape2, 0, 0);
            Assert.AreEqual(0, model.GetContainerLength());
        }

        /// <summary>
        /// check if the input is vaild or not
        /// </summary>
        [TestMethod()]
        public void CheckInputValidTest()
        {
            Model model = new Model();

            Coordinate coordinate1 = new Coordinate(1, 1);
            Assert.IsTrue(model.CheckInputValid(coordinate1._x, coordinate1._y));

            Coordinate coordinate2 = new Coordinate(1, -1);
            Assert.IsFalse(model.CheckInputValid(coordinate2._x, coordinate2._y));

            Coordinate coordinate3 = new Coordinate(-1, 1);
            Assert.IsFalse(model.CheckInputValid(coordinate3._x, coordinate3._y));

            Coordinate coordinate4 = new Coordinate(-1, -1);
            Assert.IsFalse(model.CheckInputValid(coordinate4._x, coordinate4._y));
        }

        /// <summary>
        /// test if press works fine
        /// </summary>
        [TestMethod()]
        public void PressPointerTest()
        {
            Model model = new Model();
            int shapeIndex = 0;

            Coordinate coordinate1 = new Coordinate(1, 1);
            Assert.IsTrue(model.CheckInputValid(coordinate1._x, coordinate1._y));

            Coordinate coordinate2 = new Coordinate(1, -1);
            Assert.IsFalse(model.CheckInputValid(coordinate2._x, coordinate2._y));

            Coordinate coordinate3 = new Coordinate(-1, 1);
            Assert.IsFalse(model.CheckInputValid(coordinate3._x, coordinate3._y));

            Coordinate coordinate4 = new Coordinate(-1, -1);
            Assert.IsFalse(model.CheckInputValid(coordinate4._x, coordinate4._y));

            model.PressPointer(coordinate2._x, coordinate2._y, shapeIndex);
            model.PressPointer(coordinate3._x, coordinate3._y, shapeIndex);
            model.PressPointer(coordinate4._x, coordinate4._y, shapeIndex);

            model.ClickToolButton(0);
            model.PressPointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.AreEqual(null, model.GetSelectIndex());
        }

        /// <summary>
        /// test if move works fine
        /// </summary>
        [TestMethod()]
        public void MovePointerTest()
        {
            Model model = new Model();

            int shapeIndex = 0;
            Coordinate coordinate1 = new Coordinate(1, 1);
            Assert.IsTrue(model.CheckInputValid(coordinate1._x, coordinate1._y));

            model.ClickToolButton(0);
            Assert.IsFalse(model._state._isPressed);

            model.PressPointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsTrue(model._state._isPressed);

            model._state._isPressed = false;
            model.MovePointer(coordinate1._x, coordinate1._y, shapeIndex);

            model._state._isPressed = true;

            model.MovePointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsTrue(model._state._isPressed);
        }

        /// <summary>
        /// test if release works fine
        /// </summary>
        [TestMethod()]
        public void ReleasePointerTest()
        {
            Model model = new Model();

            int shapeIndex = 0;
            Coordinate coordinate1 = new Coordinate(1, 1);
            Assert.IsTrue(model.CheckInputValid(coordinate1._x, coordinate1._y));

            model.ClickToolButton(0);
            Assert.IsFalse(model._state._isPressed);

            model.PressPointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsTrue(model._state._isPressed);

            model.MovePointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsTrue(model._state._isPressed);

            model._state._isPressed = false;
            model.ReleasePointer(coordinate1._x, coordinate1._y, shapeIndex);

            model._state._isPressed = true;
            model.ReleasePointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsFalse(model._state._isPressed);
        }

        /// <summary>
        /// test if getter works fine
        /// </summary>
        [TestMethod()]
        public void GetCurrentStateIndexTest()
        {
            Model model = new Model();
            Assert.AreEqual(1, model.GetCurrentStateIndex());
        }

        /// <summary>
        /// test if getter works fine
        /// </summary>
        [TestMethod()]
        public void GetSelectIndexTest()
        {
            Model model = new Model();
            Assert.AreEqual(0, model.GetSelectIndex());
            model._state._index = State.INVALID;
            Assert.AreEqual(null, model.GetSelectIndex());
            model._state._currentStateIndex = 0;
            Assert.AreEqual(null, model.GetSelectIndex());
        }

        /// <summary>
        /// test if reset works fine
        /// </summary>
        [TestMethod()]
        public void ResetSelectIndexTest()
        {
            Model model = new Model();
            Assert.AreEqual(0, model.GetSelectIndex());
            model.ResetSelectIndex();
            Assert.AreEqual(null, model.GetSelectIndex());
            model._state.ChangeCurrentIndex(-1);
        }

        /// <summary>
        /// test if delete works successfully
        /// </summary>
        [TestMethod()]
        public void DeleteSelectOneTest()
        {
            Model model = new Model();

            string shape1 = "圓";
            model.AddItem(shape1, 0, 1);
            Assert.AreEqual(1, model.GetContainerLength());

            string shape2 = "線";
            model.AddItem(shape2, 0, 2);
            Assert.AreEqual(2, model.GetContainerLength());

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 2), new Coordinate(100, 200));
            model._shapes.DrawShape(0, coordinateSet);
            model._shapes.DrawShape(1, coordinateSet);
            model._shapes.DrawShape(2, coordinateSet);

            model.NotifyModelChanged();

            model.GetOneElement(0);
            model.GetSelectedOneCoordinate();

            Assert.AreEqual(5, model.GetContainerLength());

            Assert.AreEqual(0, model.GetSelectIndex());
            model.ResetSelectIndex();
            Assert.AreEqual(null, model.GetSelectIndex());
            model.DeleteSelectOne();

            model._state._index = 0;
            model.DeleteSelectOne();
        }

        /// <summary>
        /// test if point state works successfully
        /// </summary>
        [TestMethod()]
        public void PointStateTest()
        {
            Model model = new Model();
            model._state._currentStateIndex = 1;

            string shape1 = "圓";
            model.AddItem(shape1, 0, 1);
            Assert.AreEqual(1, model.GetContainerLength());

            string shape2 = "線";
            model.AddItem(shape2, 0, 2);
            Assert.AreEqual(2, model.GetContainerLength());

            Coordinate point1 = new Coordinate(100, 100);
            Coordinate point2 = new Coordinate(1, 1);
            point2.GetIfSelfBigger(point1);
            Coordinate point3 = new Coordinate(1, 1);
            point2.GetIfIsSame(point1);
            point2.GetIfIsSame(point3);
            CoordinateSet point = new CoordinateSet(point1, point2);

            model._shapes.AddShapeInEnd(0, point);
            model.PrintTest();

            model._shapes._factory.SetCoordinateSet(point1, point2);

            point.GetMiddlePoint();
            point.GetWidth();
            point.GetHeight();
            point.GetTop();
            point.GetBottom();
            point.GetLeft();
            point.GetRight();
            point.GetMiddleWidth();
            point.GetMiddleHeight();
            point.GetDeltaX();
            point.GetDeltaY();
            point.Offset(10, 10);

            model._state = new PointState(model._shapes, model);

            model.PressPointer(55, 55, 0);

            model._state._index = -1;
            model.MovePointer(110, 110, 0);

            model._state._index = 1;

            model.MovePointer(-11, -11, 0);
            model.MovePointer(110, 110, 0);
            model.MovePointer(120, 120, 0);
            model.MovePointer(130, 130, 0);

            Coordinate test1 = new Coordinate(56, 56);
            Coordinate test2 = new Coordinate(58, 58);

            CoordinateSet temp = model._state.GetNewShapeCoordinate();
            temp._point2 = test2;

            Coordinate pointO = new Coordinate(0, 0);
            CoordinateSet pointSetO = new CoordinateSet(pointO, pointO);
            model._state.SetNewShapeCoordinate(pointSetO);

            model.ReleasePointer(120, 120, 0);

            model._state.SetNewShapeCoordinate(temp);

            model.ReleasePointer(120, 120, 0);

            model._state.CreateState(999, model._shapes, model);
            model._state.CreateState(-1, model._shapes, model);
            Assert.AreEqual(1, model.GetCurrentStateIndex());
            model._state.ResetThreePoint();

            model._shapes.ChangeCoordinate(-1, 100, 100);

            model._shapes.CreateTempShape(0, temp);
            model._shapes.CreateTempShape(1, temp);
            model._shapes.CreateTempShape(2, temp);
            model._shapes.CreateTempShape(999, temp);
        }
    }
}