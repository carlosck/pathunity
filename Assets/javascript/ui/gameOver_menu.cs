using UnityEngine;
using System.Collections;

public class gameOver_menu : MonoBehaviour {

	// Use this for initialization
	public UIActions ui;
	public GameObject select_yes; 
	public GameObject select_no; 
		
	
	public QuestContainer gameQuestContainer;
	//public Animator animMenu; 

	public bool busy= true;
	
	
	int current_position=0;

	// Update is called once per frame
	// void Awake()
	// {		
	// 	gameQuestContainer =player.GetComponent <QuestContainer>();
	// }
	void Update () {
		if (Input.GetKeyDown("right"))
		{
			print("right key was pressed go");
			current_position++;
			if(current_position>1)current_position=1;			
			update_select_position();
		}
		if (Input.GetKeyDown("left"))
		{
			print("left key was pressed go");
			current_position--;
			if(current_position<0)current_position=0;
			update_select_position();			
		}	
		            
	}

	void update_select_position()
	{
		
		print(current_position);
		switch(current_position)
		{
			case 0: 
				select_yes.SetActive(true);
				select_no.SetActive(false);				
			break;
			case 1: 
				select_yes.SetActive(false);
				select_no.SetActive(true);				
			break;
			
			break;	
		}
	}
	public void selectMenu()
	{
		Debug.Log("selectMenu from gameOver_menu");
		Debug.Log(current_position);
		switch(current_position)
		{
			case 0: 
				if(gameQuestContainer.currentQuestId>0){
					continueGame();
				}
			break;
			case 1: 
				continueGame();
				quitGame();
			break;			
		}
	}
	void continueGame()
	{
		print("continue");
		ui.GameOverContinue();
		//Quest currentQuest=questContainer.getQuestAt(0);
		gameQuestContainer.continueGame();
		
	}
	void GameOverClose()
	{
		print("GameOverClose");
		//animMenu.SetTrigger("exit");
		//gameQuestContainer.startGame();
		//ui.closeMenu();
		
	}
	void quitGame()
	{
		print("quitGame");
	}

	
	public void Start()
	{
		print("quest");
		print(gameQuestContainer.currentQuestId);
		
	}
	public bool isBusy(){
		return busy;
	}
	public void endIntroEscene()
	{
		ui.showIntroVideo();
	}
}


