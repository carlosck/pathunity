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
	public GameObject fadeObj ;
	public QuestContainer gameQuestContainer;
	// Use this for initialization
	
	void Awake () {
		menu.SetActive(true);
		ms= menu.GetComponent<main_menu>();
		gom= gameOver.GetComponent<gameOver_menu>();
		Time.timeScale = 1;
		isGameOver= false;
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
		print("closeMenu GO");
		gameQuestContainer.continueGame();
		StartCoroutine(hideGameOverMenu());

		
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
		StartCoroutine(cortinilla());
		//StartCoroutine(cortinilla_hide());
		// intro.SetActive(false);
		// healtUi.SetActive(true);
		// Time.timeScale = 1;
	}
	IEnumerator cortinilla()
	{	
		
		Time.timeScale = 1;
		Instantiate(fadeObj, new Vector3(0, 0, 0), Quaternion.identity); 
		yield return new WaitForSeconds(1);
		//yield return new WaitForSeconds(1);
		
		intro.SetActive(false);
		healtUi.SetActive(true);
			
		//yield break;	
	}
	
	

	public void playerDeath(){
		StartCoroutine(cortinilla_playerDeath());
	}

	IEnumerator cortinilla_playerDeath()
	{	
		
		Debug.Log("muerte");
		yield return new WaitForSeconds(2f);
		Debug.Log("fade");
		Instantiate(fadeObj, new Vector3(0, 0, 0), Quaternion.identity); 
		yield return new WaitForSeconds(1f);
		Debug.Log("show GOM");
		showGameOverMenu();
		yield return new WaitForSeconds(0.6f);
		//yield break;
		
	}
	void showGameOverMenu()
	{
		Debug.Log("hide GOM");
		isGameOver=true;
		gameOver.SetActive(true);
		Debug.Log("SetActive GOM");
		//fadeObj.SetActive(false);
		
		
	}
	IEnumerator hideGameOverMenu(){

		Debug.Log("hide GOM");
		Time.timeScale = 1;
		Instantiate(fadeObj, new Vector3(0, 0, 0), Quaternion.identity); 
		yield return new WaitForSeconds(1f);

		isGameOver=false;		
		gom.busy= false;		
		gameOver.SetActive(false);
		healtUi.SetActive(true);
		yield return new WaitForSeconds(0.6f);
	}


	
}


