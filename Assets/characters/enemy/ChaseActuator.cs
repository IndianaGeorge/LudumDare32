using UnityEngine;
using System.Collections;

public class ChaseActuator : MonoBehaviour, IActuator {
	public Transform target;
	
	public Vector3 getMotionCommand() {
		return target.localPosition-transform.localPosition;
	}
}
