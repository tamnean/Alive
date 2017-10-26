using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour 
{
	public GameObject normalCharacter;
	public GameObject necroCharacter;
	public GameObject maidenCharacter;

	public GameObject normalSkillImage;
	public GameObject necroSkillImage;
	public GameObject maidenSkillImage;

	public Button skillButton;
	public GameObject manaNotEnough;

	//Maiden Skill point target
	public List<GameObject> thunderPoint;
	public GameObject thunder;
	int thunderCount =3;

	//Necro Skill poit target
	public GameObject batPoint;
	public GameObject auraBat; //no need to pool 
	public GameObject auraSwap;

	//Normal Skill
	public GameObject boomBoom;
	Rigidbody rigidNormal;
	//Rigidbody rigidBat;

	int batCount =5;
	string skillName;

	void Awake () 
	{
		
		PoolManager.WarmPool (auraSwap, 30);
		PoolManager.WarmPool (thunder, 48);
		PoolManager.WarmPool (boomBoom, 5);
		
		if (PlayerPrefs.GetString ("CharacterSelected") == "Normal") 
		{
			normalCharacter.SetActive (true);
			rigidNormal = normalCharacter.GetComponent<Rigidbody> ();
			normalSkillImage.SetActive (true);
			skillName ="normal";
		} 
		else if (PlayerPrefs.GetString ("CharacterSelected") == "Necro") 
		{
			necroCharacter.SetActive (true);
			necroSkillImage.SetActive (true);
			skillName ="necro";
		}
		else if (PlayerPrefs.GetString ("CharacterSelected") == "Maiden") 
		{
			maidenCharacter.SetActive (true);
			maidenSkillImage.SetActive (true);
			skillName ="maiden";
		}
			
	}

	public void Skill()
	{
		if (normalCharacter.activeInHierarchy && normalCharacter.GetComponent<Player> ().MP >= 20)
		{
			PoolManager.SpawnObject (boomBoom, normalCharacter.transform.position + new Vector3 (0, 1, 0), Quaternion.AngleAxis (-90, Vector3.right));
			rigidNormal.AddRelativeForce (transform.forward * 1000);
			EventManager.PlayerSkill.Invoke (skillName);
			normalSkillImage.GetComponent<Image> ().color = Color.red;
			skillButton.GetComponent<Button> ().interactable = false;
			Invoke ("CoolDown", 10);
		} 
		else if (necroCharacter.activeInHierarchy && necroCharacter.GetComponent<Player> ().MP >= 60) 
		{
			InvokeRepeating ("BatRaider", 0, 1);
			auraBat.SetActive (true);
			EventManager.PlayerSkill.Invoke (skillName);
			necroSkillImage.GetComponent<Image> ().color = Color.red;
			skillButton.GetComponent<Button> ().interactable = false;
			Invoke ("CoolDown", 10);
		}
		else if (maidenCharacter.activeInHierarchy && maidenCharacter.GetComponent<Player> ().MP >= 40)
		{
			InvokeRepeating ("StormCall", 0, 1);
			EventManager.PlayerSkill.Invoke (skillName);
			maidenSkillImage.GetComponent<Image> ().color = Color.red;
			skillButton.GetComponent<Button> ().interactable = false;
			Invoke ("CoolDown", 10);
		} 
		else
		{
			manaNotEnough.SetActive (true);
			Invoke ("ManaOutOut",1);
		}
	}

	void ManaOutOut()
	{
		manaNotEnough.SetActive (false);
	}

	void CoolDown()
	{
		skillButton.GetComponent<Button> ().interactable =true;

		normalSkillImage.GetComponent<Image> ().color = Color.white;
		necroSkillImage.GetComponent<Image> ().color = Color.white;
		maidenSkillImage.GetComponent<Image> ().color = Color.white;
	}
		

	void BatRaider ()
	{	
		PoolManager.SpawnObject (auraSwap, necroCharacter.transform.position, Quaternion.AngleAxis(-90,Vector3.right));
		necroCharacter.transform.position = new Vector3( 
												Mathf.Clamp(batPoint.transform.position.x,-20,20),
												batPoint.transform.position.y,
												Mathf.Clamp(batPoint.transform.position.z,-20,20)	);
		PoolManager.SpawnObject (auraSwap, necroCharacter.transform.position, Quaternion.AngleAxis(-90,Vector3.right));
		batCount--;
		if (batCount <= 0) 
		{
			CancelInvoke ("BatRaider");
			batCount = 5;
			Invoke ("SetFalseBatCloud", 2);
		}
	}

	void SetFalseBatCloud ()
	{
		auraBat.SetActive (false);
	}

	void StormCall()
	{
		List<GameObject> thunderList = new List<GameObject>() ;
		for (int i = 0; i < thunderPoint.Count; i++) 
		{
			thunderList.Add (thunderPoint [i]);
		}

		for (int i = 0; i < 12; i++) 
		{
			GameObject thunderStikePoint = thunderList [Random.Range (0,thunderList.Count )];
			PoolManager.SpawnObject (thunder, thunderStikePoint.transform.position, Quaternion.AngleAxis(90,Vector3.right));
			thunderList.Remove (thunderStikePoint);
		}

		thunderCount--;

		if (thunderCount <= 0) 
		{
			CancelInvoke ("StormCall");
			thunderCount = 3;
		}

	}

}
