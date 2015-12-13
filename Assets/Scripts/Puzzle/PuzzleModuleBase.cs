using System;
using Menu;
using UnityEngine;

namespace Puzzle
{
    public abstract class PuzzleModuleBase : IPuzzleModule
    {
        public event Action<IPuzzleModule> Succeed;
        public event Action Failed;
        public abstract float Time { get; }
        public abstract IMenu GenerateControls(MenuBuilder.MenuRoot menuRoot, GameObject canvas, IMenu currentMenu);
        private bool _alreadySucceed;

        protected void Success()
        {
            if (_alreadySucceed)
                return;

            if (Succeed != null)
            {
                Succeed.Invoke(this);
                _alreadySucceed = true;
            }
        }

        protected void Fail()
        {
            if (Failed != null)
                Failed.Invoke();
        }
    }
}