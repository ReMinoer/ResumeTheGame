using System.Collections.ObjectModel;

namespace Puzzle
{
    public interface IPuzzle
    {
        ReadOnlyCollection<IPuzzleStep> Steps { get; }
        void AddStep(IPuzzleStep step);
    }
}