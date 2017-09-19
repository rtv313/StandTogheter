using UnityEngine;
using System.Collections;

public class crearCiudadanos : MonoBehaviour {

	public bool crear= false;
	public GameObject ciudadanoPrefab; //ciudadano
	public float tiempoCreacion =5;

 // Use this for initialization
	void Start () {
		
		CrearCiudadano();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (crear) {
			
			llamarCrear();
			
		}


	}
	
	void CrearCiudadano(){

		GameObject ciudadano =	(GameObject)Instantiate (ciudadanoPrefab,transform.position,Quaternion.identity);
		ciudadano.GetComponent<informarRespawn>().spawn=transform.gameObject;
		transform.GetComponent<ParticleSystem>().enableEmission =true;
			
		}
		
	void llamarCrear(){

		Invoke("CrearCiudadano",tiempoCreacion);
		
		crear = false;
	}
	
	
	

}
