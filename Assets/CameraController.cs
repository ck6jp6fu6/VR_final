using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public CollisionList touchSensor;
	private ShootController shootControl;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		shootControl = this.GetComponent<ShootController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(touchSensor.CollisionObjects.Count > 0){
			for (int i = 0; i < touchSensor.CollisionObjects.Count; i++) {
				if (touchSensor.CollisionObjects [i] != null)
					shootControl.TryToTriggerGun ();
			}
		}
	}

	public void AddPoint(int point){
		player.AddPoint (point);
	}
}
