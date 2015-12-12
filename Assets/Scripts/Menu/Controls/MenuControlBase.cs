using UnityEngine;

namespace Menu.Controls
{
    public abstract class MenuControlBase : IMenuControl
    {
        public abstract bool Enabled { get; set; }
        public abstract Color Color { get; set; }
        public GameObject GameObject { get; private set; }

        protected MenuControlBase(IMenu menu, GameObject control)
        {
            GameObject = control;

            menu.AddControl(this);
        }
    }
}