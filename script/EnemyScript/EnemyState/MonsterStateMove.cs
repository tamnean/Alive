using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMove : StateMonster 
{
	

    public override void Init()
    {
        base.Init();
        MonsterManager.MoveEventEnter.AddListener(OnEnter);
        MonsterManager.MoveEventExit.AddListener(OnExit);
    }

    void Update ()
    {
        Seek();

    }



    void Seek()
    {
        if (monsterModel.myTarget == null)
        {
            OnStateChange("Move","Idle");
        }
        Vector3 targetPosition = monsterModel.myTarget.transform.position;
		Vector3 displacement = targetPosition - transform.position;
		Vector3 direction = Vector3.Scale(displacement.normalized, new Vector3(1,0,1)) ;
		Vector3 velocity =direction * monsterModel.MyMoveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(targetPosition,transform.position);

        if(distance >= monsterModel.radias)
        {
            transform.position = transform.position + velocity ;
        }

        transform.rotation = Quaternion.LookRotation(direction);

        if (distance <= monsterModel.MyRange)
        {
            OnStateChange("Move","Attack");
        }
       
    }


}
