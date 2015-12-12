using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Menu.Controls
{
    public class MenuButton : MenuControlBase, IMenuButton
    {
        private readonly Button _button;
        private readonly Text _text;

        public event UnityAction Triggered
        {
            add { _button.onClick.AddListener(value); }
            remove { _button.onClick.RemoveListener(value); }
        }

        public override bool Enabled
        {
            get { return _button.enabled; }
            set { _button.enabled = value; }
        }

        public override Color Color
        {
            get { return _button.colors.normalColor; }
            set
            {
                ColorBlock colorBlock = _button.colors;
                colorBlock.normalColor = value;
                _button.colors = colorBlock;
            }
        }

        public string Text
        {
            get { return _text.text; }
            set { _text.text = value; }
        }

        public Color TextColor
        {
            get { return _text.color; }
            set { _text.color = value; }
        }

        public MenuButton(IMenu menu)
            : base(menu, Resources.Load<GameObject>("Label"))
        {
            _button = GameObject.GetComponent<Button>();
            _text = GameObject.GetComponent<Text>();
        }
    }
}