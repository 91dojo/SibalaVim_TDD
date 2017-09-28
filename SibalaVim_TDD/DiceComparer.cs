using System.Collections.Generic;

namespace SibalaVim_TDD
{
    internal class DiceComparer : IComparer<Dice>
    {

        public int Compare(Dice dice1, Dice dice2)
        {
            if (dice1.Type == dice2.Type)
            {
                return dice1.Points - dice2.Points;
            }
            return dice1.Type - dice2.Type;
        }
    }
}