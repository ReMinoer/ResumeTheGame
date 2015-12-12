using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Puzzle
{
    public class PuzzleStep : IPuzzleStep
    {
        public event EventHandler Succeed;
        public ReadOnlyCollection<IPuzzleModule> Modules { get; private set; }
        public IImpact Impact { get; set; }
        private readonly List<IPuzzleModule> _modules;
        private readonly Dictionary<IPuzzleModule, bool> _success;
        private bool _alreadySucceed;

        public PuzzleStep()
        {
            _modules = new List<IPuzzleModule>();
            _success = new Dictionary<IPuzzleModule, bool>();
            Modules = _modules.AsReadOnly();
        }

        public void AddModule(IPuzzleModule module)
        {
            _modules.Add(module);
            _success.Add(module, false);
    
            module.Succeed += ModuleOnSucceed;
        }

        private void ModuleOnSucceed(IPuzzleModule module)
        {
            if (!_alreadySucceed)
                return;

            _success[module] = true;

            if (_success.Values.All(x => x))
            {
                Impact.Apply();
                _alreadySucceed = true;
            }
        }
    }
}