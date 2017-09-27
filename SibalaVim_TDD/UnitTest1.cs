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
        }

        public int MaxPoint { get; set; }

        public string GetOutput()
        {
            var diceGroups = _dices.GroupBy(x => x);
            if (IsNormalPoints(diceGroups))
            {
                return GetPoints(diceGroups) + " Points";
            }

            if (IsOneColor())
            {
                this.MaxPoint = _dices.First();
                return "One Color";
            }

            return "No Points";
        }

        private static bool IsNormalPoints(IEnumerable<IGrouping<int, int>> diceGroups)
        {
            return diceGroups.Max(x => x.Count() == 2);
        }

        private int GetPoints(IEnumerable<IGrouping<int, int>> diceGroups)
        {
            var pair = diceGroups.Where(x => x.Count() == 2).Min(x => x.Key);
            var points = _dices.Where(x => x != pair);
            this.MaxPoint = points.Max();
            return points.Sum();
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
        }

        [TestMethod]
        public void NormalPoints_4242_is_8_points()
        {
            DiceOutputShouldBe("8 Points", 4, 2, 4, 2);
            MaxPointShouldBe(4);
        }

        [TestMethod]
        public void OneColor()
        {
            DiceOutputShouldBe("One Color", 1, 1, 1, 1);
            MaxPointShouldBe(1);
        }

        private void DiceOutputShouldBe(string expected, int i0, int i1, int i2, int i3)
        {
            dice = new Dice(i0, i1, i2, i3);
            Assert.AreEqual(expected, dice.GetOutput());
        }
    }
}