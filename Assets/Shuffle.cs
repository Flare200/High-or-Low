using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shuffle : MonoBehaviour {

	public Button shuffleButton, drawButton, flipButton;
	private Deck deck;
	private Flip flip;
	private Draw draw;
	public int timesFlipped;
	bool clicked=false, ani=false, ani2=false, ani3=false, resetOnce=false;
	public string[] gameDeck= new string[52];
	public GameObject card, card2;
	public Text numeric, suit;
	public float flipSpeed, moveSpeed, moveSpeed2, shuffleSpeed1, shuffleSpeed2, shuffleSpeed3, shuffleSpeed4, shuffleSpeed5;
	public float shuffleSpeed6, shuffleSpeed7, shuffleSpeed8, shuffleSpeed9, shuffleSpeed10, shuffleSpeed11, shuffleSpeed12;
	GameObject shufflePoint;
	GameObject temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10;

	void Awake() 
	{
		deck = GameObject.Find ("Flip").GetComponent<Deck> ();
		flip = GameObject.Find ("Flip").GetComponent<Flip> ();
		draw = GameObject.Find ("Draw").GetComponent<Draw> ();
	}

	// Use this for initialization
	void Start () {
		Button shuffle = shuffleButton.GetComponent<Button> ();
		shuffle.onClick.AddListener (ShuffleOnClick);

		shuffle.interactable = false;
		timesFlipped = flip.timesFlipped;

		gameDeck = deck.deck;

		drawButton = GameObject.Find ("Draw").GetComponent<Button> ();
		flipButton = GameObject.Find ("Flip").GetComponent<Button> ();

		card = GameObject.Find ("Card");
		card2 = GameObject.Find ("Card2");

		numeric = GameObject.Find ("Numeric Output").GetComponent<Text> ();
		suit = GameObject.Find ("Suit Output").GetComponent<Text> ();

		shufflePoint = GameObject.Find ("Point3");

		temp1 = GameObject.Find ("Temp1");
		temp2 = GameObject.Find ("Temp2");
		temp3 = GameObject.Find ("Temp3");
		temp4 = GameObject.Find ("Temp4");
		temp5 = GameObject.Find ("Temp5");
		temp6 = GameObject.Find ("Temp6");
		temp7 = GameObject.Find ("Temp7");
		temp8 = GameObject.Find ("Temp8");
		temp9 = GameObject.Find ("Temp9");
		temp10 = GameObject.Find ("Temp10");
	
	}
	
	// Update is called once per frame
	void Update () {
		timesFlipped = flip.timesFlipped;

		if (timesFlipped == 2 && card2.transform.rotation.eulerAngles.y >= 180) {
			shuffleButton.GetComponent<Button> ().interactable = true;
		}

		if (clicked) {
			deck.shuffle (gameDeck);
			deck.AceSpadesBias (gameDeck);
			deck.HeartsBias (gameDeck);
			flip.FlipFirstCard (gameDeck [0]);
			flip.FlipSecondCard (gameDeck [1]);

			flip.timesFlipped = 0;
			//drawButton.interactable = true;
			shuffleButton.GetComponent<Button> ().interactable = false;

			/*card.transform.rotation = Quaternion.identity;
			card.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");
			card.GetComponent<SpriteRenderer> ().flipX = false;

			card2.transform.rotation = Quaternion.identity;
			card2.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");
			card2.GetComponent<SpriteRenderer> ().flipX = false;

			card.transform.position = draw.origin;
			card2.transform.position = draw.origin;*/

			numeric.text = "";
			suit.text = "";

			clicked = false;
		}

		if (ani) {

			if (resetOnce) {
				card.transform.rotation = Quaternion.identity;
				card.GetComponent<SpriteRenderer> ().flipX = false;
				card2.transform.rotation = Quaternion.identity;
				card2.GetComponent<SpriteRenderer> ().flipX = false;
				resetOnce = false;
			}

			if (card.transform.rotation.eulerAngles.y < 78 && card2.transform.rotation.eulerAngles.y < 78) {
				card.transform.Rotate (Vector3.up, 78 * flipSpeed * Time.deltaTime);
				card2.transform.Rotate (Vector3.up, 78 * flipSpeed * Time.deltaTime);
			}

			if (card.transform.rotation.eulerAngles.y >= 78 && card2.transform.rotation.eulerAngles.y >= 78) {
				//print ("Card is back");
				card.GetComponent<SpriteRenderer> ().flipX = true;
				card.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");

				card2.GetComponent<SpriteRenderer> ().flipX = true;
				card2.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");
			}

			if (card.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> ("CardArt/CardBack") && card.transform.rotation.eulerAngles.y >= 78 && card.transform.rotation.eulerAngles.y < 180) {
				//print ("Card is different");
				card.transform.Rotate (Vector3.up, 78 * flipSpeed * Time.deltaTime);
			}

			if (card2.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> ("CardArt/CardBack") && card2.transform.rotation.eulerAngles.y >= 78 && card2.transform.rotation.eulerAngles.y < 180) {
				//print ("Card is different");
				card2.transform.Rotate (Vector3.up, 78 * flipSpeed * Time.deltaTime);
			}

			if (card.transform.rotation.eulerAngles.y >= 180 && card2.transform.rotation.eulerAngles.y >= 180) {
				//print ("Done");

				if (card.transform.position != draw.origin) {
					card.transform.position = Vector3.MoveTowards (card.transform.position, draw.origin, moveSpeed);
				}

				if (card2.transform.position != draw.origin) {
					card2.transform.position = Vector3.MoveTowards (card2.transform.position, draw.origin, moveSpeed);
				}

				if (card.transform.position == draw.origin && card2.transform.position == draw.origin) {
					ani = false;
					ani2 = true;
					card.transform.rotation = Quaternion.identity;
					card.GetComponent<SpriteRenderer> ().flipX = false;
					card2.transform.rotation = Quaternion.identity;
					card2.GetComponent<SpriteRenderer> ().flipX = false;

				}
					
			}
			
		}


		if (ani2) {
			
			if (card.transform.position != shufflePoint.transform.position) {
				card.transform.position = Vector3.MoveTowards (card.transform.position, shufflePoint.transform.position, moveSpeed2);
			}

			if (card2.transform.position != shufflePoint.transform.position) {
				card2.transform.position = Vector3.MoveTowards (card2.transform.position, shufflePoint.transform.position, moveSpeed2);
			}

			if (card.transform.position == shufflePoint.transform.position && card2.transform.position == shufflePoint.transform.position) {
				ani2 = false;
				ani3 = true;
				temp1.GetComponent<SpriteRenderer> ().enabled = true;
				temp2.GetComponent<SpriteRenderer> ().enabled = true;
				temp3.GetComponent<SpriteRenderer> ().enabled = true;
				temp4.GetComponent<SpriteRenderer> ().enabled = true;
				temp5.GetComponent<SpriteRenderer> ().enabled = true;
				temp6.GetComponent<SpriteRenderer> ().enabled = true;
				temp7.GetComponent<SpriteRenderer> ().enabled = true;
				temp8.GetComponent<SpriteRenderer> ().enabled = true;
				temp9.GetComponent<SpriteRenderer> ().enabled = true;
				temp10.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}


		if (ani3) {

			if (temp10.transform.position != draw.origin) {
				temp10.transform.position = Vector3.MoveTowards (temp10.transform.position, draw.origin, shuffleSpeed1);
			}

			if (temp9.transform.position != draw.origin) {
				temp9.transform.position = Vector3.MoveTowards (temp9.transform.position, draw.origin, shuffleSpeed2);
			}

			if (temp8.transform.position != draw.origin) {
				temp8.transform.position = Vector3.MoveTowards (temp8.transform.position, draw.origin, shuffleSpeed3);
			}

			if (temp7.transform.position != draw.origin) {
				temp7.transform.position = Vector3.MoveTowards (temp7.transform.position, draw.origin, shuffleSpeed4);
			}

			if (temp6.transform.position != draw.origin) {
				temp6.transform.position = Vector3.MoveTowards (temp6.transform.position, draw.origin, shuffleSpeed5);
			}

			if (temp5.transform.position != draw.origin) {
				temp5.transform.position = Vector3.MoveTowards (temp5.transform.position, draw.origin, shuffleSpeed6);
			}

			if (temp4.transform.position != draw.origin) {
				temp4.transform.position = Vector3.MoveTowards (temp4.transform.position, draw.origin, shuffleSpeed7);
			}

			if (temp3.transform.position != draw.origin) {
				temp3.transform.position = Vector3.MoveTowards (temp3.transform.position, draw.origin, shuffleSpeed8);
			}

			if (temp2.transform.position != draw.origin) {
				temp2.transform.position = Vector3.MoveTowards (temp2.transform.position, draw.origin, shuffleSpeed9);
			}

			if (temp1.transform.position != draw.origin) {
				temp1.transform.position = Vector3.MoveTowards (temp1.transform.position, draw.origin, shuffleSpeed10);
			}

			if (card.transform.position != draw.origin) {
				card.transform.position = Vector3.MoveTowards (card.transform.position, draw.origin, shuffleSpeed11);
			}

			if (card2.transform.position != draw.origin) {
				card2.transform.position = Vector3.MoveTowards (card2.transform.position, draw.origin, shuffleSpeed12);
			}

			if (temp10.transform.position == draw.origin && temp9.transform.position == draw.origin && temp8.transform.position == draw.origin && temp7.transform.position == draw.origin
				&& temp6.transform.position == draw.origin && temp5.transform.position == draw.origin && temp4.transform.position == draw.origin && temp3.transform.position == draw.origin
				&& temp2.transform.position == draw.origin && temp1.transform.position == draw.origin &&  card2.transform.position == draw.origin) {

				temp1.GetComponent<SpriteRenderer> ().enabled = false;
				temp2.GetComponent<SpriteRenderer> ().enabled = false;
				temp3.GetComponent<SpriteRenderer> ().enabled = false;
				temp4.GetComponent<SpriteRenderer> ().enabled = false;
				temp5.GetComponent<SpriteRenderer> ().enabled = false;
				temp6.GetComponent<SpriteRenderer> ().enabled = false;
				temp7.GetComponent<SpriteRenderer> ().enabled = false;
				temp8.GetComponent<SpriteRenderer> ().enabled = false;
				temp9.GetComponent<SpriteRenderer> ().enabled = false;
				temp10.GetComponent<SpriteRenderer> ().enabled = false;

				temp1.transform.position = shufflePoint.transform.position;
				temp2.transform.position = shufflePoint.transform.position;
				temp3.transform.position = shufflePoint.transform.position;
				temp4.transform.position = shufflePoint.transform.position;
				temp5.transform.position = shufflePoint.transform.position;
				temp6.transform.position = shufflePoint.transform.position;
				temp7.transform.position = shufflePoint.transform.position;
				temp8.transform.position = shufflePoint.transform.position;
				temp9.transform.position = shufflePoint.transform.position;
				temp10.transform.position = shufflePoint.transform.position;

				drawButton.interactable = true;

				ani3 = false;
			}

		}
	
	}

	void ShuffleOnClick()
	{
		clicked = true;
		ani = true;
		resetOnce = true;
	}
		
}
