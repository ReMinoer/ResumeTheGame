using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class No : MonoBehaviour {
	public Button btnT;
	public Button btnF;
	public GameObject next;
	public Text txt;
	// Use this for initialization
	void Start () {
		
	}

	public void Non() {
		btnF.image.enabled = false;
		btnT.image.enabled = false;
		txt.text = "NOPE...";
		next.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
