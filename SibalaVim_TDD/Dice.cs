using System.Collections.Generic;
using System.Linq;

namespace SibalaVim_TDD
{
    public enum DiceType
    {
        NoPoints = 0,
        NormalPoints = 1,
        OneColor = 2,
    }

    public class Dice
    {
        public List<int> _dices;

        public Dice(int i0, int i1, int i2, int i3)
        {
            this._dices = new List<int> { i0, i1, i2, i3 };
            this.Sibala();
        }

        public int MaxPoint { get; set; }
        public string Output { get; set; }
        public int Points { get; set; }
        public DiceType Type { get; set; }

        private IDiceHandler GetDiceHandler()
        {
            IDiceHandler handler;
            switch (_dices.GroupBy(x => x).Max(x => x.Count()))
            {
                case 2:
                    handler = new NormalPointsHandler(this);
                    break;

                case 4:
                    handler = new OneColorHandler(this);
                    break;

                default:
                    handler = new NoPointsHandler(this);
                    break;
            }
            return handler;
        }

        private bool IsOneColor()
        {
            return this._dices.All(x => x == _dices.First());
        }

        private void Sibala()
        {
            GetDiceHandler().SetResult();
        }
    }
}