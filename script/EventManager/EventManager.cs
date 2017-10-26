using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;


public class HitCollisionEvent : UnityEvent <Collision>{}
public class HitTriggerEvent : UnityEvent <Collider>{}
public class ExitTriggerEvent : UnityEvent <Collider>{}

public class GoldEvent : UnityEvent<int>{}
//public class PlayerDieEvent : UnityEvent<GameObject>{}
public class PlayerDieEvent : UnityEvent{}
public class PlayerUseSkillEvent : UnityEvent<String>{}
public class PlayerPlus : UnityEvent<int>{}

public class EventManager : MonoBehaviour
{
	private EventManager (){}

	[SerializeField]
	public static HitCollisionEvent onHitCollisionEvents = new HitCollisionEvent ();
	[SerializeField]
	public static HitTriggerEvent onHitTriggerEvents = new HitTriggerEvent ();
	[SerializeField]
	public static ExitTriggerEvent onExitTriggerEvents = new ExitTriggerEvent ();

    public static GoldEvent PositiveGold = new GoldEvent ();
    public static GoldEvent NegativeGold = new GoldEvent ();
    public static GoldEvent UpdateGold = new GoldEvent ();

	public static PlayerDieEvent PlayerDie = new PlayerDieEvent();
	public static PlayerUseSkillEvent PlayerSkill = new PlayerUseSkillEvent();
	public static PlayerPlus PlayerHeal = new PlayerPlus();
	public static PlayerPlus PlayerMana = new PlayerPlus();
}

