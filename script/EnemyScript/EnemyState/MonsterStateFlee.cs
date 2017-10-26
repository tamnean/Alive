using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateFlee : StateMonster {

    public override void Init()
    {
        base.Init();
        MonsterManager.FleeEventEnter.AddListener(OnEnter);
        MonsterManager.FleeEventExit.AddListener(OnExit);


    }
        


    void Update()
    {
        Flee();

		if(monsterModel.MyHp <= 0)
		{
			myColl.enabled = false;
			OnStateChange("Flee","Die");
		} 
    }


    void Flee ()
    {
        if(monsterModel.myTarget == null)
        {
           OnStateChange("Flee","Move");
        }

		Vector3 displacement = monsterModel.myTarget.transform.position - monsterModel.transform.position;
        Vector3 direction = displacement.normalized;
        Vector3 velocity = direction * monsterModel.MyMoveSpeed * Time.deltaTime;

		float distance = Vector3.Distance(monsterModel.myTarget.transform.position,monsterModel.transform.position);

		transform.position = transform.position -velocity;
        transform.rotation = Quaternion.LookRotation(-direction);

        if(distance >= 5)
        {
            OnStateChange("Flee","Move");
        }

    }
        
}
