using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TowerModel : MonoBehaviour 
{	
	[SerializeField]
	private float m_CurrentHp;
	private float m_MaxHp;
	private float m_FireRateDeley;

    private int m_Cost;

	[SerializeField]
	private List<GameObject> m_TargetTriggers;



	[SerializeField]
	private GameObject m_CurrentTarget;

	private GameObject m_Bullet;

	private float m_BulletDamage;

	public float CurrentHp
	{
		get{return m_CurrentHp;}
		set{m_CurrentHp = Mathf.Clamp(value, 0, MaxHp);}
	}

	public float MaxHp
	{
		get{return m_MaxHp;}
		set{m_MaxHp=value;}
	}

	public List<GameObject> TargetTriggers
	{
		get{return m_TargetTriggers;}
	}

	public float FireRateDeley
	{
		get{return m_FireRateDeley;}
	}

	public GameObject CurrentTarget
	{
		get{return m_CurrentTarget;}
		set{m_CurrentTarget = value;}

	}

	public GameObject Bullet
	{
		get{return m_Bullet;}
		set{m_Bullet = value;}
	}
		

	public float BulletDamage
	{
		get{return m_BulletDamage;}
	}

    public int Cost 
    {
        get{ return m_Cost;}
        set{ m_Cost = value; }
    }


	void OnEnable()
	{
		m_TargetTriggers = new List<GameObject>();


		if(gameObject.name.Contains("Cactus"))
		{
			m_FireRateDeley = 0.5f;
			m_BulletDamage = 20;
			m_Bullet = transform.FindChild("SpikeAttack").gameObject;
			m_MaxHp = 300;
			m_CurrentHp = m_MaxHp;
            m_Cost = 10;
		}
		else if(gameObject.name.Contains("Magictree"))
		{
			m_FireRateDeley = 3;
			m_BulletDamage = 5;
			m_Bullet = transform.FindChild("SmokeExplosion").gameObject;
			m_MaxHp = 200;
			m_CurrentHp = m_MaxHp;
            m_Cost = 20;
		}
		else if(gameObject.name.Contains("SunFlower"))
		{
			m_FireRateDeley = 10;
			m_BulletDamage = 100;
			m_Bullet = transform.FindChild("PowerAuraGreen").gameObject;
			m_MaxHp = 100;
			m_CurrentHp = m_MaxHp;
            m_Cost = 30;
		}
		else if(gameObject.name.Contains("Carrot"))
		{
			m_FireRateDeley = 3;
			m_BulletDamage = 10;
			m_Bullet = transform.FindChild("LightWall").gameObject;
			m_MaxHp = 100;
			m_CurrentHp = m_MaxHp;
            m_Cost = 40;
		}

		else if(gameObject.name.Contains("Woody"))
		{
			m_FireRateDeley = 2f;
			m_BulletDamage = 10;
			m_Bullet = transform.FindChild("Flower").gameObject;
			m_MaxHp = 50;
			m_CurrentHp = m_MaxHp;
            m_Cost = 50;
		}

        //EventManager.NegativeGold.Invoke(Cost);
	}


}
