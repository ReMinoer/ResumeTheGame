using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Init : MonoBehaviour {

	public Button btn1;
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
		Navigation nav = btn1.navigation;
		nav.mode = Navigation.Mode.Vertical;
		btn1.navigation = nav;
		btn1.transition = Selectable.Transition.ColorTint;
	}
	
	// Update is called once per frame
	void Update () {
		i++;
		if (i % 200 >= 100) {
			ColorBlock col = btn1.colors;
			col.normalColor = Color.cyan;
			col.highlightedColor = Color.white;
			col.pressedColor = Color.blue;
			btn1.colors = col;
		} else {
			ColorBlock col = btn1.colors;
			col.normalColor = Color.yellow;
			col.highlightedColor = Color.red;
			col.pressedColor = Color.green;
			btn1.colors = col;
		}
	}
}
