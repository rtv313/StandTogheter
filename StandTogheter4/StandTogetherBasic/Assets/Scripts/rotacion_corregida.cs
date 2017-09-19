using UnityEngine;
using System.Collections;

public class rotacion_corregida : MonoBehaviour {

	public GameObject padre;
	//private Vector3 rotacion_padre;
	//private Vector3 rotacion_hijo;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		/* work for nothing
		rotacion_padre = padre.transform.eulerAngles;
		rotacion_padre.y*=-1;
		rotacion_hijo = rotacion_padre;
		*/
		transform.eulerAngles = new Vector3(0.0f,0.0f,0.0f);
	}
}
