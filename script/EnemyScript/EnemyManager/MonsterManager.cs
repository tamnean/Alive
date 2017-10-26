using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AnimatorControlEvent : UnityEvent<Animator> {}
public class TargetEvent : UnityEvent<GameObject>{}
public class TakeDamageEvent : UnityEvent<GameObject,float>{}
public class WarcryEvent : UnityEvent<GameObject,Transform>{}
public class MonsterEvent : UnityEvent<GameObject>{}


public class MonsterManager : MonoBehaviour {


    public static AnimatorControlEvent IdleEventEnter = new AnimatorControlEvent ();
    public static AnimatorControlEvent IdleEventExit = new AnimatorControlEvent ();
    public static AnimatorControlEvent MoveEventEnter = new AnimatorControlEvent ();
    public static AnimatorControlEvent MoveEventExit = new AnimatorControlEvent ();
    public static AnimatorControlEvent AttackEventEnter = new AnimatorControlEvent ();
    public static AnimatorControlEvent AttackEventExit = new AnimatorControlEvent ();
    public static AnimatorControlEvent DieEventEnter = new AnimatorControlEvent();
    public static AnimatorControlEvent DieEventExit = new AnimatorControlEvent();
    public static AnimatorControlEvent FleeEventEnter = new AnimatorControlEvent();
    public static AnimatorControlEvent FleeEventExit = new AnimatorControlEvent ();
    public static AnimatorControlEvent WarcryEventEnter = new AnimatorControlEvent ();
    public static AnimatorControlEvent WarcryEventExit = new AnimatorControlEvent();

    public static WarcryEvent WarcryMonster = new WarcryEvent();
    public static TargetEvent FindTarget = new TargetEvent ();
    public static TargetEvent Target = new TargetEvent();
    public static TakeDamageEvent TakeDamge = new TakeDamageEvent ();
	public static MonsterEvent MonsterDie = new MonsterEvent();
	public static MonsterEvent MonsterStop = new MonsterEvent();
	public static MonsterEvent MonsterGogo = new MonsterEvent();

//    public static FireBullet FairyFire = new FireBullet ();

}
