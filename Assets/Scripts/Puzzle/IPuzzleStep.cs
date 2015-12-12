using System;
using System.Collections.ObjectModel;

namespace Puzzle
{
    public interface IPuzzleStep
    {
        event EventHandler Succeed;
        ReadOnlyCollection<IPuzzleModule> Modules { get; }
        IImpact Impact { get; set; }
    }
}