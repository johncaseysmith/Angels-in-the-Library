private var speed : float = 3;

var searchTag = "Collide";
var scanFrequency : float = .1;
var collideDistance : float = 0;
private var minDistance : float = 2;
//var direction : Vector3;
var collide : Transform;
var futureDistance : float;
var closestPoint : Vector3;
private var ran : float;
var chase : boolean;


var player : Transform;
var playerDistance : float;
var rendererThis : Renderer;
var flashlight : Transform;
var flashlightAngle : float;


function Start() {
	direction = new Vector3( 0, 0, 0 );
	flashlightforward = new Vector3( 0, 0, 0);
	position = new Vector3( 0, 0, 0);
	ran = Random.Range(-90,90);
	chase = false;
	InvokeRepeating("scanForTarget", 0, scanFrequency);
}

function Update () {
	transform.Translate(speed * Vector3.forward * Time.deltaTime);
	playerDistance = (transform.position - player.position).sqrMagnitude;
	
	turnIfClose();
	
	var targetDir = flashlight.position - transform.position;
	var flashForward = flashlight.forward;
	
	flashlightAngle = Vector3.Angle(targetDir, flashForward);
	
	var targetPosition = new Vector3( player.position.x, this.transform.position.y, player.position.z);
	
	if (rendererThis.isVisible) {
		if (flashlightAngle > 150) {
			speed = 0;
			if (chase == false) {
				transform.LookAt(targetPosition);
				chase = true;
			}
		} else {
			speed = 3;
			if (chase == true) {
				speed = 5;
				transform.LookAt(targetPosition);
			}
		}
	} else {
		speed = 3;
		if (chase == true) {
			speed = 5;
			transform.LookAt(targetPosition);
		}
	}
	
	if (speed == 0) {
		transform.audio.volume = 0;
	} else {
		transform.audio.volume = 0.45;
	}
	
	 
	
	//if (distance < 1) {
		//Application.LoadLevel(0);
	//} // end if
}

function turnIfClose() {
	var futureVector : Vector3 = transform.position + speed * Vector3.forward * Time.deltaTime * 3;
	var closestPointVector : Vector3 = new Vector3( 0, futureVector.y + ran, 0);
	futureDistance = Vector3.Distance(futureVector, closestPoint);
	
	if (futureDistance < minDistance) {
		transform.Rotate(Vector3.Slerp(futureVector - speed * Vector3.forward * Time.deltaTime * 3, closestPointVector, Time.time));
		chase = false;
	} else {
		ran = Random.Range(-90,90);
	}
	
}

function scanForTarget() {
	collide = getNearestTaggedObject();
	closestPoint = collide.collider.ClosestPointOnBounds(transform.position);
	collideDistance = Vector3.Distance(closestPoint, transform.position);
}

function getNearestTaggedObject() : Transform {
	var nearestDistanceSqr = Mathf.Infinity;
	var taggedGameObjects = GameObject.FindGameObjectsWithTag(searchTag);
	var nearestObj : Transform = null;
	
	for (var obj : GameObject in taggedGameObjects) {
		var closestPoint : Vector3 = obj.collider.ClosestPointOnBounds(transform.position);
		var distanceSqr : float = Vector3.Distance(closestPoint, transform.position);
		
		if (distanceSqr < nearestDistanceSqr) {
			nearestObj = obj.transform;
			nearestDistanceSqr = distanceSqr;
		}
	}
	return nearestObj;
}