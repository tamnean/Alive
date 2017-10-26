using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class TowerView : MonoBehaviour 
{
	private TowerModel towerModel;
	Animator anim;


	void OnEnable()
	{
		towerModel = GetComponent<TowerModel>();
		anim = gameObject.GetComponent<Animator> ();
        MonsterManager.TakeDamge.AddListener(TakeDamage);
	}


	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Monster"  && !towerModel.TargetTriggers.Contains(other.gameObject) )
		{
			towerModel.TargetTriggers.Add(other.gameObject);
		}

	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Monster" && towerModel.TargetTriggers.Contains(other.gameObject))
		{
			towerModel.TargetTriggers.Remove(other.gameObject);
		}
			
	}

    void TakeDamage(GameObject g, float i)
    {
        if(this.gameObject == g)
        {
            towerModel.CurrentHp -= i;
        }
		if (towerModel.CurrentHp <= 0)
		{
			anim.SetTrigger ("Die");
			gameObject.GetComponent<Collider> ().enabled = false;
		}	

		if (towerModel.CurrentHp > towerModel.MaxHp)
			towerModel.CurrentHp = towerModel.MaxHp;
    }

    void OnDisable ()
    {
        MonsterManager.TakeDamge.RemoveListener(TakeDamage);
    }
		
		
}
