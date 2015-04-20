using UnityEngine;
using System.Collections;

public class VibrateOnRange : MonoBehaviour {
	public string attractorTag;
	public float range;
	public float intensity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float sqRange = range * range;
		Vector3 diff;
		Vector3 position = transform.position;
		GameObject[] attractors;
		float sum = 0;
		attractors = GameObject.FindGameObjectsWithTag (attractorTag);
		foreach (GameObject attractor in attractors) {
			diff = attractor.transform.position - position;
			sum += diff.sqrMagnitude<sqRange? range - diff.magnitude : 0;
		}
		sum /= range;
		if (sum > 1) { // cap intensity
			sum = 1;
		}
		transform.localPosition = Random.insideUnitSphere * sum * intensity;
	}
}
