using System.Collections.ObjectModel;
using UnityEngine;

namespace Menu
{
    public interface IMenu
    {
        bool Enabled { get; set; }
        GameObject Panel { get; }
        ReadOnlyCollection<IMenuControl> Controls { get; }
        void AddControl(IMenuControl control);
    }
}