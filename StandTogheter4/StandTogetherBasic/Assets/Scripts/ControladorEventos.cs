using UnityEngine;
using System.Collections;

public class ControladorEventos : MonoBehaviour {

	public bool eventoActivo;
	public float tiempoActivar;
	public float tiempoDesactivar;
	public int numeroCiudadanos;
	public bool TiemposAleatorios;
	public GameObject particulasNumeros;
	public Texture [] texturasNumeros = new Texture[10];
	public AudioClip aparece;
	public AudioClip finevento;

	// Use this for initialization
	void Start () {
		activarEvento ();
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!eventoActivo) {

			particulasNumeros.renderer.enabled=false;
		}
	}



	void desactivarEvento(){

		eventoActivo = false;


		particulasNumeros.renderer.enabled=false;

		if (TiemposAleatorios) {

			tiempoActivar = Random.Range (5, 21);

			Invoke ("activarEvento",tiempoActivar);

			return;
		 }

			Invoke ("activarEvento", tiempoActivar);
				
		  

		}

	void activarEvento(){
		audio.clip = aparece;
		eventoActivo = true;

		audio.Play();
		particulasNumeros.renderer.enabled=true;

		numeroCiudadanos = Random.Range(1, 11);

		int numeroArray = numeroCiudadanos;

		particulasNumeros.renderer.material.mainTexture=texturasNumeros[--numeroArray];

		if(TiemposAleatorios){

			tiempoDesactivar = Random.Range(5,21);

			Invoke("desactivarEvento",tiempoDesactivar);

			return;
		}

		Invoke ("desactivarEvento", tiempoDesactivar);

		}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player" && eventoActivo){

		int ciudadanosPlayer =	other.GetComponent<obtenerCiudadanos>().numeroCiudadanos;

			if(ciudadanosPlayer >= numeroCiudadanos){
				audio.clip = finevento;
				audio.Play();

				if(other.name=="Player1"){

					GameObject.FindGameObjectWithTag("score").SendMessage("actualizarPuntajeP1",numeroCiudadanos);
				
				}else{
					GameObject.FindGameObjectWithTag("score").SendMessage("actualizarPuntajeP2",numeroCiudadanos);

				}

				other.GetComponent<obtenerCiudadanos>().SendMessage("destruirCiudadanosRango",numeroCiudadanos);

				eventoActivo=false;

			}
		}
	}
}
