using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointCamera : MonoBehaviour {

	public UIController uiManager;
	public int hp = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddPoint(int point){
		hp += point;
		uiManager.SetPoint (hp);

	}
}
