using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomasEnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Attack(){
		string textMessage = "";
		int i = Random.Range (0,4);
		switch (i) {
		case 0:
			textMessage = "¡Allévoy!";
			LevelManagerIdiomas.instance.TakeDamagePlayer (0.2f);
			break;
		case 1:
			textMessage = "A winner is you";
			LevelManagerIdiomas.instance.HealEnemy (0.3f);
			break;
		case 2:
			textMessage = "I am error";
			LevelManagerIdiomas.instance.TakeDamageEnemy (0.1f);
			break;
		case 3:
			textMessage = "All your base are belong to us";
			LevelManagerIdiomas.instance.HealEnemy (0.2f);
			LevelManagerIdiomas.instance.TakeDamagePlayer (0.1f);
			break;
		default:
			break;
		}

		LevelManagerIdiomas.instance.SendMessageToScreenEnemy (textMessage);
	}

}
