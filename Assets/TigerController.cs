using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TigerController : MonoBehaviour {

	private Animator animator;
	private float minimumHitPeriod = 1f;
	private float hitCounter = 0;
	public float currentHP = 10;
	public AudioSource tigerAttack;
	public AudioSource tigerHit;

	public float moveSpeed;
	public GameObject followTarget;
	private Rigidbody rigidBody;
	public CollisionList playerSensor;
	public CollisionList attackSensor;
	public float attackPeriod = 1;
	private float attackCounter = 0;
	public GameObject playerObject;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		rigidBody = this.GetComponent<Rigidbody> ();
		player = playerObject.GetComponent<PlayerController> ();
	}
	public void AttackPlayer(){
		if (attackSensor.CollisionObjects.Count > 0 && currentHP > 0 && player.hp > 0) {
			//followTarget = GameObject.FindGameObjectWithTag ("Player");
			tigerAttack.Play ();
			player.transform.SendMessage ("Hit", 20);
		}
	}

	public void Hit(float value){
		tigerHit.Play ();
		if (hitCounter <= 0) {
			followTarget = GameObject.FindGameObjectWithTag ("Player");
			hitCounter = minimumHitPeriod;
			currentHP -= value;
			animator.SetFloat ("hp", currentHP);
			animator.SetTrigger ("hit");

			if (currentHP <= 0) {
				followTarget.SendMessage ("AddPoint", 20);
				BuryTheBody ();
			}
		}
	}

	void BuryTheBody(){
		this.GetComponent<Rigidbody> ().useGravity = false;
		this.GetComponent<Collider> ().enabled = false;
		this.transform.DOLocalRotate (new Vector3 ( 0, 0, -60), 0.5f);
		this.transform.DOMoveY (-0.8f, 1f).SetRelative (true).SetDelay (3).OnComplete (() => {
			this.transform.DOMoveY (-0.8f, 1f).SetRelative (true).SetDelay (1).OnComplete (() => {
				GameObject.Destroy (this.gameObject);
			});
		});
	}

	// Update is called once per frame
	void Update () {
		if (playerSensor.CollisionObjects.Count > 0) {
			followTarget = playerSensor.CollisionObjects [0].gameObject;
		}
		if (currentHP > 0 && hitCounter > 0) {
			hitCounter -= Time.deltaTime;
		} else {
			if (currentHP > 0) {
				if (followTarget != null) {
					Vector3 lookAt = followTarget.gameObject.transform.position;
					lookAt.y = this.gameObject.transform.position.y;
					this.transform.LookAt (lookAt);
					animator.SetBool ("run", true);

					if (attackSensor.CollisionObjects.Count > 0) {
						animator.SetBool ("attack", true);
						this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
					} else {
						animator.SetBool ("attack", false);
						rigidBody.velocity = this.transform.forward * moveSpeed;
					}
				}
			} else {
				this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}
		}
	}
}
