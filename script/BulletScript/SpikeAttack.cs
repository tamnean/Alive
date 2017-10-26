using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour 
{
	TowerModel tm;

	void Awake()
	{
		tm = GetComponentInParent<TowerModel>();
	}

	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	IEnumerator CheckIfAlive ()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f);
			if(!GetComponent<ParticleSystem>().IsAlive(true))
			{
				gameObject.SetActive (false);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Monster")
		{
			MonsterManager.TakeDamge.Invoke (other.gameObject, tm.BulletDamage);
//			EnemyModel enemy = other.gameObject.GetComponent<EnemyModel>();
//			enemy.hp = Mathf.Clamp( enemy.hp - tm.BulletDamage, 0, enemy.maxHp);
		}
	
	}
		
}
