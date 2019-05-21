using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Exit : MonoBehaviour {

	bool clicked=false;
	public Button exitButton;

	// Use this for initialization
	void Start () {

		Button exit = exitButton.GetComponent<Button> ();
		exit.onClick.AddListener (Quit);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (clicked) {
			Application.Quit ();
		}
		
	
	}

	void Quit(){
		clicked = true;
	}

}
