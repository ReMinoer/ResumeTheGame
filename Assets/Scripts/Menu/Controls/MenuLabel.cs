using UnityEngine;
using UnityEngine.UI;

namespace Menu.Controls
{
    public class MenuLabel : MenuControlBase, IMenuLabel
    {
        private readonly Text _text;
        public override bool Enabled { get; set; }

        public override Color Color
        {
            get { return _text.color; }
            set { _text.color = value; }
        }

        public string Text
        {
            get { return _text.text; }
            set { _text.text = value; }
        }

        public MenuLabel(IMenu menu)
            : base(menu, Resources.Load<GameObject>("Label"))
        {
            _text = GameObject.GetComponent<Text>();
        }
    }
}