using UnityEngine;
using UnityEngine.Events;

namespace Menu.Controls
{
    public interface IMenuButton : IMenuControl
    {
        event UnityAction Triggered;
        string Text { get; set; }
        Color TextColor { get; set; }
    }
}