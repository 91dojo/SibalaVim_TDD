namespace SibalaVim_TDD
{
    public class NoPointsHandler
    {
        private Dice _dice;

        public NoPointsHandler(Dice dice)
        {
            _dice = dice;
        }

        public string SetResult()
        {
            return _dice.Output = "No Points";
        }
    }
}