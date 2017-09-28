using System.Collections.Generic;

namespace SibalaVim_TDD
{
    internal class DiceComparer : IComparer<Dice>
    {
        public int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Type == dice2.Type)
            {
                if (dice1.Type == DiceType.OneColor)
                {
                    //1 > 4 > 6 > 5 > 3 > 2
                    return CompareOfOneColor(dice1, dice2);
                }

                if (dice1.Type == DiceType.NormalPoints)
                {
                    return CompareOfNormalPoints(dice1, dice2);
                }

                return 0;
            }

            return dice1.Type - dice2.Type;
        }

        private static int CompareOfNormalPoints(Dice dice1, Dice dice2)
        {
            if (dice1.Points == dice2.Points)
            {
                return dice1.MaxPoint - dice2.MaxPoint;
            }
            return dice1.Points - dice2.Points;
        }

        private static int CompareOfOneColor(Dice dice1, Dice dice2)
        {
            var weights = new List<int> { 2, 3, 5, 6, 4, 1 };
            return weights.IndexOf(dice1.Points) - weights.IndexOf(dice2.Points);
        }
    }
}