using System.Collections.Generic;

namespace SibalaVim_TDD
{
    internal class DiceComparer:IComparer<Dice>
    {

        public int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Type== DiceType.NormalPoints && dice2.Type== DiceType.NoPoints)
            {
                return 1;
            }

            return 0;
        }
    }
}