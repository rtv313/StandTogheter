using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Memory;


[RAINAction]
public class ObtenerRed : RAINAction
{  



    public ObtenerRed()
    {
        actionName = "ObtenerRed";
    }

    public override void Start(AI ai)
    {

        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {  
		Debug.Log("ObtenerRed");

	Vector3 posicion =	ai.WorkingMemory.GetItem<Vector3>("varPlayer");

		Debug.Log("ObtenerRed2");
		
		//GameObject.FindGameObjectWithTag("Player").GetComponent<detectarNetwork>().network;
	GameObject player1 = GameObject.FindGameObjectWithTag("Player");

		GameObject red;
		Debug.Log("ObtenerRed3");
		if (posicion == player1.transform.position) {

			Debug.Log("Buscar Red1");
			 red =GameObject.FindGameObjectWithTag("Player").GetComponent<detectarNetwork>().network;
			ai.WorkingMemory.SetItem("searchPat",red);
			return ActionResult.SUCCESS;	
		}

		GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
		Debug.Log("ObtenerRed4");
		if (posicion == player2.transform.position) {
			Debug.Log("Buscar Red2");
			 red =GameObject.FindGameObjectWithTag("Player2").GetComponent<detectarNetwork>().network;
			ai.WorkingMemory.SetItem("searchPat",red);
			return ActionResult.SUCCESS;	
		}

						return ActionResult.SUCCESS;
				
				
	


    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}