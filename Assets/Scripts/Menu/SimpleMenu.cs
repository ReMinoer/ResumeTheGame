using System.Collections.Generic;
using System.Collections.ObjectModel;
using Menu.Controls;
using UnityEngine;

namespace Menu
{
    public class SimpleMenu : MenuButton, IMenu
    {
        private readonly List<IMenuControl> _controls; 
        public GameObject Canvas { get; private set; }
        public ReadOnlyCollection<IMenuControl> Controls { get; private set; }

        public SimpleMenu(IMenu menu)
            : base(menu)
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