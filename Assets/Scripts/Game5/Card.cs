using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Sprite image;
	public int id;

	float timeWait = 0.8f;
	Image imageRenderer;

	// Use this for initialization
	void Start () {
		imageRenderer = GetComponent<Image> ();
		if (imageRenderer == null)
			Debug.LogError ("Image not founded!");
		imageRenderer.sprite = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Button_Activate_Image(){
		if (LevelManagerExpLab.instance.canClick == false)
			return;
		
		imageRenderer.sprite = image;
		LevelManagerExpLab.instance.canClick = false;
		LevelManagerExpLab.instance.clickCounter++;
		if (LevelManagerExpLab.instance.clickCounter % 2 == 0)
			Invoke ("GrantInfoLevelManager", timeWait);
		else
			GrantInfoLevelManager ();

	}

	public void DeactivateImage(){
		imageRenderer.sprite = null;
	}

	void GrantInfoLevelManager(){
		LevelManagerExpLab.instance.CardClicked (this.gameObject,id);
	}
}
