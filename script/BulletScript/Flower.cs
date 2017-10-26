using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {


	bool trigger;
	TowerModel tm;
	GameObject sameTarget;

	void OnEnable()
	{
		trigger = false;
		tm = GetComponentInParent<TowerModel>();
		sameTarget = tm.CurrentTarget;
	}
		


	void Update()
	{
		if (sameTarget.GetComponent<Collider>().enabled == true && sameTarget != null)
		{
			Vector3 velocity = ((tm.CurrentTarget.transform.position - gameObject.transform.position).normalized) * Time.deltaTime * 10;
			transform.position += velocity;
		}
		else
		{
			this.gameObject.SetActive (false);
			transform.position = tm.transform.position + new Vector3(0,2,0);
		}

	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Monster" && !trigger) 
		{
			trigger = true;
			MonsterManager.TakeDamge.Invoke (other.gameObject, tm.BulletDamage);
			this.gameObject.SetActive (false);
			transform.position = tm.transform.position + new Vector3 (0, 2, 0);
		}
		else if (other.gameObject.tag == "Ground") 
		{
			this.gameObject.SetActive (false);
			transform.position = tm.transform.position + new Vector3 (0, 2, 0);
		}

	}
		
}


 