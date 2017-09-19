using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour 
{
    public GUISkin myskin;

    private Rect windowRect;
    private bool paused = false , waited = true;
	private int contador;

	public AudioClip click;

    private void Start()
    {
        windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 500);
		contador = 0;
    }

    private void waiting()
    {
        waited = true;
    }

    private void Update()
    {
		timestuff();
    }

	private void timestuff(){

		if (waited)
			if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
		{
			if (paused){
				paused = false;	

				Time.timeScale = 1f;

			}else{
				paused = true;
				Time.timeScale = 0.001f;
			}
			waited = false;
			//Invoke("waiting",0.001f);
			waiting();
		}
		
	}
	
	private void OnGUI()
	{
		if (paused){
			GUI.skin.window = myskin.window;
			windowRect = GUI.Window(0, windowRect, windowFunc, "");
		}

    }

    private void windowFunc(int id)
    {
		GUI.skin.button = myskin.button;

		//GUI.Button(new Rect(10, 70, 50, 30), "Resume"

		if (GUILayout.Button("Resume"))
		{
            paused = false;
			Time.timeScale = 1f;
			audio.Play();
        }
      
		//GUI.Button(new Rect(10, 120, 50, 30),"Quit")
		if (GUILayout.Button("Quit"))
        {
			audio.Play();
			Time.timeScale = 1;
			Application.LoadLevel("menu_principal");

        }
    }
}
