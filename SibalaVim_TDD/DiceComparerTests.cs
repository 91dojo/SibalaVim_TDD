using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SibalaVim_TDD
{
    [TestClass]
    public class DiceComparerTests
    {
        [TestMethod]
        public void Both_NoPoints_Should_Equal()
        {
            FirstShouldEqualToSecond(new Dice(1, 2, 3, 4), new Dice(1, 2, 3, 4));
        }

        [TestMethod]
        public void NormalPoints_compare_10_points_should_larger_than_9_points()
        {
            FirstShouldLargerThanSecond(new Dice(5, 5, 6, 4), new Dice(3, 3, 5, 4));
        }

        [TestMethod]
        public void NormalPoints_compare_of_same_points()
        {
            FirstShouldBeSmallerThanSecond(new Dice(6, 6, 3, 2), new Dice(5, 5, 4, 1));
        }

        [TestMethod]
        public void NormalPoints_should_be_smaller_than_OneColor()
        {
            FirstShouldBeSmallerThanSecond(new Dice(6, 6, 3, 2), new Dice(1, 1, 1, 1));
        }

        [TestMethod]
        public void NormalPoints_should_larger_than_NoPoints()
        {
            FirstShouldLargerThanSecond(new Dice(6, 6, 3, 2), new Dice(1, 2, 3, 4));
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

        private static int CompareResult(Dice dice1, Dice dice2)
        {
            return new DiceComparer().Compare(dice1, dice2);
        }

        private static void FirstShouldBeSmallerThanSecond(Dice dice1, Dice dice2)
        {
            var result = new DiceComparer().Compare(dice1, dice2);
            Assert.IsTrue(result < 0);
        }

        private static void FirstShouldEqualToSecond(Dice dice1, Dice dice2)
        {
            var result = CompareResult(dice1, dice2);
            Assert.IsTrue(result == 0);
        }

        private static void FirstShouldLargerThanSecond(Dice dice1, Dice dice2)
        {
            var result = new DiceComparer().Compare(dice1, dice2);
            Assert.IsTrue(result > 0);
        }
    }
}