using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerInfo : MonoBehaviour {

	public static LevelManagerInfo instance;

	[SerializeField]
	Text textAnswer;
	[SerializeField]
	Text textSave;

	string goatText;

	[SerializeField]
	GameObject[] questionButtons;

	bool canPressButton = true;

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

	public void AnswerQuestion(int number){
		if (!canPressButton)
			return;
		canPressButton = false;
		switch(number){
		case 0:
			goatText = "Hola, soy David Vacas Miguel, encantado de conocerte.";
			break;
		case 1:
			goatText = "Pues naci el 15 de febrero de 1995.";
			break;
		case 2:
			goatText = "Soy de Alcorcon, una ciudad al sur de Madrid.";
			break;
		case 3:
			goatText = "Pues mi correo electronico es davidvacasmiguel@hotmail.com, tambien te dejo mi movil 645490997.";
			break;
		}
		questionButtons [number].SetActive (false);
		questionButtons [number] = null;
		StartCoroutine(AnimateText(number));
	}

	IEnumerator AnimateText(int answerToSave){

		for (int i = 0; i < (goatText.Length+1); i++)
		{
			textAnswer.text = goatText.Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}

		WritteSaveText (answerToSave);
		canPressButton = true;
	}

	void WritteSaveText(int answerToSave){
		switch(answerToSave){
		case 0:
			textSave.text += "\nNombre: David Vacas Miguel.";
			break;
		case 1:
			textSave.text += "\nFecha de nacimiento: 15/02/1995.";
			break;
		case 2:
			textSave.text += "\nDireccion: C/Palmeras Nº10 Portal.6 1º4, Alcorcon, Madrid.";
			break;
		case 3:
			textSave.text += "\nTelefono: 645490997.";
			textSave.text += "\nE-mail: davidvacasmiguel@hotmail.com.";
			break;
		}
		bool last = true;
		for (int i = 0; i < questionButtons.Length; i++) {
			if(questionButtons[i]!=null){
				last = false;
				return;
			}
		}
		if(last){
			textSave.text += "\nDNI: 50250340D.";
		}
	}
}
