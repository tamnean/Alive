using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour 
{
	public float hp;
	public float maxHp;
	public Rigidbody rigid;
	float time =0;

	public float Hp
	{
		get
		{
			return hp;
		}
		set
		{
			hp= value;
		}
	}


	void Start () 
	{
		hp = 10;
		maxHp = 10;
		rigid = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		time += Time.deltaTime;
		rigid.velocity = new Vector3(Input.GetAxis("Horizontal") ,0f,Input.GetAxis("Vertical"))*20;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag =="Tower" && time >= 2)
		{
			TowerModel tower = other.GetComponent<TowerModel>();
			tower.CurrentHp -= 10;
			time=0;
			Debug.Log(tower.CurrentHp);
		}
	}
}
