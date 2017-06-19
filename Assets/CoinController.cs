using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	public AudioSource coin;
	public int point;

	// Use this for initialization
	void Start () {
		//coin = this.gameObject.GetComponent<AudioSource>();
	}

	public void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.layer);
			CameraController player = other.gameObject.GetComponent<CameraController> ();
			player.AddPoint (point);
			coin.Play ();
			Destroy (this.gameObject);
	}
}
