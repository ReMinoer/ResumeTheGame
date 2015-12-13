using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Menu.Controls;
using Puzzle;
using Puzzle.Impacts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Menu
{
    [Serializable]
    public class MenuBuilder
    {
        public PuzzleBuilder PuzzleBuilder;

        public IMenu Build(GameObject canvas, int seed)
        {
            IPuzzle puzzle = PuzzleBuilder.Build(seed);

            var menuRoot = new MenuRoot(canvas);
            IMenu currentMenu = menuRoot;
            IImpact currentImpact = null;

            foreach (IPuzzleStep puzzleStep in puzzle.Steps)
            {
                IMenu newMenu = null;
                foreach (IPuzzleModule module in puzzleStep.Modules)
                    newMenu = module.GenerateControls(menuRoot, canvas, currentMenu);

                if (currentImpact != null)
                    currentImpact.Configure(newMenu);

                currentImpact = puzzleStep.Impact = new EnableButtonImpact();

                currentMenu = newMenu;
            }

            var button = new MenuButton(currentMenu);
            button.Text = "Resume The Game";

            currentImpact = puzzle.Steps.Last().Impact = new WinImpact();
            currentImpact.Configure(null);

            return menuRoot;
        }

        public class MenuRoot : IMenu
        {
            public bool Enabled { get; set; }
            public GameObject Panel { get; private set; }
            public ReadOnlyCollection<IMenuControl> Controls { get; private set; }
            private readonly List<IMenuControl> _controls;
            private readonly List<GameObject> _panels; 

            public MenuRoot(GameObject canvas)
            {
                Panel = Object.Instantiate(Resources.Load("Panel")) as GameObject;
                if (Panel == null)
                    throw new NullReferenceException();

                Panel.transform.SetParent(canvas.transform, false);
                Panel.transform.localPosition = Vector3.zero;

                _controls = new List<IMenuControl>();
                Controls = _controls.AsReadOnly();

                Panel.SetActive(true);

                _panels = new List<GameObject>();
                RegisterPanel(Panel);
            }

            public void AddControl(IMenuControl control)
            {
                control.GameObject.transform.SetParent(Panel.transform, false);
                _controls.Add(control);
            }

            public void RegisterPanel(GameObject panel)
            {
                _panels.Add(panel);
            }

            public void SetCurrentPanel(GameObject panel)
            {
                foreach (GameObject otherPanel in _panels)
                    otherPanel.SetActive(false);

                panel.SetActive(true);
            }
        }
    }
}