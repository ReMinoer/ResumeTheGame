using Menu;
using Menu.Controls;

namespace Puzzle.Impacts
{
    public class EnableButtonImpact : IImpact
    {
        private readonly MenuButton _button;

        public void Configure(IMenu nextMenu)
        {
            _button.Enabled = false;
        }

        public void Apply()
        {
            _button.Enabled = true;
        }
    }
}