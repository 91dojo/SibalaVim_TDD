using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SibalaVim_TDD
{
    public class Dice
    {
        private List<int> _dices;

        public Dice(int i0, int i1, int i2, int i3)
        {
            this._dices = new List<int> { i0, i1, i2, i3 };
            this.Sibala();
        }

        public int MaxPoint { get; set; }
        public int Points { get; set; }
        public DiceType Type { get; set; }

        private void Sibala()
        {
            var maxCountOfSamePoint = _dices.GroupBy(x => x).Max(x => x.Count());

            switch (maxCountOfSamePoint)
            {
                case 2:
                    new NormalPointsHandler(this).SetNormalPointsResult();
                    break;
                case 4:
                    new OneColorHandler(this).SetOneColorResult();
                    break;
                default:
                    new NoPointsHandler(this).SetNoPointsResult();
                    break;
            }
        }

        public string Output { get; set; }

        private bool IsOneColor()
        {
            return this._dices.All(x => x == _dices.First());
        }
    }

    [TestClass]
    public class UnitTest1
    {
        private Dice dice;

        [TestMethod]
        public void NoPoints()
        {
            DiceOutputShouldBe("No Points", 1, 2, 3, 4);
            MaxPointShouldBe(0);
            PointsShouldBe(0);
            TypeShouldBe(DiceType.NoPoints);
        }

        private void TypeShouldBe(DiceType expected)
        {
            Assert.AreEqual(expected, dice.Type);
        }

        private void MaxPointShouldBe(int expected)
        {
            Assert.AreEqual(expected, dice.MaxPoint);
        }

        [TestMethod]
        public void NormalPoints_1123_is_5_Points()
        {
            DiceOutputShouldBe("5 Points", 1, 1, 2, 3);
            MaxPointShouldBe(3);
            PointsShouldBe(5);
            TypeShouldBe(DiceType.NormalPoints);
        }

        [TestMethod]
        public void NormalPoints_4242_is_8_points()
        {
            DiceOutputShouldBe("8 Points", 4, 2, 4, 2);
            MaxPointShouldBe(4);
            PointsShouldBe(8);
            TypeShouldBe(DiceType.NormalPoints);
        }

        [TestMethod]
        public void OneColor()
        {
            DiceOutputShouldBe("One Color", 1, 1, 1, 1);
            MaxPointShouldBe(1);
            PointsShouldBe(1);
            TypeShouldBe(DiceType.OneColor);
        }

        private void PointsShouldBe(int expected)
        {
            Assert.AreEqual(expected, dice.Points);
        }

        private void DiceOutputShouldBe(string expected, int i0, int i1, int i2, int i3)
        {
            dice = new Dice(i0, i1, i2, i3);
            Assert.AreEqual(expected, dice.Output);
        }
    }

    [TestClass]
    public class DiceComparerTests
    {
        [TestMethod]
        public void Both_NoPoints_Should_Equal()
        {
            FirstShouldEqualToSecond(new Dice(1, 2, 3, 4), new Dice(1, 2, 3, 4));
        }

        [TestMethod]
        public void NormalPoints_should_larger_than_NoPoints()
        {
            FirstShouldLargerThanSecond(new Dice(6, 6, 3, 2), new Dice(1, 2, 3, 4));
        }

        [TestMethod]
        public void NormalPoints_should_be_smaller_than_OneColor()
        {
            FirstShouldBeSmallerThanSecond(new Dice(6, 6, 3, 2), new Dice(1, 1, 1, 1));
        }

        [TestMethod]
        public void NormalPoints_compare_10_points_should_larger_than_9_points()
        {
            FirstShouldLargerThanSecond(new Dice(5, 5, 6, 4), new Dice(3, 3, 5, 4));
        }

        [TestMethod]
        public void OneColor_compare()
        {
            FirstShouldLargerThanSecond(new Dice(5, 5, 5, 5), new Dice(2, 2, 2, 2));
        }

        [TestMethod]
        public void OneColor_compare_1_larger_than_4()
        {
            FirstShouldLargerThanSecond(new Dice(1, 1, 1, 1), new Dice(4, 4, 4, 4));
        }

        [TestMethod]
        public void OneColor_compare_4_larger_than_6()
        {
            FirstShouldLargerThanSecond(new Dice(4, 4, 4, 4), new Dice(6, 6, 6, 6));
        }

        [TestMethod]
        public void NormalPoints_compare_of_same_points()
        {
            FirstShouldBeSmallerThanSecond(new Dice(6, 6, 3, 2), new Dice(5, 5, 4, 1));
        }

        private static void FirstShouldBeSmallerThanSecond(Dice dice1, Dice dice2)
        {
            var result = new DiceComparer().Compare(dice1, dice2);
            Assert.IsTrue(result < 0);
        }

        private static void FirstShouldLargerThanSecond(Dice dice1, Dice dice2)
        {
            var result = new DiceComparer().Compare(dice1, dice2);
            Assert.IsTrue(result > 0);
        }

        private static void FirstShouldEqualToSecond(Dice dice1, Dice dice2)
        {
            var result = CompareResult(dice1, dice2);
            Assert.IsTrue(result == 0);
        }

        private static int CompareResult(Dice dice1, Dice dice2)
        {
            return new DiceComparer().Compare(dice1, dice2);
        }
    }

    public enum DiceType
    {
        NoPoints = 0,
        NormalPoints = 1,
        OneColor = 2,
    }
}