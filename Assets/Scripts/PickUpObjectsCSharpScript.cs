using UnityEngine;
using System.Collections;

public class PickUpObjectsCSharpScript : MonoBehaviour {
	
	public GameObject SpawnTo;
	public int dist = 1;
	public bool isHolding = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)) { //if you press "F"
			if(Vector3.Distance(SpawnTo.transform.position, this.transform.position) < dist) { //if distance is less than dist variable
				isHolding = !isHolding;  //changes isHolding var from false to true
			}
		}
		if(isHolding == true) {
			this.rigidbody.useGravity = false; //sets gravity to not on so it doesnt fall to the ground
			this.transform.parent = SpawnTo.transform;  //parents the object
			this.transform.position = SpawnTo.transform.position; //sets the position
			this.transform.rotation = SpawnTo.transform.rotation; //sets the rotation
			this.transform.collider.isTrigger = true;
		}
		else {
			//SpawnTo.transform.DetachChildren();  //detatch object from hand
			this.transform.parent = null;
			this.rigidbody.useGravity = true; //add the gravity back to the object
			this.transform.collider.isTrigger = false;
		}
	}
}
