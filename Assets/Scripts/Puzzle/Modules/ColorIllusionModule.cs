using System.Collections.Generic;
using System.Linq;
using Menu;
using Menu.Controls;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Puzzle.Modules
{
    public class ColorIllusionModule : PuzzleModuleBase
    {
        static private readonly int ChoiceCount = 3;

        static private readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>()
        {
            { "Red", Color.red },
            { "Green", Color.green },
            { "Blue", Color.blue }
        };

        public override float Time
        {
            get { return 15f; }
        }

        public override IMenu GenerateControls(IMenu rootMenu)
        {
            int answerIndex = Random.Range(0, ChoiceCount - 1);
            string answerText = Colors.ElementAt(Random.Range(0, Colors.Count - 1)).Key;
            Color answerColor = Colors.ElementAt(Random.Range(0, Colors.Count - 1)).Value;

            var menu = new SimpleMenu(rootMenu);

            var label = new MenuLabel(menu)
            {
                Text = string.Format("Click the button with the {0} text.", answerText)
            };

            for (int i = 0; i < ChoiceCount; i++)
            {
                var button = new MenuButton(menu);

                if (i == answerIndex)
                {
                    button.Triggered += Success;
                    button.TextColor = answerColor;
                }
                else
                {
                    button.Triggered += Fail;
                    int colorIndex = Random.Range(0, Colors.Count - 2);
                    button.TextColor = Colors.Values.Where(x => x != answerColor).ElementAt(colorIndex);
                }

                button.Text = Colors.ElementAt(Random.Range(0, Colors.Count - 1)).Key;
                button.Color = Colors.ElementAt(Random.Range(0, Colors.Count - 1)).Value;
            }

            return menu;
        }
    }
}
