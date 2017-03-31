using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIActions : MonoBehaviour {

	public GameObject menu;
	public GameObject gameOver;
	main_menu ms;
	gameOver_menu gom;
	public GameObject intro;
	public GameObject healtUi;	
	bool isGameOver;
	// Use this for initialization
	
	void Awake () {							
		ms= menu.GetComponent<main_menu>();
		gom= gameOver.GetComponent<gameOver_menu>();
		Time.timeScale = 0;
		isGameOver= true;
	}
	
	void Update () {
		if (Input.GetKeyDown("return"))
		{
			print("enter");
			if(isGameOver){
				gom.selectMenu();
			}
			else{
				if(ms.busy)
				{
					ms.selectMenu();
				}
				else
				{
					showMenu();			
				}
			}
			
		}
	}

	void showMenu()
	{
		print("showMenu");
		if(ms.busy) return;

		ms.busy= true;
		menu.SetActive(true);
		Time.timeScale = 0;
		healtUi.SetActive(false);
	}
	public void closeMenu()
	{
		print("closeMenu");
		menu.SetActive(false);
		ms.busy= false;
		Time.timeScale = 1;
		healtUi.SetActive(true);
	}

	public void GameOverContinue()
	{
		print("closeMenu");
		gameOver.SetActive(false);
		gom.busy= false;
		Time.timeScale = 1;
		healtUi.SetActive(true);
	}
	public void showIntroVideo()
	{
		print("showIntro");
		menu.SetActive(false);
		intro.SetActive(true);
		ms.busy= false;		
	}
	public void hideIntro()
	{
		print("hideIntro");
		intro.SetActive(false);
		healtUi.SetActive(true);
		Time.timeScale = 1;
	}

	
}


