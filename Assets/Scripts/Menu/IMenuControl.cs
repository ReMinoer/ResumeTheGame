using UnityEngine;

namespace Menu
{
    public interface IMenuControl
    {
        bool Enabled { get; set; }
        Color Color { get; set; }
        GameObject GameObject { get; }
    }
}