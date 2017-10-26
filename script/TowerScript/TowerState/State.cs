using UnityEngine;
using System.Collections;



[System.Serializable]
public abstract class State : MonoBehaviour
{
	protected Animator anim;
	protected TowerModel towerModel;

	void Awake ()
	{
		init ();  
	}

	public virtual void init ()
	{
		anim = GetComponent<Animator> ();
		towerModel = GetComponent<TowerModel> ();
	}

	public virtual void onEnter (Animator anim)
	{
		if (this.anim == anim)
			enabled = true;
	}

	public virtual void onExit (Animator anim)
	{
		if (this.anim == anim)
			enabled = false;
	}
		

	public virtual void onStateChanged (string from, string to)
	{                    
		anim.ResetTrigger (from);
		anim.SetTrigger (to);                  
	}



}
		
	

