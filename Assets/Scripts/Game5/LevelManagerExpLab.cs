using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerExpLab : MonoBehaviour {

	GameObject goClicked;
	int idClicked;

	int aciertos = 0;

	public static LevelManagerExpLab instance;

	public bool canClick = true;
	public int clickCounter = 0;

	public GameObject winPanel;

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

	public void CardClicked(GameObject goIn, int idIn){

		if (goClicked == null) {
			goClicked = goIn;
			idClicked = idIn;
		} else {
		
			if (idClicked == idIn) {
				goClicked.SetActive (false);
				goIn.SetActive (false);

				aciertos++;
				if (aciertos >= 4) {
					winPanel.SetActive (true);
				}
			} else {
				goClicked.GetComponent<Card> ().DeactivateImage ();
				goIn.GetComponent<Card> ().DeactivateImage ();
			}
			goClicked = null;
			idClicked = -1;
		}

		canClick = true;

	}
}
