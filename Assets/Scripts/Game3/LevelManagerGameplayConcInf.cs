using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerGameplayConcInf : MonoBehaviour {

	[SerializeField]
	GameObject bugPref;

	[SerializeField]
	Transform spawnParent;

	[SerializeField]
	Text textInfo;

	public static LevelManagerGameplayConcInf instance;

	public float spawnRate = 4;

	int bugsCounter = 0;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		
		Invoke ("SpawnBug",spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBug(){
		int i = Random.Range (0,spawnParent.childCount);
		GameObject bug = Instantiate (bugPref, spawnParent.GetChild (i).transform.position, bugPref.transform.rotation) as GameObject;
		Destroy (bug,5);
		Invoke ("SpawnBug",spawnRate);
	}

	public void BugFixed(){
		bugsCounter++;
		switch (bugsCounter) {
		case 2:
			WriteText ("Unity (C#), Java = Alto.");
			break;
		case 4:
			WriteText ("\nUnreal (Blueprints), C, JavaScript = Medio.");
			break;
		case 6:
			WriteText ("\nUnreal (C++) = Bajo.");
			LevelManagerConcInf.instance.WinGame ();
			CancelInvoke ();
			break;
		}
	}
		
	void WriteText(string text){
		textInfo.text += text;
	}

	void OnEnable(){
		bugsCounter = 0;
	}

	public void Restart(){
		bugsCounter = 0;
		textInfo.text = "";
		Invoke ("SpawnBug",spawnRate);
	}
}
