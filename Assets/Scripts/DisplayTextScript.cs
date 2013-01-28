using UnityEngine;
using System.Collections;

public class DisplayTextScript : MonoBehaviour {

	private string instructions;
	private string winString;
	private string loseString;
	private string empty = "";
	public Light endLight;
	public float displayTime = 0;
	void Start () {
		instructions = "How to play the game: " + "\n" + "W,A,S,D to move" + "\n" + "F to pick up and drop lightbulbs" + "\n" + "R to screw in lighbulbs" + "\n" + "Don't blink.";
		winString = "You won!" + "\n" + "Press P to play again.";
		loseString = "You blinked." + "\n" + "Press P to play again.";
	}
	
	// Update is called once per frame
	void Update () {
		if(displayTime < 5){
			guiText.text = instructions;
	
		}
		else if(displayTime>5 && displayTime < 6){
			guiText.text = empty;	
		}

		if(displayTime<10){
			displayTime+=1 *Time.deltaTime;	
		}
		if(endLight.color==Color.red && endLight.intensity>1){
			guiText.text = loseString;	
		}
		else if(endLight.color==Color.white && endLight.intensity>1){
			guiText.material.color = Color.black;
			guiText.text = winString;
		}
		else if(displayTime>5){
			guiText.text = empty;
		}
	}
}
