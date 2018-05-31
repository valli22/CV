using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	public float jumpForce = 5;
	public bool canJump = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetButtonDown ("Jump") || Input.GetAxis ("Vertical") > 0 || Input.GetMouseButtonDown (0)) && canJump) {
			rb.AddForce (new Vector2(0,jumpForce),ForceMode2D.Impulse);
			canJump = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Obstacle")
			LevelManagerFormAc.instance.LooseGame ();

		if (other.tag == "Passed")
			LevelManagerFormAc.instance.PassedOne ();
	}
}
