using System.Collections.Generic;

namespace SibalaVim_TDD
{
    internal class DiceComparer : IComparer<Dice>
    {
        public int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Type == dice2.Type)
            {
                return GetComparer(dice1.Type).Compare(dice1, dice2);
            }

            return dice1.Type - dice2.Type;
        }

        private static IComparer<Dice> GetComparer(DiceType type)
        {
            switch (type)
            {
                case DiceType.OneColor:
                    //1 > 4 > 6 > 5 > 3 > 2
                    return new OneColorComparer();

                case DiceType.NormalPoints:
                    return new NormalPointsComparer();

                case DiceType.NoPoints:
                    return new NoPointsComparer();
            }
            return null;
        }
    }
}