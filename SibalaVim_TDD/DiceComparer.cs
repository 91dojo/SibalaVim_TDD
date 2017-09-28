﻿using System.Collections.Generic;

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
                    var weights = new List<int> { 2, 3, 5, 6, 4, 1 };
                    var weightOfDice1 = weights.IndexOf(dice1.Points); 
                    var weightOfDice2 = weights.IndexOf(dice2.Points);
                    return weightOfDice1 - weightOfDice2;
                }
                return dice1.Points - dice2.Points;
            }
            return dice1.Type - dice2.Type;
        }
    }
}