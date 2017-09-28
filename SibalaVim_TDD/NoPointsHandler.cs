namespace SibalaVim_TDD
{
    public class NoPointsHandler : IDiceHandler
    {
        private Dice _dice;

        public NoPointsHandler(Dice dice)
        {
            _dice = dice;
        }

        public void SetResult()
        {
            _dice.Output = "No Points";
        }
    }
}