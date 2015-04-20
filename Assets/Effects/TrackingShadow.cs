using UnityEngine;
using System.Collections;

public class TrackingShadow : MonoBehaviour {
	public Transform shadowPrefab;
	public float radius;
	Transform shadow;

	// Use this for initialization
	void Start () {
		shadow = (Transform) Instantiate(shadowPrefab, transform.position, Quaternion.Euler(new Vector3(90,0,0)));
		shadow.localScale.Set (
			0.5f,
			0.5f,
			1
			);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray downRay = new Ray(transform.position, -Vector3.up);
		if (Physics.Raycast (downRay, out hit)) {
			if (!shadow.gameObject.activeSelf) {
				shadow.gameObject.SetActive(true);
			}
			shadow.localPosition = new Vector3(
				transform.position.x,
				transform.position.y - hit.distance,
				transform.position.z
				);
		} else {
			shadow.gameObject.SetActive(false);
		}
	}
}
