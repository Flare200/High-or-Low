using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour {

	public string[] deck=new string[52];

	// Use this for initialization
	void Awake () {

		for (int i = 0; i < 13; i++) {
			switch(i)
			{
			case(0):
				deck [i] = "SA";
				break;
			case(9):
				deck [i] = "ST";
				break;
			case(10):
				deck [i] = "SJ";
				break;
			case(11):
				deck [i] = "SQ";
				break;
			case(12):
				deck [i] = "SK";
				break;
			default:
				deck [i] = "S" + (i + 1);
				break;
			}
			//print (deck [i]);
		}

		for (int i = 0; i < 13; i++) {
			switch(i)
			{
			case(0):
				deck [i+13] = "HA";
				break;
			case(9):
				deck [i+13] = "HT";
				break;
			case(10):
				deck [i+13] = "HJ";
				break;
			case(11):
				deck [i+13] = "HQ";
				break;
			case(12):
				deck [i+13] = "HK";
				break;
			default:
				deck [i+13] = "H" + (i + 1);
				break;
			}
			//print (deck [i+13]);
		}

		for (int i = 0; i < 13; i++) {
			switch(i)
			{
			case(0):
				deck [i+26] = "CA";
				break;
			case(9):
				deck [i+26] = "CT";
				break;
			case(10):
				deck [i+26] = "CJ";
				break;
			case(11):
				deck [i+26] = "CQ";
				break;
			case(12):
				deck [i+26] = "CK";
				break;
			default:
				deck [i+26] = "C" + (i + 1);
				break;
			}
			//print (deck [i+26]);
		}

		for (int i = 0; i < 13; i++) {
			switch(i)
			{
			case(0):
				deck [i+39] = "DA";
				break;
			case(9):
				deck [i+39] = "DT";
				break;
			case(10):
				deck [i+39] = "DJ";
				break;
			case(11):
				deck [i+39] = "DQ";
				break;
			case(12):
				deck [i+39] = "DK";
				break;
			default:
				deck [i+39] = "D" + (i + 1);
				break;
			}
			//print (deck [i+39]);
		}
			
		shuffle (deck);
		AceSpadesBias (deck);
		HeartsBias (deck);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void shuffle(string[] deck)
	{
		for (int i = 0; i < 52; i++) {
			string temp = deck [i];
			int randomIndex = Random.Range (i, 52);
			deck [i] = deck [randomIndex];
			deck [randomIndex] = temp;
			//print (deck [i]);
		}
	}

	public void AceSpadesBias(string[] deck)
	{
		for (int i = 0; i < 52; i++) {
			if (deck [i] == "SA") {
				string temp = deck [i];
				int randomIndex = Random.Range (0, 17);
				deck [i] = deck [randomIndex];
				deck [randomIndex] = temp;
				break;
			}
		}
	}

	public void HeartsBias(string[] deck)
	{
		for (int i = 0; i < 52; i++) {
			if (deck [i] [0] == 'H') {
				string temp = deck [i];
				GetRandom:
				int randomIndex = Random.Range (0, 26);
				if (deck [randomIndex] [0] == 'H'|| deck[randomIndex]=="SA")
					goto GetRandom;
				deck [i] = deck [randomIndex];
				deck [randomIndex] = temp;
			}
		}
	}
}
