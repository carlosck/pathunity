using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIActions : MonoBehaviour {

	public GameObject menu;
	main_menu ms;
	public GameObject intro;	
	
	// Use this for initialization
	
	void Awake () {							
		ms= menu.GetComponent<main_menu>();
		Time.timeScale = 0;
	}
	
	void Update () {
		if (Input.GetKeyDown("return"))
		{
			print("enter");
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

	void showMenu()
	{
		print("showMenu");
		if(ms.busy) return;

		ms.busy= true;
		menu.SetActive(true);
		Time.timeScale = 0;
	}
	public void closeMenu()
	{
		print("closeMenu");
		menu.SetActive(false);
		ms.busy= false;
		Time.timeScale = 1;
	}
	public void showIntroVideo()
	{
		print("showIntroVideo");
		menu.SetActive(false);
		intro.SetActive(true);
		ms.busy= false;		
	}
	public void hideIntro()
	{
		print("hideIntro");
		intro.SetActive(false);
		Time.timeScale = 1;
	}

	
}


