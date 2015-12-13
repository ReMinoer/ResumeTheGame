using System;
using Random = UnityEngine.Random;

namespace Puzzle
{
    [Serializable]
    public class PuzzleBuilder
    {
        public int ModulesCount;
        public int OptionalCount;
        private readonly ModuleDictionary _dictionary = new ModuleDictionary();

        public IPuzzle Build(int seed)
        {
            Random.seed = seed;

            var puzzle = new Puzzle();
            for (int i = 0; i < ModulesCount; i++)
            {
                var puzzleStep = new PuzzleStep();

                IPuzzleModule module = _dictionary.GetModule();
                puzzleStep.AddModule(module);
                 
                puzzle.AddStep(puzzleStep);
            }

            return puzzle;
        }
    }
}