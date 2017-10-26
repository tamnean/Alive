using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateIdle : StateMonster {



    public override void Init()
    {
        base.Init();
        MonsterManager.IdleEventEnter.AddListener(OnEnter);
        MonsterManager.IdleEventExit.AddListener(OnExit);


       
    }

    public override void OnEnter(Animator aim)
    {
        base.OnEnter(aim);
        if(isActiveAndEnabled)
        {
            Check();
        }

	}


    void Check ()
    {
        
        if(this.gameObject.name.StartsWith("Evil Mushroom"))
        {

            monsterModel.target = GameObject.FindGameObjectsWithTag("Player");

            GameObject near = FindNearest();
            monsterModel.myTarget = near ;

            OnStateChange("Idle","Move");
        }
        else if(this.gameObject.name.StartsWith("Forest Wolf"))
        {
			if (monsterModel.myTarget == null) 
			{
				GameObject[] target = GameObject.FindGameObjectsWithTag ("Player");
				foreach (GameObject player in target) 
				{
					if(player.name == "Player" || player.name == "Necro" || player.name == "Maiden")
						monsterModel.myTarget = player ;
				}

			}
            OnStateChange("Idle","Move");
        }
        else if(this.gameObject.name.StartsWith("TreantGuard"))
        {
            monsterModel.target = GameObject.FindGameObjectsWithTag("Player");

            GameObject near = FindNearest();
            monsterModel.myTarget = near;

            OnStateChange("Idle","Move");
        }
        else if(this.gameObject.name.StartsWith("Forest Golem"))
        {
            monsterModel.target = GameObject.FindGameObjectsWithTag("Player");

            GameObject near = FindNearest();
            monsterModel.myTarget = near;

            OnStateChange("Idle","Move");
        }
        else if(this.gameObject.name.StartsWith("Nymph Fairy"))
		{
			if (monsterModel.myTarget == null) 
			{
				GameObject[] target = GameObject.FindGameObjectsWithTag ("Player");
				foreach (GameObject player in target) 
				{
					if(player.name == "Player" || player.name == "Necro" || player.name == "Maiden")
						monsterModel.myTarget = player ;
				}

			}
			OnStateChange("Idle","Move");
		}
        else if(this.gameObject.name.StartsWith("Forest Bat"))
        {
            monsterModel.target = GameObject.FindGameObjectsWithTag("Player");

            GameObject near = FindNearest();
            monsterModel.myTarget = near;

            OnStateChange("Idle","Move");
        }
    }

    void Update ()
    {

    }

   
    GameObject FindNearest ()
    {
        float minValue = float.MaxValue;
        GameObject nearest = null;
        Vector3 p1 = transform.position;

        foreach (GameObject c in monsterModel.target)
        {
            Vector3 p2 = c.transform.position;
            float distance = Vector3.Distance(p1,p2);

            if (distance < minValue)
            {
                nearest = c;
                minValue = distance;
            }
        }

        return nearest;
    }
 
   
}
