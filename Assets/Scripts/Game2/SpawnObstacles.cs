using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

	[SerializeField]
	float cd = 3;

	[SerializeField]
	GameObject[] obstaclePrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPref(){
		int i = Random.Range (0,obstaclePrefab.Length);
		Instantiate (obstaclePrefab[i], transform.position, Quaternion.identity);
		Invoke ("SpawnPref",cd);

	}
	public void StopSpawning(){
		CancelInvoke ();
	}

	public void Restart(){
		Invoke ("SpawnPref",cd);
	}


}
