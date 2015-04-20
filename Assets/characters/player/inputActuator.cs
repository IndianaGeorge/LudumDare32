using UnityEngine;
using System.Collections;

public class inputActuator : MonoBehaviour, IActuator {

	public Vector3 getMotionCommand() {
		return new Vector3 (
			Input.GetAxis("Horizontal"),
			Input.GetButton ("Jump")?1:0,
			Input.GetAxis("Vertical")
			);
	}
}
