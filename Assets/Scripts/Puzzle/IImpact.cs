using Menu;

namespace Puzzle
{
    public interface IImpact
    {
        void Configure(IMenu nextMenu);
        void Apply();
    }
}