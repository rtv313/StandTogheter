using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;

public class obtenerCiudadanos : MonoBehaviour {
	
	private double distanciaSeparacion=3;
	public string player;
	public  List <GameObject> ciudadanos ;
	public int numeroCiudadanos;
	public bool invulnerable;
	public bool velocidadActivada;
	
	// Use this for initialization
	void Start () {
		
		invulnerable = false;
		velocidadActivada = false;
		numeroCiudadanos = 0;
		ciudadanos = new List<GameObject>();
	}
	
	
	
	void agregarCiudadano(Collider other){
		
		if(numeroCiudadanos < 10){
			if (other.gameObject.GetComponentInChildren<AIRig> ().AI.WorkingMemory.GetItem<bool> ("seguir")) {
				
				//other.gameObject.GetComponentInChildren<AIRig> ().AI.WorkingMemory.SetItem (player, true);
				
				other.gameObject.GetComponentInChildren<AIRig> ().AI.WorkingMemory.SetItem ("seguir", false);
				
				other.gameObject.GetComponentInChildren<AIRig> ().AI.WorkingMemory.SetItem ("distanciaPlayer", distanciaSeparacion);
				
				
				//distanciaSeparacion += 1.5;
				
				if (numeroCiudadanos > 0) {
					int posicion = numeroCiudadanos -1;
					other.gameObject.GetComponentInChildren<AIRig> ().AI.WorkingMemory.SetItem ("varPlayer", ciudadanos[posicion]);
					
				}else{
					other.gameObject.GetComponentInChildren<AIRig> ().AI.WorkingMemory.SetItem ("varPlayer", transform.gameObject);
				}

				ciudadanos.Add (other.gameObject);

				if(other.gameObject.GetComponent<informarRespawn>().spawn.name=="SpawnCiudadanos"){

					other.gameObject.GetComponent<informarRespawn>().spawn.GetComponent<ParticleSystem>().enableEmission =false;
				}
				other.gameObject.GetComponent<informarRespawn>().SendMessage("llamarSpawn"); //aqui llamo al spawn de pups

				numeroCiudadanos++;

				audio.Play();
			}
			
		}
		
	}
	
	
	
	
	void OnTriggerStay(Collider other){
		
		if (player == "asignarPlayer1") {
			
			if (other.gameObject.tag == "Ciudadano" && Input.GetKeyDown (KeyCode.LeftControl)) {
				
				agregarCiudadano(other);
				
					
				other.GetComponent<SphereCollider>().enabled=false;
				
				cambiarVelocidadCiudadanos(35);
				
			}
			
		} else {
			
			if(other.gameObject.tag == "Ciudadano" && Input.GetKeyDown (KeyCode.RightControl)) {
				
				agregarCiudadano(other);
				
			
				other.GetComponent<SphereCollider>().enabled=false;
				
				cambiarVelocidadCiudadanos(35);
			}
			
		}
		
		//Debug.Log ("contador" + numeroCiudadanos);
	}
	
	
	
	void destruirCiudadanos(){
		
		if (!invulnerable) {
			
			ciudadanos.ForEach (delegate(GameObject ciudadano) {
				
				Destroy (ciudadano);});
			
			ciudadanos.RemoveRange(0,ciudadanos.Count);
			
			numeroCiudadanos = 0;
		}
	}
	
	void destruirCiudadanosRango(int numeroCiudadanos){
		
		int contador = ciudadanos.Count;
		
		contador--;
		
		
		
		//if (!invulnerable) {
			
			for(int x =0 ;x<numeroCiudadanos;x++){
				
				Destroy(ciudadanos[contador]);
				
				ciudadanos.RemoveAt(contador);
			 
		    	this.numeroCiudadanos--;     

				contador--;
		//	}
			

		//	Debug.Log("NumeroCiudadanosRango"+numeroCiudadanos);
			
		//	this.numeroCiudadanos -= numeroCiudadanos;
			
		}
	}
	
	
	
	void cambiarVelocidadCiudadanos(double velocidad){
		
		
		
		if(ciudadanos.Count > 0 && velocidadActivada){
			
			Debug.Log (velocidad);
			
			ciudadanos.ForEach (delegate(GameObject ciudadano) {
				
				ciudadano.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem("Velocidad",velocidad);
				
				;});
		}
	}
}
