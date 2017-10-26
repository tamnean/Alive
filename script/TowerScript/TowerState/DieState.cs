using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[System.Serializable]
public class DieState : State
{
	
	public override void init ()
	{
		base.init ();
		TowerStateManager.DieEventEnter.AddListener (onEnter);
		TowerStateManager.DieEventExit.AddListener (onExit);
	}

	void OnEnable()
	{
        if(isActiveAndEnabled)
        {
            StartCoroutine("Die");
        }

	}
		
    IEnumerator Die ()
    {
        yield return new WaitForSeconds(1.5f);
        PoolManager.ReleaseObject(this.gameObject);
    }

	void OnDisable()
	{
		onStateChanged ("Die", "Idle");
	}


}
