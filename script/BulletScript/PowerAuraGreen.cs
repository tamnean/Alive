using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAuraGreen : MonoBehaviour 
{

	TowerModel tm;
	bool trigger;

	void Awake()
	{
		tm = GetComponentInParent<TowerModel>();
	}
		
	void OnEnable()
	{
		trigger = false;
		//tm.CurrentHp = Mathf.Clamp( tm.CurrentHp+tm.BulletDamage ,0,tm.MaxHp);
	}


	void OnTriggerStay(Collider other)
	{
		if (!trigger && other.gameObject.tag == "Player" )
		{
			trigger = true;
//			foreach(GameObject target in tm.TargetTriggers)
//			{
//				TowerModel tower = target.GetComponent<TowerModel>();
//				tower.CurrentHp = tower.CurrentHp+ tm.BulletDamage;
//			}
			MonsterManager.TakeDamge.Invoke(other.gameObject, -tm.BulletDamage);
			tm.CurrentHp += tm.BulletDamage;
			Invoke ("FuckOff", 2);

		}
	}

	void FuckOff()
	{
		gameObject.SetActive (false);
	}
}
