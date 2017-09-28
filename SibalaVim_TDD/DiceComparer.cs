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
                    var comparer = new OneColorComparer();
                    return comparer.Compare(dice1, dice2);
                }

                if (dice1.Type == DiceType.NormalPoints)
                {
                    var comparer = new NormalPointsComparer();
                    return comparer.Compare(dice1, dice2);
                }

                return 0;
            }

            return dice1.Type - dice2.Type;
        }
    }
}