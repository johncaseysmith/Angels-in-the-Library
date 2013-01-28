using UnityEngine;
using System.Collections;

public class HangingLampScript : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject angel;
	public GameObject bulb;
	public GameObject hand;
	public Light lampLight;
	public Light endLight;
	private bool lampOn = false;
	private bool won = false;
	private bool collided = false;
	public int dist;
	public int killDist;
	public int bulbDist;
	public int winNum = 2;
	public GUIText winText;
	public float maxBright = 8;
	public float endIntensity;
	public Vector3 homeVector = new Vector3(-32f,2.11f,-14.89f);
	private Vector3 tempPosition;
	private Vector3 lockPosition;

	
	private static int lampsOn = 0;
	
	private bool on = false;
	private Component bulbScript; 
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			if(Vector3.Distance (player.transform.position,this.transform.position)< dist){
				if(Vector3.Distance (player.transform.position,bulb.transform.position)<bulbDist && lampOn==false){
					lampLight.intensity = 4.5f;
					lampLight.range=15;
					PickUpObjectsCSharpScript pick = bulb.GetComponent("PickUpObjectsCSharpScript") as PickUpObjectsCSharpScript;
					pick.isHolding=false;
					bulb.transform.position = homeVector;
					lampsOn++;
					lampOn=true;
				}
			}
		}
		
		//win loss code
		//win code
		if(lampsOn >= winNum){
			if(won==false){
				lockPosition=player.transform.position;
				won=true;
				//winText.material.color = Color.black;
				//winText.text = "Congradulations! You won! \n Press P to play again.";
			}
			endLight.color = Color.white;
			if(endLight.intensity<=maxBright){
				endLight.intensity += 2f*Time.deltaTime;
			}
			player.transform.position = lockPosition;
			if(Input.GetKeyDown (KeyCode.P)){
				lampsOn=0;
				Application.LoadLevel("mainRecovered");
			}
		}
		//lose code
		if(Vector3.Distance (player.transform.position, angel.transform.position) < killDist){
			if(collided==false){
				lockPosition=player.transform.position;
				tempPosition=angel.transform.position;
				angel.audio.volume = 0;
				hand.audio.Play();
				collided=true;
			}
			if(Input.GetKeyDown (KeyCode.P)){
				lampsOn=0;
				angel.audio.volume=.66f;
				Application.LoadLevel("mainRecovered");
			}
			endLight.color = Color.red;	
			if(endLight.intensity <= endIntensity)
				endLight.intensity +=2f*Time.deltaTime;
		}

		if(collided){
			player.transform.position=lockPosition;
			angel.transform.position=tempPosition;
		}
	}
}
