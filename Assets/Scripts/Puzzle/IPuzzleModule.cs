using System;
using Menu;

namespace Puzzle
{
    public interface IPuzzleModule
    {
        event Action<IPuzzleModule> Succeed;
        event Action Failed;
        float Time { get; }
        IMenu GenerateControls(IMenu rootMenu);
    }
}