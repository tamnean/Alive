using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IdleState : State
{	
	float time=0;
	public override void init ()
	{
		base.init ();
		TowerStateManager.IdleEventEnter.AddListener (onEnter);
		TowerStateManager.IdleEventExit.AddListener (onExit);


	}

	void Update()
	{
		time += Time.deltaTime;
		if(towerModel.TargetTriggers.Count >= 1 && time >= towerModel.FireRateDeley)
		{
			onStateChanged ("Idle", "Attack");
			time=0;
		}

	}
		



				
}
		