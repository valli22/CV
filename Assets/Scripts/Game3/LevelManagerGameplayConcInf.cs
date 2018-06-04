using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerGameplayConcInf : MonoBehaviour {

	[SerializeField]
	GameObject bugPref;

	[SerializeField]
	Transform spawnParent;

	public float spawnRate = 4;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnBug",spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBug(){
		int i = Random.Range (0,spawnParent.childCount);
		Instantiate (bugPref, spawnParent.GetChild (i).transform.position, bugPref.transform.rotation);
		Invoke ("SpawnBug",spawnRate);
	}
}
