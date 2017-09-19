using UnityEngine;
using System.Collections;
using RAIN.Core;
public class SeguirPlayer : MonoBehaviour {

	private AIRig aiRig = null;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		aiRig = gameObject.GetComponentInChildren<AIRig>();
	// Use this for initialization

	
	}
	

 public void seguir(){
	
		aiRig.AI.WorkingMemory.SetItem("sigoAalguien",true);
		aiRig.AI.WorkingMemory.SetItem("seguir",true);
		aiRig.AI.WorkingMemory.SetItem("varPlayer",player);
	}
}
