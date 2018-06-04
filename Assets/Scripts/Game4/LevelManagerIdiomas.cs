using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerIdiomas : MonoBehaviour {

	public static LevelManagerIdiomas instance;

	[SerializeField]
	Text textMessage;
	[SerializeField]
	Scrollbar playerScrollBar;
	[SerializeField]
	Scrollbar enemyScrollBar;

	[SerializeField]
	IdiomButton idButtonScript;

	[SerializeField]
	IdiomasEnemyController enemyController;

	[SerializeField]
	GameObject WinGo;
	[SerializeField]
	GameObject LooseGo;

	bool anyDeath = false;
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

	IEnumerator AnimateText(string newText){
		for (int i = 0; i < (newText.Length+1); i++)
		{
			textMessage.text = newText.Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}
		idButtonScript.canPress = true;
	}

	IEnumerator AnimateTextPlayer(string newText){
		for (int i = 0; i < (newText.Length+1); i++)
		{
			textMessage.text = newText.Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}
		yield return new WaitForSeconds(1f);

		if(!anyDeath)
			enemyController.Attack ();
	}

	public void SendMessageToScreen(string message){
		StartCoroutine (AnimateTextPlayer(message));
	}

	public void SendMessageToScreenEnemy(string message){
		StartCoroutine (AnimateText(message));
	}

	public void TakeDamagePlayer(float lifeTaken){
		playerScrollBar.size -= lifeTaken;
		if (playerScrollBar.size <= 0)
			PlayerDeath ();
	}

	public void TakeDamageEnemy(float lifeTaken){
		enemyScrollBar.size -= lifeTaken;
		if (enemyScrollBar.size <= 0)
			EnemyDeath ();
	}

	public void HealPlayer(float healTaken){
		playerScrollBar.size += healTaken;
	}
	public void HealEnemy(float healTaken){
		enemyScrollBar.size += healTaken;
	}

	void PlayerDeath(){
		LooseGo.SetActive (true);
		anyDeath = true;
	}

	void EnemyDeath (){
		WinGo.SetActive (true);
		anyDeath = true;
	}

	public void Restart(){
		playerScrollBar.size = 1;
		enemyScrollBar.size = 1;
		anyDeath = false;
		idButtonScript.canPress = true;
		WinGo.SetActive (false);
		LooseGo.SetActive (false);
		textMessage.text = "";
	}
}
