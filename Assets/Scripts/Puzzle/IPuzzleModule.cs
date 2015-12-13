using System;
using Menu;
using UnityEngine;

namespace Puzzle
{
    public interface IPuzzleModule
    {
        event Action<IPuzzleModule> Succeed;
        event Action Failed;
        float Time { get; }
        IMenu GenerateControls(MenuBuilder.MenuRoot menuRoot, GameObject canvas, IMenu currentMenu);
    }
}