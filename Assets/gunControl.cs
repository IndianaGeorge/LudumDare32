using UnityEngine;
using System.Collections;

public class gunControl : MonoBehaviour {
	Transform gravityField;
	// Use this for initialization
	void Start () {
		gravityField = transform.Find("CharacterRig/torso/r_brazo/r_antebrazo/r_mano/weapon/gravityField");
		gravityField.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			gravityField.gameObject.SetActive(!gravityField.gameObject.activeSelf);
		}
	}
}
