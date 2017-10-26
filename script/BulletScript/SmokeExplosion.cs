using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeExplosion : MonoBehaviour 
{


	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	void OnDisable()
	{
		MonsterManager.MonsterGogo.Invoke (this.gameObject);
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
			MonsterManager.MonsterStop.Invoke (other.gameObject);
		}

	}
}
