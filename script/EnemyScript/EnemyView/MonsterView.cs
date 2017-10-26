using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterView : MonoBehaviour {

    private MonsterModel monsterModel;
    private Animator anim;
	float moveSpeed;

    void Awake()
    {
        monsterModel = gameObject.GetComponent<MonsterModel>();
        anim = gameObject.GetComponent<Animator>();

        MonsterManager.WarcryMonster.AddListener(WarcryMonster);
        MonsterManager.TakeDamge.AddListener(ChangeHp);

		MonsterManager.MonsterStop.AddListener (MonsterStop);
		MonsterManager.MonsterGogo.AddListener (MonsterGoGo);
		moveSpeed = monsterModel.MyMoveSpeed;


    }

    void OnEnable()
    {
		transform.GetComponent<Collider> ().enabled = true;
        monsterModel.MyDamge = monsterModel.MyDamge + Time.time * 0.09f;
        monsterModel.MyHp = monsterModel.MyHp + Time.time * 0.09f;

    }

    void Update ()
    {
  

    }
      

	void MonsterStop(GameObject monster)
	{
		if (monster == this.gameObject) 
		{
			monsterModel.MyMoveSpeed = 0;
			Invoke ("MonsterGoGo", 2);
		}

	}

	void MonsterGoGo(GameObject freeze)
	{
		if (freeze == null || !freeze.activeInHierarchy) 
		{
			monsterModel.MyMoveSpeed = moveSpeed;
		}
	}

    void WarcryMonster(GameObject m,Transform t)
    {
        float distance = Vector3.Distance(t.position,transform.position);
        if(distance <= 50)
        {
            monsterModel.myTarget = m;
        }
    }

    void ChangeHp(GameObject m,float h)
    {
        if (this.gameObject == m)
        {
            monsterModel.MyHp -= h;
            if(monsterModel.MyHp <= 0)
            {
                anim.SetTrigger("Die");

            } 

            if (this.gameObject.name == "Forest Wolf")
            {
                if(monsterModel.MyHp <= 30)
                {
                    if (Time.time > monsterModel.nextUse)
                    {
                        monsterModel.nextUse = Time.time + monsterModel.useRate;
                        anim.SetTrigger("Flee");
                    }
                }
            }
            else if(this.gameObject.name == "Forest Golem")
            {
                if(monsterModel.MyHp <= 40)
                {
                    if (Time.time > monsterModel.nextUse)
                    {
                        monsterModel.nextUse = Time.time + monsterModel.useRate;
                        anim.SetTrigger("Warcry");
                    }
                }
            }
            else if(this.gameObject.name == "Nymph Fairy")
            {
                if(monsterModel.MyHp <= 80)
                {
                    if (Time.time > monsterModel.nextUse)
                    {
                        monsterModel.nextUse = Time.time + monsterModel.useRate;
                        anim.SetTrigger("Flee");
                    }
                }
            }

        }
    }

//	void OnDrawGizmosSelected()
//	{
//		Gizmos.DrawWireSphere (transform.position, 5);
//	}
}
