using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HorseController : MonoBehaviour {

	private Animator animator;
	private float minimumHitPeriod = 1f;
	private float hitCounter = 0;
	public float currentHP = 10;
	public AudioSource horseHit;
	public GameObject player;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}

	public void Hit(float value){
		if (hitCounter <= 0) {
			horseHit.Play ();
			hitCounter = minimumHitPeriod;
			currentHP -= value;

			animator.SetTrigger ("hit");

			if (currentHP <= 0) {
				this.transform.DOLocalRotate (new Vector3 ( 0, 0, -60), 0.5f);
				player.SendMessage ("AddPoint", -40);
				BuryTheBody ();
			}
		}
	}

	void BuryTheBody(){
		this.GetComponent<Rigidbody> ().useGravity = false;
		this.GetComponent<Collider> ().enabled = false;
		this.transform.DOMoveY (-0.8f, 1f).SetRelative (true).SetDelay (1).OnComplete (() => {
			this.transform.DOMoveY (-0.8f, 1f).SetRelative (true).SetDelay (1).OnComplete (() => {
				GameObject.Destroy (this.gameObject);
			});
		});
	}

	// Update is called once per frame
	void Update () {
		if (currentHP > 0 && hitCounter > 0) {
			hitCounter -= Time.deltaTime;
		}
	}
}
