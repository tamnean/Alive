using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MonsterModel : MonoBehaviour {

    [SerializeField]
    int loot;
    [SerializeField]
    float dmg  ,range ,hp ,atkSpeed ,moveSpeed ;
    public float radias;
    public float useRate;
    [HideInInspector]
    public float nextUse;

   

    [HideInInspector]
    public GameObject[] target ;
    [HideInInspector]
	public GameObject myTarget ;

    [HideInInspector]
	public Rigidbody rigid;


    public float MyDamge 
    {
        get
        {
            return dmg;
        }
        set
        {
            dmg = value;
        }
    }

    public float MyRange
    {
        get
        {
            return range;
        }
        set
        {
            range = value;
        }
    }

    public float MyHp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public float MyAtkSpeed 
    {
        get
        {
            return atkSpeed;
        }
        set
        {
            atkSpeed = value;
        }
    }

    public float MyMoveSpeed 
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    public int Myloot
    {
        get
        {
            return loot;
        }
        set
        {
            loot = value;
        }
    }


	void Start()
	{
		rigid = GetComponent<Rigidbody> ();
	}

}

