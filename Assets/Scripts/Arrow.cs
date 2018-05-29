using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

	[SerializeField]
	Sprite imageNormal;
	[SerializeField]
	Sprite imageOnMouse;

	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MouseEnter(){
		image.sprite = imageOnMouse;
	}

	public void MouseExit(){
		image.sprite = imageNormal;
	}
}
