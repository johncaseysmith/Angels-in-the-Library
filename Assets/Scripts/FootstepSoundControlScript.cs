using UnityEngine;
using System.Collections;

public class FootstepSoundControlScript : MonoBehaviour {

	// Use this for initialization
	private bool playing = false;
	public float timer = 0f;
	public float cutTime;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)){
			if(playing==false){
				this.audio.volume = 1;
				this.audio.Play();
				playing = true;
			}
			
		}
		else{
			timer += 1f*Time.deltaTime;
			this.audio.volume = 1f-timer/cutTime;
			if(timer>=cutTime){
				this.audio.Stop ();
				playing = false;
				timer=0;
			}
		}
	}
}
