using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomButton : MonoBehaviour {

	public bool canPress = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DamageEnemy(float i){
		if (!canPress)
			return;
		LevelManagerIdiomas.instance.TakeDamageEnemy (i);
	}

	public void DamagePlayer(float i){
		if (!canPress)
			return;
		LevelManagerIdiomas.instance.TakeDamagePlayer(i);
	}

	public void HealPlayer(float i){
		if (!canPress)
			return;
		LevelManagerIdiomas.instance.HealPlayer (i);
	}

	public void DoMessage(string m){
		if (!canPress)
			return;
		LevelManagerIdiomas.instance.SendMessageToScreen (m);
		canPress = false;
	}

	public void Restart(){
		LevelManagerIdiomas.instance.Restart ();
	}
}
