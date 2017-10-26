using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AnimatorControllerEvent : UnityEvent<Animator>
{

}

public class TowerStateManager : MonoBehaviour
{

	public static AnimatorControllerEvent IdleEventEnter = new AnimatorControllerEvent ();
	public static AnimatorControllerEvent IdleEventExit = new AnimatorControllerEvent ();
	public static AnimatorControllerEvent AttackEventEnter = new AnimatorControllerEvent ();
	public static AnimatorControllerEvent AttackEventExit = new AnimatorControllerEvent ();
	public static AnimatorControllerEvent DieEventEnter = new AnimatorControllerEvent ();
	public static AnimatorControllerEvent DieEventExit = new AnimatorControllerEvent ();

	private TowerStateManager ()
	{
	}
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}
}