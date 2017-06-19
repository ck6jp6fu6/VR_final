using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

	private float rotateSpeed = 3;
	private float rotateSpeedScale = 18f;

	private float MoveSpeed = 3;
	private float MoveSpeedScale = 12f;
	float currentSpeed = 0;
	private Rigidbody rigidBody;
	private Rigidbody camrigidBody;
	public CollisionList touchSensor;
	public GameObject CameraParent;
	public Transform CameraTransform;
	private ShootController shootControl;
	public UIController uiManager;
	public GameObject gameOver;
	public int hp = 100;
	public AudioSource gameOverSound;
	public AudioSource bgm;

	// Use this for initialization
	void Start () {
		//animatorController = this.GetComponent<Animator> ();
		camrigidBody = CameraParent.GetComponent<Rigidbody> ();
		rigidBody = this.GetComponent<Rigidbody> ();
		shootControl = this.GetComponent<ShootController> ();
		//touchSensor = this.GetComponent<CollisionList> ();
		VRSettings.enabled = true;
		bgm.Play ();
	}

	public void Hit(int value){
		if (hp <= 0) {
			return;
		}
		hp -= value;
		uiManager.SetPoint (hp);

		if (hp > 0) {
			uiManager.PlayHitAnimatoin();
		} else {
			gameOver.SetActive (true);
			bgm.Pause ();
			gameOverSound.Play ();
			rigidBody.gameObject.GetComponent<Collider> ().enabled = false;
			rigidBody.useGravity = false;
			rigidBody.velocity = Vector3.zero;
			this.enabled = false;
			//rotateXTransform.transform.DOLocalRotate (new Vector3 (-60, 0, 0), 0.5f);
			//rotateYTransform.transform.DOLocalMoveY (-1.0f, 0.5f).SetRelative (true);
		}
	}

	public void AddPoint(int point){
		hp += point;
		uiManager.SetPoint (hp);
	}

	// Update is called once per frame
	void Update () 
	{
		Cursor.visible = false;
		//if (Input.GetKey(KeyCode.Space)) {
		/*if(touchSensor.CollisionObjects.Count > 0){
			for (int i = 0; i < touchSensor.CollisionObjects.Count; i++) {
				if (touchSensor.CollisionObjects [i] != null)
					shootControl.TryToTriggerGun ();
			}
		}*/
		Vector3 movDirection = Vector3.zero;
		Vector3 VRMove = Vector3.zero;
		rigidBody.transform.rotation = Quaternion.Euler (CameraTransform.transform.rotation.eulerAngles.x, 
			CameraTransform.transform.rotation.eulerAngles.y, CameraTransform.transform.rotation.eulerAngles.z);
		if (CameraTransform.transform.rotation.eulerAngles.x > 10 && CameraTransform.transform.rotation.eulerAngles.x < 90) {
			//VRMove.z += 1;
			//VRMove = VRMove.normalized;
			//Vector3 VRmovement = transform.forward * VRMove.z * Time.deltaTime;
			rigidBody.MovePosition (rigidBody.position + transform.forward * 7 * Time.deltaTime);
			camrigidBody.MovePosition(rigidBody.position + transform.forward * 7 * Time.deltaTime);
			movDirection.z += 1;
			//CameraTransform.DOLocalMove (camaratransform.position + VRmovement, 0.5f);
		}
	
		if (CameraTransform.transform.rotation.eulerAngles.x < 330 && CameraTransform.transform.rotation.eulerAngles.x > 270){
			rigidBody.MovePosition (rigidBody.position + -transform.forward * 5 * Time.deltaTime);
			camrigidBody.MovePosition(rigidBody.position + -transform.forward * 5 * Time.deltaTime);
			movDirection.z -= 1;
		}
		//決定鍵盤input的結果

		if (Input.GetKey (KeyCode.W)){
			rigidBody.MovePosition (rigidBody.position + transform.forward * 20 * Time.deltaTime);
			camrigidBody.MovePosition(rigidBody.position + transform.forward * 20 * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.S)){
			rigidBody.MovePosition (rigidBody.position + -transform.forward * 2 * Time.deltaTime);
			camrigidBody.MovePosition(rigidBody.position + -transform.forward * 2 * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.D)){movDirection.x += 1;} 
		if (Input.GetKey (KeyCode.A)){movDirection.x -= 1;} 

		movDirection = movDirection.normalized;
		//Vector3	camUp = GvrViewer.Instance.HeadPose.Orientation * Vector3.up;
		//float VRMoveSpeed = camUp.z * MoveSpeedScale;
//		Vector3 movement = transform.forward * VRMoveSpeed * Time.deltaTime;
		//rigidBody.MovePosition (rigidBody.position + movement);

		//決定要給Animator的動畫參數
		if (movDirection.magnitude == 0) {currentSpeed = 0;} 
		else {
			if (movDirection.z < 0) {currentSpeed = -MoveSpeed;} 
			else {currentSpeed = MoveSpeed;}
		}
//		animatorController.SetFloat("Speed",currentSpeed);
		//轉換成世界座標的方向
		//Vector3 worldSpaceDirection = movDirection.z * rotateYTransform.transform.forward + movDirection.x * rotateYTransform.transform.right;
		Vector3 velocity = rigidBody.velocity;
		//velocity.x = worldSpaceDirection.x * MoveSpeed;
	//	velocity.z = worldSpaceDirection.z * MoveSpeed;

	

		//rigidBody.velocity = velocity;
		//velocity.x = velocity.x * (float)0.8;
		//velocity.z = velocity.z * (float)0.8;
		//camrigidBody.velocity = velocity;

		//計算滑鼠
	
		//rotateYTransform.transform.localEulerAngles += new Vector3 (0,camaratransform.rotation.eulerAngles.y,0) * rotateSpeed;
		/*currentRotateX += Input.GetAxis ("Vertical") * rotateSpeed;
		if (currentRotateX > 90) {
			currentRotateX = 90;
		} else if (currentRotateX < -90) {
			currentRotateX = -90;
		}*/
		//rotateXTransform.transform.localEulerAngles = new Vector3 (-currentRotateX,0,0);
	}
}