using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateWarcry : StateMonster {

    public override void Init()
    {
        base.Init();
        MonsterManager.WarcryEventEnter.AddListener(OnEnter);
        MonsterManager.WarcryEventExit.AddListener(OnExit);
    }

    public override void OnEnter(Animator aim)
    {
        base.OnEnter(aim);


        if (isActiveAndEnabled)
        {
            Warcry();
        }

    }

    void Warcry ()
    {
        MonsterManager.WarcryMonster.Invoke(monsterModel.myTarget,transform);
    }

    void Update()
    {
        
    }
}
