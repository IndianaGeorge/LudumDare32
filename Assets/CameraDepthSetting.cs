using UnityEngine;
using System.Collections;

public class CameraDepthSetting : MonoBehaviour {
	public TransparencySortMode mode;

	// Use this for initialization
	void Start () {
		GetComponent<Camera>().transparencySortMode = mode;
	}

}
