using UnityEngine;

public interface IActuator {
	Vector3 getMotionCommand(); // vector of requested speed
}
