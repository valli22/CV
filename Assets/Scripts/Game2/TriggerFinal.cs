using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Obstacle")
			Destroy (other.transform.parent.gameObject);
	
	}
}
