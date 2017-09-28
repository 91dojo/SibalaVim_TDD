using System.Linq;

namespace SibalaVim_TDD
{
    public class OneColorHandler : IDiceHandler
    {
        private Dice _dice;

        public OneColorHandler(Dice dice)
        {
            _dice = dice;
        }

        public void SetResult()
        {
            _dice.MaxPoint = _dice._dices.First();
            _dice.Points = _dice._dices.First();
            _dice.Type = DiceType.OneColor;
            _dice.Output = "One Color";
        }
    }
}