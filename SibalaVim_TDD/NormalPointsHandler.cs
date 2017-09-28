using System.Linq;

namespace SibalaVim_TDD
{
    public class NormalPointsHandler : IDiceHandler
    {
        private Dice _dice;

        public NormalPointsHandler(Dice dice)
        {
            _dice = dice;
        }

        public void SetResult()
        {
            var pair = _dice._dices.GroupBy(x => x).Where(x => x.Count() == 2).Min(x => x.Key);
            var points = _dice._dices.Where(x => x != pair);
            _dice.MaxPoint = points.Max();
            _dice.Points = points.Sum();
            _dice.Type = DiceType.NormalPoints;
            _dice.Output = _dice.Points + " Points";
        }
    }
}