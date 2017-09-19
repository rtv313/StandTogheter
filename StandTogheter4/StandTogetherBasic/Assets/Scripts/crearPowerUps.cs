using UnityEngine;
using System.Collections;

public class crearPowerUps : MonoBehaviour {
	
	public bool crear= false;
	
	public GameObject p_up1;// invulnerabilidad
	public GameObject p_up2;// velocidad
	public GameObject p_up3;// ciudadano
	
	
	
	
	// Use this for initialization
	void Start () {
		
		llamarCrear ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (crear) {
			
			llamarCrear();

		
		}
		
	}
	
	void CrearPowerUp(){
		
		int selectorRandom = Random.Range (1, 4);
		
		switch (selectorRandom) {
			
		case 1:
			
			GameObject invulnerabilidad =(GameObject)Instantiate (p_up1,transform.position,Quaternion.identity);
			invulnerabilidad.GetComponent<informarRespawn>().spawn =transform.gameObject;
			break;
			
		case 2:
			
			GameObject velocidad =(GameObject) Instantiate (p_up2,transform.position,Quaternion.identity);
			velocidad.GetComponent<informarRespawn>().spawn =transform.gameObject;
			
			break;
			
		case 3:
			
			GameObject ciudadano =	(GameObject)Instantiate (p_up3,transform.position,Quaternion.identity);
			ciudadano.GetComponent<informarRespawn>().spawn=transform.gameObject;
			
			break;
			
		}
		
		
		crear = false;
		

		
	}//CrearPowerUp
	
	
	
	void llamarCrear(){
		
		Invoke("CrearPowerUp",2);
		
		crear = false;
	}
	
	
	
	
	
}
