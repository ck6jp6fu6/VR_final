using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float damageValue = 15;

	public void InitAndShoot(Vector3 Direction){
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
		rigidbody.velocity = Direction * speed;
		Invoke ("KillYourSelf", lifeTime);
	}

	// Use this for initialization
	public void KillYourSelf () {
		GameObject.Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if(other.gameObject.layer == 12 || other.gameObject.layer == 13)
			other.gameObject.SendMessage ("Hit", damageValue);
		KillYourSelf ();
	}
}
