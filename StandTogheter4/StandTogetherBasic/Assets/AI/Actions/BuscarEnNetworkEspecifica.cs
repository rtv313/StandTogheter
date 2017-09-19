using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Navigation.Waypoints;

[RAINAction]
public class BuscarEnNetworkEspecifica : RAINAction
{
	public static float _time = 0f;
	private Waypoint[] ArrayListWaypoints ;
    public BuscarEnNetworkEspecifica()
    {
        actionName = "BuscarEnNetworkEspecifica";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
		_time += Time.time;
    }

    public override ActionResult Execute(AI ai)
    {
		Vector3 loc = Vector3.zero;

		GameObject red = ai.WorkingMemory.GetItem<GameObject>("searchPath");

		int numeroNodos = red.GetComponent<WaypointRig>().WaypointSet.Waypoints.Count;

		ArrayListWaypoints = new Waypoint[numeroNodos];

		red.GetComponent<WaypointRig>().WaypointSet.Waypoints.CopyTo(ArrayListWaypoints,0);

		Waypoint punto = ArrayListWaypoints [Random.Range(0,numeroNodos)];

		loc = punto.position;
			
		ai.WorkingMemory.SetItem<Vector3>("varMoveToSearch",loc);
		
		if (_time > 150f) {
			
			ai.WorkingMemory.SetItem("isSearching",false);
			_time=0;
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}