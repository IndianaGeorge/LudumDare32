using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class CharacterMovement : MonoBehaviour {

	public float maxSpeed;
	public float jumpSpeed;
	public Vector3 speed;
	public bool isGrounded;
	public bool buttonDown;
	CharacterController characterController;
	Animator animator;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		buttonDown = Input.GetButton ("Jump");
		isGrounded = characterController.isGrounded;
		Vector2 flatSpeed = new Vector2 (
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical"));
		if (flatSpeed.magnitude > 1) {
			flatSpeed.Normalize();
		}
		flatSpeed = flatSpeed * maxSpeed;
		animator.SetFloat ("flatSpeed", flatSpeed.magnitude);
		if (characterController.isGrounded) { // floortime
			speed.Set(
				flatSpeed.x,
				0,
				flatSpeed.y
				);
			if (Input.GetButton ("Jump")) {
				speed.y = jumpSpeed;
			}
		} else { // airtime
			speed.Set(
				speed.x,
				speed.y + (Physics.gravity.y * Time.deltaTime),
				speed.z
				);
		}
		if (speed.x < 0) {
			transform.localScale = new Vector3(-1,1,1);
		}
		if (speed.x > 0) {
			transform.localScale = new Vector3(1,1,1);
		}
		characterController.Move (speed * Time.deltaTime);
	}
}
