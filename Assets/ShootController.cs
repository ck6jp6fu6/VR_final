using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootController : MonoBehaviour {

	public float minimumShootPeriod;

	private float shootCounter = 0;
	private AudioSource arrowSound;
	public Transform CameraTransform;
	public GameObject arrow;

	void Start(){
		arrowSound = this.GetComponent<AudioSource> ();
	}

	public void TryToTriggerGun(){
		if(shootCounter <= 0){
			CameraTransform.DOShakeRotation (minimumShootPeriod * 0.8f, 3f);
			shootCounter = minimumShootPeriod;
			GameObject newArrow = GameObject.Instantiate (arrow);
			ArrowController arrowControl = newArrow.GetComponent<ArrowController> ();
			arrowControl.transform.position = CameraTransform.position + new Vector3(0, 0.5f, 0);
			var rot = CameraTransform.rotation;
			arrowControl.transform.rotation = rot * Quaternion.Euler (0, 90, 0);
			arrowControl.InitAndShoot (CameraTransform.forward);
			arrowSound.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCounter > 0) {
			shootCounter -= Time.deltaTime;
		}
	}
}
