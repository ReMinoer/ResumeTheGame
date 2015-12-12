using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Puzzle;
using Puzzle.Impacts;
using UnityEngine;

namespace Menu
{
    public class MenuBuilder
    {
        public PuzzleBuilder PuzzleBuilder;
        public double ParallelVsDepth = 0.5f;

        public IMenu Build(int seed)
        {
            IPuzzle puzzle = PuzzleBuilder.Build(seed);

            var menu = new MenuRoot();
            IMenu currentMenu = menu;
            IImpact currentImpact = null;

            foreach (IPuzzleStep puzzleStep in puzzle.Steps)
            {
                bool depth = Random.value > ParallelVsDepth;

                IMenu newMenu = null;
                foreach (IPuzzleModule module in puzzleStep.Modules)
                    newMenu = module.GenerateControls(currentMenu);

                if (currentImpact != null)
                    currentImpact.Configure(newMenu);

                currentImpact = puzzleStep.Impact = new EnableButtonImpact();

                if (depth)
                    currentMenu = newMenu;
            }

            puzzle.Steps.Last().Impact = new WinImpact();

            return menu;
        }

        public class MenuRoot : IMenu
        {
            public bool Enabled { get; set; }
            public GameObject Canvas { get; private set; }
            public ReadOnlyCollection<IMenuControl> Controls { get; private set; }
            private readonly List<IMenuControl> _controls;

            public MenuRoot()
            {
                Canvas = Resources.Load<GameObject>("Canvas");

                _controls = new List<IMenuControl>();
                Controls = _controls.AsReadOnly();
            }

            public void AddControl(IMenuControl control)
            {
                control.GameObject.transform.parent = Canvas.transform;
                _controls.Add(control);
            }
        }
    }
}