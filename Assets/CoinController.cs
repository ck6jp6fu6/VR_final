using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	private AudioSource coin;
	public int point;

	// Use this for initialization
	void Start () {
		coin = this.gameObject.GetComponent<AudioSource>();
	}

	public void OnTriggerEnter(Collider other){
		//Debug.Log (other.gameObject.layer);
		if (other.gameObject.layer == 8) {
			PlayerController player = other.gameObject.GetComponent<PlayerController> ();
			player.AddPoint (point);
			coin.Play ();
			Destroy (this.gameObject);
		}
	}
}
