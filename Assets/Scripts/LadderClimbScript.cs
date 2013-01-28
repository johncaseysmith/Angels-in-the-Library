using UnityEngine;
using System.Collections;

public class LadderClimbScript : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	private bool climbContact;
	public float climbSpeed;
	private Vector3 climbVector = new Vector3(0f,1f,0f);
	void Start () {
		climbContact = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(climbContact && Input.GetKey(KeyCode.W)){
			player.transform.position+=climbVector*climbSpeed*Time.deltaTime;	
		}
	}
	void OnTriggerEnter(Collider other){
		climbContact = true;
	}
	void OnTriggerExit(Collider other){
		climbContact = false;	
	}
}
