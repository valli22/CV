using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	[SerializeField]
	Rigidbody rb;

	public float power = 10;

	// Use this for initialization
	void Start () {
		rb.AddForce (transform.forward*power,ForceMode.Impulse);
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "Bug") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
