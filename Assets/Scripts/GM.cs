using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public static GM instance;

	int state = 0;
	[SerializeField]
	GameObject[] uiGO;
	[SerializeField]
	Button[] uiButtons;

	public Color pressedColor;
	public Color unPressedColor;
	public Color unPressedColorHighlighted;

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

	public void GoTo(int stateToGo){
		uiGO[state].SetActive (false);
		ColorBlock cb = uiButtons [state].colors;
		cb.normalColor = unPressedColor;
		cb.highlightedColor = unPressedColorHighlighted;
		uiButtons [state].colors = cb;
		state = stateToGo;
		uiGO [state].SetActive (true);
		cb = uiButtons [state].colors;
		cb.normalColor = pressedColor;
		cb.highlightedColor = pressedColor;
		uiButtons [state].colors = cb;
	}

	public void PreviousState(){
		if (state == 0)
			return;

		GoTo (state-1);
	}

	public void NextState(){
		if (state == 4)
			return;

		GoTo (state+1);
	}	
}
