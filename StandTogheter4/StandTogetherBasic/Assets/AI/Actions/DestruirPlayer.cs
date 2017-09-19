using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

[RAINAction]
public class DestruirPlayer : RAINAction
{  


    public DestruirPlayer()
    {
        actionName = "DestruirPlayer";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {   
	GameObject player =	ai.WorkingMemory.GetItem<GameObject>("Player");
	
		if(!player.GetComponent<obtenerCiudadanos>().invulnerable){

			obtenerCiudadanos destruir = player.GetComponent<obtenerCiudadanos>();

			destruir.SendMessage("destruirCiudadanos");

			if(player.transform.gameObject.name=="Player1"){

				player.transform.position = new Vector3 (27,3,-32);

			}else{

				player.transform.position = new Vector3 (-51,3,-33);
			}

			ai.WorkingMemory.SetItem ("isSearching", false);
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}