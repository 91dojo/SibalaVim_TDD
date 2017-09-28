using System.Collections.Generic;

namespace SibalaVim_TDD
{
    internal class OneColorComparer : IComparer<Dice>
    {
        public int Compare(Dice dice1, Dice dice2)
        {
            var weights = new List<int> { 2, 3, 5, 6, 4, 1 };
            return weights.IndexOf(dice1.Points) - weights.IndexOf(dice2.Points);
        }
    }
}