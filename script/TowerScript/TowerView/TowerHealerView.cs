using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealerView : MonoBehaviour {

	private TowerModel towerModel;
	Animator anim;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();
		MonsterManager.TakeDamge.AddListener(TakeDamage);
		//EventManager.onHitTriggerEvents.AddListener(OnAddToList);
		//EventManager.onExitTriggerEvents.AddListener(OnRemoveFromList);
	}

	void OnEnable()
	{
        towerModel = GetComponent<TowerModel>();
      
	}

//
//	void OnTriggerEnter(Collider other)
//	{
//		if(other.gameObject.tag == "Player" && !towerModel.TargetTriggers.Contains(other.gameObject) )
//		{
//			EventManager.onHitTriggerEvents.Invoke(other);
//		}
//	}
//
//	void OnTriggerExit(Collider other)
//	{
//		if(other.gameObject.tag == "Player" && towerModel.TargetTriggers.Contains(other.gameObject) )
//		{
//			EventManager.onExitTriggerEvents.Invoke(other);
//		}
//
//	}
//
//	void OnAddToList(Collider other)
//	{
//		towerModel.TargetTriggers.Add(other.gameObject);
//	}
//
//	void OnRemoveFromList(Collider other)
//	{
//		towerModel.TargetTriggers.Remove(other.gameObject);
//	}
//
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
        //MonsterManager.TakeDamge.RemoveListener(TakeDamage);
    }

//	void OnDrawGizmos()
//	{
//		Gizmos.DrawWireSphere(transform.position+Vector3.up, 100);
//	}
}
