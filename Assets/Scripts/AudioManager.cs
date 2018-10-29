using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{

	public string name;
	public AudioClip clip;

	[Range(0f,1f)]
	public float volume = 0.7f;
	[Range(0.5f,1.5f)]
	public float pitch = 1f;

	AudioSource source;

	public void SetSource(AudioSource sourceIn){
		source = sourceIn;
		source.clip = clip;
	}

	public void Play(){
		source.volume = volume;
		source.pitch = pitch;
		source.Play ();
	}
}	

public class AudioManager : MonoBehaviour {

	[SerializeField]
	Sound[] sounds;

	public static AudioManager instance;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		for (int i = 0; i < sounds.Length; i++) {
			GameObject go = new GameObject ("Sound_"+i+"_"+sounds[i].name);
			go.transform.SetParent (this.transform);
			sounds[i].SetSource(go.AddComponent<AudioSource> ());
		}
	}
	
	public void PlaySound(string nameIn)
	{
		for (int i = 0; i < sounds.Length; i++) {
			if (sounds [i].name == nameIn) {
				sounds [i].Play ();
				return;
			}
		}

		Debug.LogError ("No sound named -"+nameIn+"- in sounds name");
	}

}
