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
            if (IsNormalPoints())
            {
                SetNormalPointsResult();
                this.Output = this.Points + " Points";
                return;
            }

            if (IsOneColor())
            {
                SetOneColorResult();
                this.Output = "One Color";
                return;
            }

            this.Output = "No Points";
        }

        public string Output { get; set; }

        private void SetOneColorResult()
        {
            this.MaxPoint = _dices.First();
            this.Points = _dices.First();
            this.Type = DiceType.OneColor;
        }

        private bool IsNormalPoints()
        {
            return _dices.GroupBy(x => x).Max(x => x.Count() == 2);
        }

        private void SetNormalPointsResult()
        {
            var pair = _dices.GroupBy(x => x).Where(x => x.Count() == 2).Min(x => x.Key);
            var points = _dices.Where(x => x != pair);
            this.MaxPoint = points.Max();
            this.Points = points.Sum();
            this.Type = DiceType.NormalPoints;
        }

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
        NoPoints,
        NormalPoints,
        OneColor
    }
}