using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerConcInf : MonoBehaviour {

	[SerializeField]
	GameObject gameplay;

	// Use this for initialization
	void Start (){
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		Camera.main.orthographic = false;
		gameplay.SetActive (true);
	}

	void OnDisable(){
		Camera.main.orthographic = true;
		gameplay.SetActive (false);
		GameObject[] bugs = GameObject.FindGameObjectsWithTag ("Bug");
		GameObject[] balas = GameObject.FindGameObjectsWithTag ("Bala");
		foreach (GameObject bug in bugs) {
			Destroy (bug);
		}
		foreach (GameObject bala in balas) {
			Destroy (bala);
		}
	}
}
