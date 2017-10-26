using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Player : MonoBehaviour {
    
    float horizontal;
    float vertical;

    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    Slider mpSlider;

	[SerializeField]
    int gold;
   
    [SerializeField]
    int hp = 1000 ;
	[SerializeField]
	int m_Mp = 100 ;

	private Animator anim;

    public int m_HP 
    {
        get{ return hp; }
        set{ hp = value; }
    }

	public int MP
	{
		get{ return m_Mp; }
		set{ m_Mp = value; }
	}

    float moveSpeed = 5; 
    public float m_Speed
    {
        get{ return moveSpeed; }
        set{ moveSpeed = value; }
    }

	public int m_Gold
	{
		get{ return gold;}
		set
		{ 
			gold = value;
			EventManager.UpdateGold.Invoke(gold);
		}
	}
		

    void Awake ()
    {
		hpSlider = hpSlider.GetComponent<Slider> ();
		mpSlider = mpSlider.GetComponent<Slider> ();
        anim = gameObject.GetComponent<Animator>();

        MonsterManager.TakeDamge.AddListener(TakeDamage);
        EventManager.PositiveGold.AddListener(PositiveGold);
        EventManager.NegativeGold.AddListener(NegativeGold);
		EventManager.PlayerSkill.AddListener (UseMana);
		EventManager.PlayerHeal.AddListener (PlayerIsHealed);
		EventManager.PlayerMana.AddListener (PlayerGetMana);


		hpSlider.maxValue = hp;
		hpSlider.value = hp;
		mpSlider.maxValue = MP;
		mpSlider.value = MP;
		InvokeRepeating ("ManaRegen", 1, 1);
    }

	void Start()
	{
		m_Gold = 100;
	}

	void ManaRegen()
	{
		MP += 1;
		mpSlider.value = MP;
		if (MP > mpSlider.maxValue)
		{
			MP = (int)mpSlider.maxValue;
			CancelInvoke ("ManaRegen");
		}
			
	}

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
	void Update () 
    {
        Run();


	}

    void Run()
    {
		
		//horizontal = Input.GetAxis ("Horizontal");
		//vertical = Input.GetAxis ("Vertical");

		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
	
        Vector3 direction = new Vector3(horizontal,0f,vertical);
        Vector3 velocity = direction * moveSpeed * Time.deltaTime;
		if(horizontal != 0 || vertical !=0)
       	 	transform.rotation = Quaternion.LookRotation(direction);
        anim.SetTrigger("Dash");

        Position = Position + velocity;
    }

    void TakeDamage (GameObject m,float d)
    {
        if(this.gameObject == m)
        {
            m_HP -= (int)d;
			hpSlider.value = hp;
        }    

		if (m_HP <= 0)
			EventManager.PlayerDie.Invoke ();
		if (m_HP > 1000)
			m_HP = 1000;
    }

	void PlayerIsHealed(int healDamage)
	{
		m_HP += (int)healDamage;
		hpSlider.value = hp;
	}

	void PlayerGetMana(int manaGet)
	{
		MP += (int)manaGet;
		mpSlider.value = MP;
	}

	void UseMana(string skillName)
	{
		if (skillName == "normal") 
		{
			MP -= 20;
		}
		else if (skillName == "necro")
		{
			MP -= 60;
		}
		else if (skillName == "maiden")
		{
			MP -= 40;
		}
			
		mpSlider.value = MP;

		if (MP <= 0)
			MP = 0;
		else if (MP > mpSlider.maxValue)
			MP = (int)mpSlider.maxValue;
		else
			InvokeRepeating ("ManaRegen", 1, 1);
			

	}

    void PositiveGold(int g)
    {
        m_Gold += g;
    }

    void NegativeGold(int g)
    {
        m_Gold -= g;
    }
   
}
