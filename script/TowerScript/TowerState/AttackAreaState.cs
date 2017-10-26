using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[System.Serializable]
public class AttackAreaState : State
{
	public override void init ()
	{
		base.init ();
		TowerStateManager.AttackEventEnter.AddListener (onEnter);
		TowerStateManager.AttackEventExit.AddListener (onExit);
	}

	void OnEnable ()
	{
		UpdateTarget ();
	}



	void UpdateTarget ()
	{
		float nearDistance = Mathf.Infinity;
		foreach (GameObject target in towerModel.TargetTriggers) 
		{		
			float distance = Vector3.Magnitude (target.transform.position - transform.position);
			if (distance <= nearDistance) 
			{
				nearDistance = distance;
				towerModel.CurrentTarget = target;
			}

			if(!target.activeInHierarchy || target == null)
			{
				towerModel.TargetTriggers.Remove(target);
				UpdateTarget();
				break;
			}
		}

		Shoot ();
	}

	void Update ()
	{
		if (towerModel.CurrentTarget != null) 
		{
			Vector3 distanceToEnemy = towerModel.CurrentTarget.transform.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation (distanceToEnemy);
			Vector3 rotation = Quaternion.Lerp (transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
			transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);
		} 
		else
			UpdateTarget ();
		
	}

	void Shoot ()
	{
		towerModel.Bullet.SetActive (true);
		onStateChanged ("Attack", "Idle");
	}
}