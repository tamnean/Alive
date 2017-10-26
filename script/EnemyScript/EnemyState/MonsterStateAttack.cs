using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack : StateMonster 
{
	bool trigger;
    public override void Init()
    {
        base.Init();

        MonsterManager.AttackEventEnter.AddListener(OnEnter);
        MonsterManager.AttackEventExit.AddListener(OnExit);

    }

    public override void OnEnter(Animator aim)
    {
        base.OnEnter(aim);

        if (isActiveAndEnabled)
        {
            StartCoroutine("Attack");
        }
    }
        
	void OnEnable()
	{
		trigger = false;
	}

    IEnumerator Attack()
    {
		if(!this.gameObject.name.StartsWith("Nymph"))
			yield return new WaitForSeconds(monsterModel.MyAtkSpeed);


		if(this.gameObject.name.StartsWith("TreantGuard"))
        {
            monsterModel.MyHp += monsterModel.MyDamge*0.3f;
			MonsterManager.TakeDamge.Invoke(monsterModel.myTarget,monsterModel.MyDamge);
			OnStateChange("Attack","Idle");

        }
		else if(this.gameObject.name.StartsWith( "Forest Golem"))
        {
            foreach (GameObject m in monsterModel.target)
            {
                float distance = Vector3.Distance(m.transform.position,transform.position);
                if (distance <= 5)
                {
                    MonsterManager.TakeDamge.Invoke(m,monsterModel.MyDamge);
                }
            }
			transform.FindChild ("GolemRock").gameObject.SetActive (true);
        }

		else if (this.gameObject.name.StartsWith(  "Nymph Fairy"))
        {
            //MonsterManager.FairyFire.Invoke(this.gameObject,monsterModel.myTarget);
			if(!trigger)
			{
				trigger = true;
				PoolManager.SpawnObject( gm.GetComponent<Game_Manager>().fairyBullet, this.transform.position+new Vector3(0,1.5f,0), Quaternion.identity).GetComponent<FairyBullet>().Aim(monsterModel.myTarget);
				Invoke ("Nymph", monsterModel.MyAtkSpeed);
			}


        }

		else if(this.gameObject.name.StartsWith(  "Forest Bat"))
        {
            foreach (GameObject m in monsterModel.target)
            {
                float distance = Vector3.Distance(m.transform.position,transform.position);
                if (distance <= 5)
                {
					OnStateChange("Attack","Die");
                }
            }
        }
			
		MonsterManager.TakeDamge.Invoke(monsterModel.myTarget,monsterModel.MyDamge);
		OnStateChange("Attack","Idle");
    }
		
	void Nymph()
	{
		OnStateChange("Attack","Move");
	}
}
