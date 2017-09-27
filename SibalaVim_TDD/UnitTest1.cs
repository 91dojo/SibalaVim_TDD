using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SibalaVim_TDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneColor()
        {
            DiceOutputShouldBe("One Color", 1, 1, 1, 1);
        }

        [TestMethod]
        public void NoPoints()
        {
            DiceOutputShouldBe("No Points", 1, 2, 3, 4);
        }

        [TestMethod]
        public void NormalPoints_1123_is_5_Points()
        {
            DiceOutputShouldBe("5 Points", 1, 1, 2, 3);
        }

        private static void DiceOutputShouldBe(string expected, int i0, int i1, int i2, int i3)
        {
            var dice = new Dice(i0, i1, i2, i3);
            Assert.AreEqual(expected, dice.GetOutput());
        }
    }

    public class Dice
    {
        private List<int> _dices;

        public Dice(int i0, int i1, int i2, int i3)
        {
            this._dices = new List<int> { i0, i1, i2, i3 };
        }

        public string GetOutput()
        {
            var diceGroups = _dices.GroupBy(x => x);
            if (IsNormalPoints(diceGroups))
            {
                return GetPoints(diceGroups) + " Points";
            }

            if (IsOneColor())
            {
                return "One Color";
            }

            return "No Points";
        }

        private int GetPoints(IEnumerable<IGrouping<int, int>> diceGroups)
        {
            var pair = diceGroups.Where(x => x.Count() == 2).First();
            var points = _dices.Where(x => x != pair.First()).Sum();
            return points;
        }

        private static bool IsNormalPoints(IEnumerable<IGrouping<int, int>> diceGroups)
        {
            return diceGroups.Max(x => x.Count() == 2);
        }

        private bool IsOneColor()
        {
            return this._dices.All(x => x == _dices.First());
        }
    }
}