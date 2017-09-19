using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {


	double tiempo=0;
	public TextMesh minutosMesh;
	public TextMesh segundosMesh;
	public double minutos;
	public double segundos = 60;
	double countdown;
	public double minutosmostrados;

	public AudioClip musicalevel;
	public AudioClip gameover;

	public bool ya;

	public GameObject puntuaciones;



	int contador;

	// Use this for initialization
	void Start () {
		countdown = minutos * 60;
		//countdown += 60;

		minutosMesh.text=minutosmostrados.ToString();
		audio.clip = musicalevel;
		audio.Play();

		ya = false;
	}
	
	// Update is called once per frame
	void Update () {

		llamarTime();

		if ( ya == true)
		{
			contador++;
		}

		if (contador > 100){
			win ();
		}

	}

	void llamarTime(){

		tiempo+= Time.deltaTime;
		//countdown -= Time.deltaTime;

		segundosMesh.text=((int)(segundos - tiempo)).ToString();

		if(tiempo > 60){

			tiempo = 0;

			minutos--;
			minutosmostrados --;

			minutosMesh.text = minutosmostrados.ToString();
		}

	

		if (minutos <= 0 ){

			minutos = 0;
			Time.timeScale = 0;
			segundosMesh.text = "0";
			minutosMesh.text = "0";
			if (ya == false){
				ya= true;
				gameoverplay();
			}

		}
	}

	void gameoverplay(){
		audio.clip = gameover;
		audio.Play();
		Invoke("win", 2.3f);
	}

	void win(){
		Debug.Log("carajo");

		int p1= puntuaciones.GetComponent<Score>().p1_score;
		int p2 =  puntuaciones.GetComponent<Score>().p2_score;

		if(p1 > p2){

			Debug.Log("Gano p1");
		
			Application.LoadLevel("p1_winner");

		}else if(p1 < p2){
			
			Debug.Log("Gano p2");
			Application.LoadLevel("p2_winner");
		} else if (p1 == p2){
			Application.LoadLevel("draw");
		}
	}

}
