using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerIdleState : State
{

	float time=0;
	public override void init ()
	{
		base.init ();
		TowerStateManager.IdleEventEnter.AddListener (onEnter);
		TowerStateManager.IdleEventExit.AddListener (onExit);
	}

	void OnEnable()
	{
		
	}

	void Update()
	{
		time += Time.deltaTime;

		if(time >= towerModel.FireRateDeley)
		{
			
				onStateChanged ("Idle", "Attack");
				time =0;
				
//			foreach(GameObject target in towerModel.TargetTriggers )
//			{
//				TowerModel tower = target.GetComponent<TowerModel>();
//
//				if(tower.CurrentHp < tower.MaxHp)
//				{
//					onStateChanged ("Idle", "Attack");
//					time =0;
//				}
//				if(!target.activeInHierarchy ||  tower.CurrentHp <=0)
//				{
//					towerModel.CurrentTarget = null;
//					towerModel.TargetTriggers.Remove(target);
//					break;
//				}
//			}
		}
			
	}


}
