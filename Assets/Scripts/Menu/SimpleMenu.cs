using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Menu.Controls;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Menu
{
    public class SimpleMenu : MenuButton, IMenu
    {
        private const float Margin = 10f;
        private readonly List<IMenuControl> _controls;
        private readonly MenuBuilder.MenuRoot _menuRoot;
        private float _anchorCursor = Margin;
        public GameObject Panel { get; private set; }
        public ReadOnlyCollection<IMenuControl> Controls { get; private set; }

        public SimpleMenu(MenuBuilder.MenuRoot menuRoot, GameObject canvas, IMenu menu)
            : base(menu)
        {
            Text = "Resume The Game";

            Panel = Object.Instantiate(Resources.Load("Panel")) as GameObject;
            if (Panel == null)
                throw new NullReferenceException();

            Panel.transform.SetParent(canvas.transform, false);
            Panel.transform.localPosition = Vector3.zero;

            _controls = new List<IMenuControl>();
            Controls = _controls.AsReadOnly();

            Triggered += OnTriggered;

            _menuRoot = menuRoot;
            Panel.SetActive(false);
            menuRoot.RegisterPanel(Panel);

            /*
            var returnButton = new MenuButton(this)
            {
                Text = "Back"
            };
            returnButton.Triggered += () => _menuRoot.SetCurrentPanel(menu.Panel);
             * */
        }

        public void AddControl(IMenuControl control)
        {
            control.GameObject.transform.SetParent(Panel.transform, false);
            control.GameObject.transform.localPosition = Vector3.down * _anchorCursor;

            _anchorCursor += control.GameObject.GetComponent<RectTransform>().rect.height + Margin;

            _controls.Add(control);
        }

        private void OnTriggered()
        {
            _menuRoot.SetCurrentPanel(Panel);
        }
    }
}