using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class Yes : MonoBehaviour {
	public Button btnT;
	public Button btnF;
	public GameObject next;
	public Text txt;
	// Use this for initialization
	void Start () {
		
	}

	public void Oui() {
		btnF.image.enabled = false;
		btnT.image.enabled = false;
		txt.text = "YAY !";
		next.SetActive (true);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
