#pragma strict
public var camera0 : Camera;
public var camera1 : Camera;
public var doorr: GameObject;
public var cam0light: GameObject;
public var cam1light: GameObject;
public var drightstatic: GameObject;
public var aangels: GameObject;
public var dyingbulb: GameObject;
public var count: int;
public var dlight : Light;
function Start () {
	camera0.active = false;
	camera1.active = false;
	aangels.SetActiveRecursively(false);
	cam0light.SetActiveRecursively(false);
	cam1light.SetActiveRecursively(false);
	dyingbulb.SetActiveRecursively(false);
	drightstatic.SetActiveRecursively(false);
	}
function Update () {
    if(Time.time < 39) {
		cam0light.SetActiveRecursively(true);
		camera0.active = true;
		doorr.animation.Play("doorright"); //9secs 
    }
    else if(Time.time >= 39&& (Time.time < 64)){
		camera0.active = false;
		cam0light.SetActiveRecursively(false);
		camera1.active = true;
		cam1light.SetActiveRecursively(true);
		aangels.SetActiveRecursively(true);
		aangels.animation.Play("aangels");
		drightstatic.SetActiveRecursively(true);
    }
    else{
    	aangels.SetActiveRecursively(false);
    	dyingbulb.SetActiveRecursively(true);
    	cam1light.SetActiveRecursively(false);
    	dlight.intensity = 0;
		Application.LoadLevel("mainRecovered");
    }
}