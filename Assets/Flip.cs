using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flip : MonoBehaviour {

	public Button flipButton;
	public GameObject card, card2;
	bool clicked=false;
	public float speed;
	string cardsRoot="CardArt/";
	public string cardType1, cardType2; 
	string suit1, suit2, num1, num2, end1, end2;
	private Deck deck;
	public string[] gameDeck= new string[52];
	public int timesFlipped = 0;
	int suitNum1, suitNum2, cardNum1, cardNum2;
	public Text numeric, suit;

	void Awake() 
	{
		deck = GetComponent<Deck> ();	
	}

	// Use this for initialization
	void Start () {
		Button flip = flipButton.GetComponent<Button> ();
		flip.onClick.AddListener (FlipOnClick);
		flip.interactable = false;

		numeric = GameObject.Find ("Numeric Output").GetComponent<Text> ();
		numeric.text = "";

		suit = GameObject.Find ("Suit Output").GetComponent<Text> ();
		suit.text = "";

		card = GameObject.Find ("Card");
		card2 = GameObject.Find ("Card2");

		gameDeck = deck.deck;

		FlipFirstCard (gameDeck [0]);
		FlipSecondCard (gameDeck [1]);

	
	}
	
	// Update is called once per frame
	void Update () {

		if (timesFlipped == 1 || card.transform.eulerAngles.y > 0) {
			if (clicked && card.transform.rotation.eulerAngles.y < 78)
				card.transform.Rotate (Vector3.up, 78 * speed * Time.deltaTime);

			if (clicked && card.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> ("CardArt/CardBack") && card.transform.rotation.eulerAngles.y >= 78) {
				//print ("Card is back");
				card.GetComponent<SpriteRenderer> ().flipX = true;
				card.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (cardType1);
			}

			if (clicked && card.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> (cardType1) && card.transform.rotation.eulerAngles.y >= 78 && card.transform.rotation.eulerAngles.y < 180) {
				//print ("Card is different");
				card.transform.Rotate (Vector3.up, 78 * speed * Time.deltaTime);
			}

			if (clicked && card.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> (cardType1) && card.transform.rotation.eulerAngles.y >= 180 && timesFlipped != 2) {
				//print ("Done");
				clicked = false;
			}
		}

		if (timesFlipped == 2) {
			flipButton.interactable = false;

			if (clicked && card2.transform.rotation.eulerAngles.y < 78)
				card2.transform.Rotate (Vector3.up, 78 * speed * Time.deltaTime);

			if (clicked && card2.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> ("CardArt/CardBack") && card2.transform.rotation.eulerAngles.y >= 78) {
				//print ("Card is back");
				card2.GetComponent<SpriteRenderer> ().flipX = true;
				card2.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (cardType2);
			}

			if (clicked && card2.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> (cardType2) && card.transform.rotation.eulerAngles.y >= 78 && card2.transform.rotation.eulerAngles.y < 180) {
				//print ("Card is different");
				card2.transform.Rotate (Vector3.up, 78 * speed * Time.deltaTime);
			}

			if (clicked && card2.GetComponent<SpriteRenderer> ().sprite == Resources.Load<Sprite> (cardType2) && card2.transform.rotation.eulerAngles.y >= 180) {
				//print ("Done");
				clicked = false;

				if (cardNum2 == cardNum1)
					numeric.text = "Second Card is Equal To \n the First Card";
				else if (cardNum2 > cardNum1)
					numeric.text = "Second Card is Higher Than \n the First Card";
				else 
					numeric.text = "Second Card is Lower Than \n the First Card";

				if (suitNum2 == suitNum1)
					suit.text = "Second Card is Equal To \n the First Card";
				else if (suitNum2 > suitNum1)
					suit.text = "Second Card is Higher Than \n the First Card";
				else 
					suit.text = "Second Card is Lower Than \n the First Card";
					
			}

		}
	
	}

	void FlipOnClick()
	{
		timesFlipped++;
		clicked = true;
		//card.transform.rotation = Quaternion.identity;
		//card.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("CardArt/CardBack");
		//card.GetComponent<SpriteRenderer> ().flipX = false;

	}

	public void FlipFirstCard(string card)
	{
		switch (card [0]) 
		{
		case('S'):
			suit1 = "Spades/";
			end1 = "_S";
			suitNum1 = 4;
			break;
		case('H'):
			suit1 = "Hearts/";
			end1 = "_H";
			suitNum1 = 3;
			break;
		case('C'):
			suit1 = "Clubs/";
			end1 = "_C";
			suitNum1 = 2;
			break;
		case('D'):
			suit1 = "Diamonds/";
			end1 = "_D";
			suitNum1 = 1;
			break;
		}

		switch (card [1])
		{
		case('A'):
			num1 = "01_A";
			cardNum1 = 1;
			break;
		case('2'):
			num1 = "02_2";
			cardNum1 = 2;
			break;
		case('3'):
			num1 = "03_3";
			cardNum1 = 3;
			break;
		case('4'):
			num1 = "04_4";
			cardNum1 = 4;
			break;
		case('5'):
			num1 = "05_5";
			cardNum1 = 5;
			break;
		case('6'):
			num1 = "06_6";
			cardNum1 = 6;
			break;
		case('7'):
			num1 = "07_7";
			cardNum1 = 7;
			break;
		case('8'):
			num1 = "08_8";
			cardNum1 = 8;
			break;
		case('9'):
			num1 = "09_9";
			cardNum1 = 9;
			break;
		case('T'):
			num1 = "10_10";
			cardNum1 = 10;
			break;
		case('J'):
			num1 = "11_J";
			cardNum1 = 11;
			break;
		case('Q'):
			num1 = "12_Q";
			cardNum1 = 12;
			break;
		case('K'):
			num1 = "13_K";
			cardNum1 = 13;
			break;
		}

		cardType1 = cardsRoot + suit1 + num1 + end1;
	}


	public void FlipSecondCard(string card)
	{
		switch (card [0]) 
		{
		case('S'):
			suit2 = "Spades/";
			end2 = "_S";
			suitNum2 = 4;
			break;
		case('H'):
			suit2 = "Hearts/";
			end2 = "_H";
			suitNum2 = 3;
			break;
		case('C'):
			suit2 = "Clubs/";
			end2 = "_C";
			suitNum2 = 2;
			break;
		case('D'):
			suit2 = "Diamonds/";
			end2 = "_D";
			suitNum2 = 1;
			break;
		}

		switch (card [1])
		{
		case('A'):
			num2 = "01_A";
			cardNum2 = 1;
			break;
		case('2'):
			num2 = "02_2";
			cardNum2 = 2;
			break;
		case('3'):
			num2 = "03_3";
			cardNum2 = 3;
			break;
		case('4'):
			num2 = "04_4";
			cardNum2 = 4;
			break;
		case('5'):
			num2 = "05_5";
			cardNum2 = 5;
			break;
		case('6'):
			num2 = "06_6";
			cardNum2 = 6;
			break;
		case('7'):
			num2 = "07_7";
			cardNum2 = 7;
			break;
		case('8'):
			num2 = "08_8";
			cardNum2 = 8;
			break;
		case('9'):
			num2 = "09_9";
			cardNum2 = 9;
			break;
		case('T'):
			num2 = "10_10";
			cardNum2 = 10;
			break;
		case('J'):
			num2 = "11_J";
			cardNum2 = 11;
			break;
		case('Q'):
			num2 = "12_Q";
			cardNum2 = 12;
			break;
		case('K'):
			num2 = "13_K";
			cardNum2 = 13;
			break;
		}

		cardType2 = cardsRoot + suit2 + num2 + end2;
	}
		
}
