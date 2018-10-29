using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerConcInf : MonoBehaviour {

	[SerializeField]
	GameObject gameplay;

	[SerializeField]
	Text textInfo;

	[SerializeField]
	GameObject WinGameUI;

	public bool winGame = false;

	public static LevelManagerConcInf instance;

	// Use this for initialization
	void Start (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

	}

	void OnEnable(){
		Camera.main.orthographic = false;
		if(!winGame)
			gameplay.SetActive (true);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnDisable(){
		Camera.main.orthographic = true;
		GameObject[] bugs = GameObject.FindGameObjectsWithTag ("Bug");
		GameObject[] balas = GameObject.FindGameObjectsWithTag ("Bala");
		foreach (GameObject bug in bugs) {
			Destroy (bug);
		}
		foreach (GameObject bala in balas) {
			Destroy (bala);
		}
		if (winGame) {
			textInfo.text = "";
		}
		gameplay.SetActive (false);
	}

	public void WinGame(){
		GameObject[] bugs = GameObject.FindGameObjectsWithTag ("Bug");
		GameObject[] balas = GameObject.FindGameObjectsWithTag ("Bala");
		foreach (GameObject bug in bugs) {
			Destroy (bug);
		}
		foreach (GameObject bala in balas) {
			Destroy (bala);
		}
		gameplay.SetActive (false);
		WinGameUI.SetActive (true);
		winGame = true;
	}

	public void Restart(){
		winGame = false;
		WinGameUI.SetActive (false);
		gameplay.SetActive (true);
		Cursor.lockState = CursorLockMode.Locked;
		LevelManagerGameplayConcInf.instance.Restart ();
	}

}
