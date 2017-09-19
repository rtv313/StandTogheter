using UnityEngine;
using System.Collections;
using RAIN.Core;
public class detectarPlayer : MonoBehaviour {


	public AudioClip visto;

	void OnTriggerEnter(Collider other) {
				//Debug.Log("NOMBRE NETWORK "+other.gameObject.name);
	 if (other.gameObject.tag == "Player") {
		audio.Play();
			
	  	gameObject.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem("searchPath",other.gameObject.GetComponent<detectarNetwork>().network);
	  	gameObject.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem("Player",other.gameObject);
			
	   }//Network
	}

	void OnTriggerStay(Collider other){
		
		if (other.gameObject.tag == "Player") {


			
			gameObject.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem("searchPath",other.gameObject.GetComponent<detectarNetwork>().network);
			gameObject.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem("Player",other.gameObject);
		}//Network
		
	}


}
