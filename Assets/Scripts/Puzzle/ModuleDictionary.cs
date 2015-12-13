using System;
using System.Collections.Generic;
using Puzzle.Modules;

namespace Puzzle
{
    public class ModuleDictionary
    {
        private readonly Category _modules;
        private readonly Category _optionals;

        public ModuleDictionary()
        {
            _modules = new Category();
            _optionals = new Category();

            AddModule<ColorIllusionModule>(1);
        }

        public void AddModule<TModule>(int probability)
                where TModule : IPuzzleModule, new()
        {
            _modules.AddModule<TModule>(probability);
        }

        public void AddOptional<TModule>(int probability)
                where TModule : IPuzzleModule, new()
        {
            _optionals.AddModule<TModule>(probability);
        }

        public IPuzzleModule GetModule()
        {
            return _modules.GetModule();
        }

        public IPuzzleModule GetOptional()
        {
            return _optionals.GetModule();
        }

        public class Category
        {
            private readonly Dictionary<Type, int> _modules;
            private int _probabilityTotal;

            public Category()
            {
                _modules = new Dictionary<Type, int>();
            }

            public void AddModule<TModule>(int probability)
                where TModule : IPuzzleModule, new()
            {
                _modules.Add(typeof(TModule), probability);
                _probabilityTotal += probability;
            }

            public IPuzzleModule GetModule()
            {
                int randomValue = UnityEngine.Random.Range(0, _probabilityTotal);

                int sum = 0;
                foreach (KeyValuePair<Type, int> modulePair in _modules)
                {
                    Type type = modulePair.Key;
                    int probability = modulePair.Value;

                    sum += probability;

                    if (sum >= randomValue)
                        return (IPuzzleModule)Activator.CreateInstance(type);
                }

                return null;
            }
        }
    }
}