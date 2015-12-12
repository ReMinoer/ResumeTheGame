using Menu;

namespace Puzzle.Impacts
{
    public class WinImpact : IImpact
    {
        public void Configure(IMenu nextMenu)
        {
        }

        public void Apply()
        {
            // You win !
        }
    }
}