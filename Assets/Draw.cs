using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Draw : MonoBehaviour {

	public Button drawButton, flipButton;
	public GameObject card, card2; 
	GameObject point1, point2;
	public float speed1, speed2;
	bool clicked=false;
	public Vector3 origin;


	// Use this for initialization
	void Start () {
		Button draw = drawButton.GetComponent<Button> ();
		draw.onClick.AddListener (DrawOnClick);

		flipButton = GameObject.Find ("Flip").GetComponent<Button> ();

		card = GameObject.Find ("Card");
		card2 = GameObject.Find ("Card2");
		origin = card.transform.position;

		point1 = GameObject.Find ("Point1");
		point2 = GameObject.Find ("Point2");
	}
	
	// Update is called once per frame
	void Update () {

		if (clicked && card.transform.position != point1.transform.position) {
			card.transform.position = Vector3.MoveTowards (card.transform.position, point1.transform.position, speed1);
		}

		if (clicked && card2.transform.position != point2.transform.position) {
			card2.transform.position = Vector3.MoveTowards (card2.transform.position, point2.transform.position, speed2);
		}

		if (card.transform.position == point1.transform.position && card2.transform.position == point2.transform.position) {
			clicked = false;
		}
	}

	void DrawOnClick()
	{
		//print ("Card Drawn");
		//card.transform.position = origin;
		//card2.transform.position = origin;
		clicked = true;
		drawButton.GetComponent<Button> ().interactable = false;
		flipButton.interactable = true;

		/*card.transform.rotation = Quaternion.identity;
		card.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");
		card.GetComponent<SpriteRenderer> ().flipX = false;

		card2.transform.rotation = Quaternion.identity;
		card2.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");
		card2.GetComponent<SpriteRenderer> ().flipX = false;*/

	}
		
}
