using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWall : MonoBehaviour 
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
		if(other.gameObject.tag == "Monster" )
		{
			MonsterManager.TakeDamge.Invoke (other.gameObject, tm.BulletDamage);
		}

	}


}
