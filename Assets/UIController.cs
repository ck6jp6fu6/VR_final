using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour {

	public Image bloodPaw;
	public Text Point;
	Tweener tweenAnimation;

	public void PlayHitAnimatoin(){
		if (tweenAnimation != null)
			tweenAnimation.Kill ();

		bloodPaw.color = Color.white;
		tweenAnimation = DOTween.To(() => bloodPaw.color, (x) => bloodPaw.color = x, new Color(1, 1, 1, 0), 0.5f);

	}

	// Use this for initialization
	void Start () {
	}
	
	public void SetPoint(int hp){
		Point.text = "Point : " + hp;
	}
}
