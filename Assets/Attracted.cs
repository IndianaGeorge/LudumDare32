using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Attracted : MonoBehaviour {
	public string attractorTag;
	public float range;
	public float intensity;
	public float maxRotation;
	Rigidbody rigidBody;
	float rotationSpeed = 0;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float sqRange = range * range;
		Vector3 diff;
		Vector3 position = transform.position;
		GameObject[] attractors;
		GameObject closestAttractor;
		float minSqrDistance = range*range;
		attractors = GameObject.FindGameObjectsWithTag (attractorTag);
		if (attractors.Length > 0) {
			diff = attractors [0].transform.position - position;
			minSqrDistance = diff.sqrMagnitude;
			closestAttractor = attractors [0];
			foreach (GameObject attractor in attractors) {
				diff = attractor.transform.position - position;
				if (diff.sqrMagnitude < minSqrDistance) {
					closestAttractor = attractor;
					minSqrDistance = diff.sqrMagnitude;
				}
			}
			if (minSqrDistance < sqRange) {
				if (!rigidBody.isKinematic) {
					rigidBody.isKinematic = true;
					Collider collider = GetComponent<Collider> ();
					collider.isTrigger = true;
					rotationSpeed = Random.value * maxRotation;
				}
				diff = closestAttractor.transform.position - position;
				float strength = intensity * (1 - (diff.sqrMagnitude / sqRange));
				transform.localPosition = transform.localPosition + (diff * strength * Time.deltaTime);
				transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
			} else { // back to physics
				if (rigidBody.isKinematic) {
					rigidBody.isKinematic = false;
					Collider collider = GetComponent<Collider> ();
					collider.isTrigger = false;
				}
			}
		} else { // no attractor, back to physics
			if (rigidBody.isKinematic) {
				rigidBody.isKinematic = false;
				Collider collider = GetComponent<Collider> ();
				collider.isTrigger = false;
			}
		}
	}
}
