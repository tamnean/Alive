using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager_Play : MonoBehaviour 
{
	public GameObject pauseActive;
	public GameObject itemUICaller;
	public GameObject itemUIActive;
	public GameObject towerUICaller;
	public GameObject towerUIActive;


	public void OnPauseClick()
	{
		pauseActive.SetActive (true);
		Time.timeScale = 0;
	}
	public void OnResume()
	{
		Time.timeScale = 1;
		pauseActive.SetActive (false);
	}

	public void OnMainMenuClick()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("Main Menu");
	}



	public void OnTowerUIActive()
	{
		towerUIActive.SetActive (true);
		towerUICaller.SetActive (false);
	}

	public void OnTowerUIOut()
	{
		towerUIActive.SetActive (false);
		towerUICaller.SetActive (true);
	}




	public void OnItemUIActive()
	{
		itemUIActive.SetActive (true);
		itemUICaller.SetActive (false);
	}

	public void OnItemUIOut()
	{
		itemUIActive.SetActive (false);
		itemUICaller.SetActive (true);
	}


	public void PlayAnimMoveIn(GUIAnimFREE ui)
	{
		ui.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	}

	public void PlayAnimMoveOut(GUIAnimFREE ui)
	{
		ui.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	}
}
