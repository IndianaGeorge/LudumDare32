using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
[RequireComponent (typeof (IActuator))]
public class CharacterMovement : MonoBehaviour {

	public float maxSpeed;
	public float jumpSpeed;
	Vector3 speed;
	CharacterController characterController;
	Animator animator;
	IActuator actuator;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		actuator = GetComponent<IActuator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 throttle = actuator.getMotionCommand ();
		Vector2 flatSpeed = new Vector2 (
			throttle.x,
			throttle.z
			);
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
			if (throttle.y > 0.5) {
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
