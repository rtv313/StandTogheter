using UnityEngine;
using System.Collections;
//using RAIN.Core;

public class detectarNetwork : MonoBehaviour {

	public GameObject network;
//	public string player;
//	private double distanciaSeparacion=1.5;



	void OnTriggerEnter(Collider other) {
		//Debug.Log("NOMBRE NETWORK "+other.gameObject.name);
		if (other.gameObject.tag == "Network") {

			network=other.gameObject;

			Debug.Log("NOMBRE NETWORK"+other.gameObject.name);

				}//Network
//
	}




}
