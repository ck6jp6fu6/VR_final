using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestcontroller : MonoBehaviour {

	public GameObject openChest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.layer);
		if (other.gameObject.layer == 8) {
			this.gameObject.SetActive (false);
			openChest.gameObject.SetActive (true);
		}
	}
}
