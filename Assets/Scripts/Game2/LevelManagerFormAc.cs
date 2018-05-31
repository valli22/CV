using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerFormAc : MonoBehaviour {

	[SerializeField]
	GameObject buttonStartPlay;
	[SerializeField]
	GameObject gameplay;

	[SerializeField]
	GameObject looseMenu;
	[SerializeField]
	SpawnObstacles spObstacles;

	[SerializeField]
	GameObject winMenu;

	[SerializeField]
	Animator anim;
	[SerializeField]
	Text logroText;

	int obstaclesPassed = 0;
	public int obstaclesPassedToWin = 10;

	public static LevelManagerFormAc instance;

	[SerializeField]
	Text textToPlaceText;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		buttonStartPlay.SetActive (false);
		gameplay.SetActive (true);
		spObstacles.Restart ();
	}

	public void LooseGame(){

		spObstacles.StopSpawning ();
		looseMenu.SetActive (true);
		obstaclesPassed = 0;
		textToPlaceText.text = "";
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Obstacle");
		foreach (GameObject item in gos) {
			Destroy (item.transform.parent.gameObject);
		}

	}

	public void Reintentar(){
		spObstacles.Restart ();
		looseMenu.SetActive (false);
	}

	public void PassedOne(){
		obstaclesPassed++;
		if (obstaclesPassed == obstaclesPassedToWin / 2) {
			logroText.text = "Graduacion (1/2)";
			anim.SetTrigger("LogroObtenido");
			textToPlaceText.text = "Doble Grado de Ingenieria Informatica e Ingenieria del Software\nUniversidad Rey Juan Carlos (Mostoles, Madrid)";
		}
		if (obstaclesPassed == obstaclesPassedToWin) {
			logroText.text = "Graduacion Completa! (2/2)";
			anim.SetTrigger("LogroObtenido");
			textToPlaceText.text += "\nMaster en Diseño y Desarrollo de Videojuegos.\nUniversidad Politecnica de Madrid.";
			spObstacles.StopSpawning ();
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Obstacle");
			foreach (GameObject item in gos) {
				Destroy (item.transform.parent.gameObject);
			}
			winMenu.SetActive (true);
		}
	}

	void OnDisable(){
		spObstacles.StopSpawning ();
		obstaclesPassed = 0;
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Obstacle");
		foreach (GameObject item in gos) {
			Destroy (item.transform.parent.gameObject);
		}
		gameplay.SetActive (false);
	}

	void OnEnable(){
		buttonStartPlay.SetActive (true);
		winMenu.SetActive (false);
	}

}
