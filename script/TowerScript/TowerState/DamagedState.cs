using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : State 
{
	bool isDamage = false;
	public override void init()
	{
		base.init();
		//TowerStateManager.DamagedEventEnter.AddListener (onEnter);
		//TowerStateManager.DamagedEventExit.AddListener (onExit);
	}

	void Update()
	{
		onDamaged();
	}

	void OnEnable()
	{
		isDamage = false;
	}

	void onDamaged()
	{
		if(!isDamage)
		{
			towerModel.MaxHp -= 10;
			Debug.Log("hp-10");
			isDamage = true;
		}
		else
			onStateChanged("Damaged","Idle");
		
		if(towerModel.MaxHp <=0)
		{	towerModel.MaxHp =0;
			towerModel.MaxHp+=100;
			Debug.Log("hp+100");
		}
	}
}
