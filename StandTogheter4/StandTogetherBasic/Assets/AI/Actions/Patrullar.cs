using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Navigation;
using RAIN.Navigation.Graph;

[RAINAction]
public class Patrullar : RAINAction
{
	public static float _time= 0f;
	public Patrullar()
	{
		actionName = "Patrullar";
	}
	
	public override void Start(AI ai)
	{
		base.Start(ai);

		
		
	}
	
	public override ActionResult Execute(AI ai)
	{
		Vector3 loc = Vector3.zero;
		List<RAINNavigationGraph> found = new List<RAINNavigationGraph> ();
		
		do{
			loc = new Vector3(ai.Kinematic.Position.x + Random.Range(-20f,20f),
			                  ai.Kinematic.Position.y,
			                  ai.Kinematic.Position.z + Random.Range(-20f,20f));
			
			found= NavigationManager.Instance.GraphsForPoints(ai.Kinematic.Position,
			                                                  loc,
			                                                  ai.Motor.StepUpHeight
			                                                  ,NavigationManager.GraphType.Navmesh,
			                                                  ((BasicNavigator)ai.Navigator).GraphTags);
			
		} while((Vector3.Distance(ai.Kinematic.Position,loc) <2f)||(found.Count==0));
		
		ai.WorkingMemory.SetItem<Vector3>("varMoveTo",loc);
		

		
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(AI ai)
	{
		base.Stop(ai);
	}
}