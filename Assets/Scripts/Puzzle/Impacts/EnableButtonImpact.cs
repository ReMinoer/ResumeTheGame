using Menu;

namespace Puzzle.Impacts
{
    public class EnableButtonImpact : IImpact
    {
        private IMenu _nextMenu;

        public void Configure(IMenu nextMenu)
        {
            _nextMenu = nextMenu;
            _nextMenu.Enabled = false;
        }

        public void Apply()
        {
            _nextMenu.Enabled = true;
        }
    }
}