using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestcontroller : MonoBehaviour {

	public GameObject openChest;
	public GameObject UI;
	public AudioSource win;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		//Debug.Log (other.gameObject.layer);
		if (other.gameObject.layer == 8) {
			this.gameObject.SetActive (false);
			openChest.gameObject.SetActive (true);
			UI.SetActive (true);
			UI.transform.GetChild (0).GetComponent<Image> ().enabled = false;
			UI.transform.GetChild(1).GetComponent<Text>().text = "YOU WIN";
			win.Play ();
		}
	}
}
