using UnityEngine;
using System.Collections;

public class informarRespawn : MonoBehaviour {

	public GameObject spawn;


	void llamarSpawn(){

	   if (spawn.name == "SpawnPowerUps") {

		  spawn.GetComponent<crearPowerUps> ().crear = true;
				
		  } else {

			spawn.GetComponent<crearCiudadanos>().crear = true;
		}
				
	}

}
