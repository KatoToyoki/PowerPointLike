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
        [TestMethod()]
        public void AddItemTest()
        {
            Model model = new Model();

            string shape1 = string.Empty;
            model.AddItem(shape1);
            Assert.AreEqual(0, model.GetContainerLength());

            string shape2 = "矩形";
            model.AddItem(shape2);
            Assert.AreEqual(1, model.GetContainerLength());
        }

        [TestMethod()]
        public void DeleteCertainElementTest()
        {
            Model model = new Model();

            string shape2 = "矩形";
            model.AddItem(shape2);
            Assert.AreEqual(1, model.GetContainerLength());

            model.DeleteCertainElement(0);
            Assert.AreEqual(0, model.GetContainerLength());
        }

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

            model.PressPointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.AreEqual(null, model.GetSelectIndex());
        }

        [TestMethod()]
        public void MovePointerTest()
        {
            Model model = new Model();

            int shapeIndex = 0;
            Coordinate coordinate1 = new Coordinate(1, 1);
            Assert.IsTrue(model.CheckInputValid(coordinate1._x, coordinate1._y));

            model.ClickToolButton(0);
            Assert.IsFalse (model._state._isPressed);
            
            model.PressPointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsTrue(model._state._isPressed);

            model._state._isPressed = false;
            model.MovePointer(coordinate1._x, coordinate1._y, shapeIndex);

            model._state._isPressed = true;

            model.MovePointer(coordinate1._x, coordinate1._y, shapeIndex);
            Assert.IsTrue(model._state._isPressed);
        }

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

        [TestMethod()]
        public void GetCurrentStateIndexTest()
        {
            Model model = new Model();

            Assert.AreEqual(1, model.GetCurrentStateIndex());
        }

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

        [TestMethod()]
        public void ResetSelectIndexTest()
        {
            Model model = new Model();
            Assert.AreEqual(0, model.GetSelectIndex());
            model.ResetSelectIndex();
            Assert.AreEqual(null, model.GetSelectIndex());
        }

        [TestMethod()]
        public void DeleteSelectOneTest()
        {
            Model model = new Model();

            string shape1 = "圓";
            model.AddItem(shape1);
            Assert.AreEqual(1, model.GetContainerLength());

            string shape2 = "線";
            model.AddItem(shape2);
            Assert.AreEqual(2, model.GetContainerLength());

            CoordinateSet coordinateSet = new CoordinateSet(new Coordinate(1, 2), new Coordinate(100, 200));
            model._shapes.DrawShape(0, coordinateSet);
            model._shapes.DrawShape(1, coordinateSet);
            model._shapes.DrawShape(2, coordinateSet);

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
    }
}