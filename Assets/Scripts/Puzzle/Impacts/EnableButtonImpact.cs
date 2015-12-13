using Menu;

namespace Puzzle.Impacts
{
    public class EnableButtonImpact : IImpact
    {
        private IMenu _nextMenu;

        public void Configure(IMenu nextMenu)
        {
            _nextMenu = nextMenu;

            if (_nextMenu != null)
                _nextMenu.Enabled = false;
        }

        public void Apply()
        {
            if (_nextMenu != null)
                _nextMenu.Enabled = true;
        }
    }
}