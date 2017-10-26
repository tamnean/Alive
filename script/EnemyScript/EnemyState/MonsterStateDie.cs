using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDie : StateMonster 
{
	bool down;
    public override void Init()
    {
        base.Init();
        MonsterManager.DieEventEnter.AddListener(OnEnter);
        MonsterManager.DieEventExit.AddListener(OnExit);
    }
		

    public override void OnEnter(Animator aim)
    {
        base.OnEnter(aim);
        if(isActiveAndEnabled)
        {
			if (!this.gameObject.name.StartsWith ("Forest Bat")) 
			{
				transform.GetComponent<Collider> ().enabled = false;
				StartCoroutine ("Die");
			}
				
			else 
			{
				down = false;
				Invoke ("Down", 0.5f);
				Invoke ("Bombaya",2);
			}
				
        }
    }

	IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        EventManager.PositiveGold.Invoke(monsterModel.Myloot);
        PoolManager.ReleaseObject(this.gameObject);
    }

	void Update()
	{
		if (this.gameObject.name.StartsWith ("Forest Bat")&& !down)
			this.gameObject.GetComponent<Rigidbody> ().AddForce ( (transform.forward*5 + transform.up*1.5f)*10);
		else if( this.gameObject.name.StartsWith ("Forest Bat")&& down )
			this.gameObject.GetComponent<Rigidbody> ().AddForce ( (transform.forward*8 + -transform.up*1.2f)*10);
	}



	void Down()
	{
		down = true;
	}

	void Bombaya()
	{
		if (down) 
		{
			down = false;
			EventManager.PositiveGold.Invoke(monsterModel.Myloot);
			PoolManager.ReleaseObject(this.gameObject);
			MonsterManager.MonsterDie.Invoke (this.gameObject);
		}

	}
}
