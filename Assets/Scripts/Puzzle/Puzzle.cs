using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Puzzle
{
    public class Puzzle : IPuzzle
    {
        private readonly List<IPuzzleStep> _steps;
        public ReadOnlyCollection<IPuzzleStep> Steps { get; private set; }

        public Puzzle()
        {
           _steps = new List<IPuzzleStep>();
            Steps = _steps.AsReadOnly();
        }

        public void AddStep(IPuzzleStep step)
        {
            _steps.Add(step);
        }
    }
}