using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;

	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	void Start(){

	}

	void OnMouseEnter(){

		guiTexture.texture = rollOverTexture;
	}

	void OnMouseExit(){

		guiTexture.texture=normalTexture;
	}

	IEnumerator OnMouseUp(){

		audio.PlayOneShot (beep);

		yield return new WaitForSeconds (0.35f);

		Application.LoadLevel (levelToLoad);

	}
}
