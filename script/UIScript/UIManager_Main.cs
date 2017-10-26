using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager_Main : MonoBehaviour 
{
	public GameObject loadingPic;
	public GameObject shopActive;
	public Button normalButton;
	public Button maidenButton;
	public Button necroButton;
	public Text normalText;
	public Text maidenText;
	public Text necroText;

	float m_money;
	public Text moneyText;

	public float RealMoney
	{
		get{return m_money;}
		set{ m_money = value;}
	}

	void Awake()
	{
		RealMoney = 4f;
		moneyText.text = RealMoney.ToString ("F");
		PlayerPrefs.SetInt ("NecroBuy", 0);
		PlayerPrefs.SetInt ("MaidenBuy", 0);
		PlayerPrefs.SetString ("CharacterSelected", "Normal");
	}

	public void OnLoading()
	{
		loadingPic.SetActive (true);
		Invoke ("OnChangeScene", 3);
	}

	public void OnShopOpenClick()
	{
		shopActive.SetActive (true);
	}
	public void OnShopCloseClick()
	{
		shopActive.SetActive (false	);
	}

	public void PlayAnimMoveIn(GUIAnimFREE ui)
	{
		ui.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	}

	public void PlayAnimMoveOut(GUIAnimFREE ui)
	{
		ui.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	}

	public void OnChangeScene()
	{
		SceneManager.LoadScene ("Together_Scene");
	}

	public void OnExitGame()
	{
		Application.Quit ();
	}


	public void OnNormalButtonClick()
	{
		normalButton.interactable = false;
		normalText.text = "Selected";
		maidenButton.interactable = true;
		necroButton.interactable = true;
		PlayerPrefs.SetString ("CharacterSelected", "Normal");

		if (PlayerPrefs.GetInt ("MaidenBuy") == 1) 
		{
			maidenText.text = "Pick";
		}
		if (PlayerPrefs.GetInt ("NecroBuy") == 1) 
		{
			necroText.text = "Pick";
		}

	}

	public void OnNecroButtonClick()
	{
		if (PlayerPrefs.GetInt ("NecroBuy") == 1) 
		{
			necroButton.interactable = false;
			necroText.text = "Selected";
			normalButton.interactable = true;
			normalText.text = "Pick";
			maidenButton.interactable = true;
			PlayerPrefs.SetString ("CharacterSelected", "Necro");

			if (PlayerPrefs.GetInt ("MaidenBuy") == 1) 
			{
				maidenText.text = "Pick";
			}

		} 
		else 
		{
			if (RealMoney >= 1.99f) 
			{
				RealMoney -= 1.99f;
				moneyText.text = RealMoney.ToString ("F");
				PlayerPrefs.SetInt ("NecroBuy", 1);
				necroText.text = "Pick";
			}
		}
	}

	public void OnMaidenButtonClick()
	{
		if (PlayerPrefs.GetInt ("MaidenBuy") == 1) 
		{
			maidenButton.interactable = false;
			maidenText.text = "Selected";
			normalButton.interactable = true;
			normalText.text = "Pick";
			necroButton.interactable = true;
			PlayerPrefs.SetString ("CharacterSelected", "Maiden");
		
			if (PlayerPrefs.GetInt ("NecroBuy") == 1) 
			{
				necroText.text = "Pick";
			}
		}
		else 
		{
			if (RealMoney >= 1.99f) 
			{
				RealMoney -= 1.99f;
				moneyText.text = RealMoney.ToString ("F");
				PlayerPrefs.SetInt ("MaidenBuy", 1);
				maidenText.text = "Pick";
			}
		}
	}


}
