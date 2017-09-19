using UnityEngine;
using System.Collections;

public class destroy_p_up : MonoBehaviour {

	public float tiempo_de_vida;
	public int pos;

	// Use this for initialization
	void Start () {
		//Invoke ("destruccion", tiempo_de_vida);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void destruccion (){

		Destroy (gameObject);

	}
}
