using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	[SerializeField]
	Transform shootPoint;

	[SerializeField]
	GameObject balaPref;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Mouse X");
		float y = Input.GetAxis ("Mouse Y");
		transform.Rotate (new Vector3(y,-x,0));
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (balaPref,shootPoint.position,transform.rotation);
		}
	}
}
