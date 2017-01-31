using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {

	// Use this for initialization
	public UIActions ui;
	public GameObject select_continue; 
	public GameObject select_newgame; 
	public GameObject select_quit; 
	public GameObject btn_continue; 
	public GameObject btn_continue_disabled;
	
	public QuestContainer gameQuestContainer;
	public Animator animMenu; 

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
			print("right key was pressed");
			current_position++;
			if(current_position>2)current_position=2;			
			update_select_position();
		}
		if (Input.GetKeyDown("left"))
		{
			print("left key was pressed");
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
				select_continue.SetActive(true);
				select_newgame.SetActive(false);
				select_quit.SetActive(false);
			break;
			case 1: 
				select_continue.SetActive(false);
				select_newgame.SetActive(true);
				select_quit.SetActive(false);
			break;
			case 2: 
				select_continue.SetActive(false);
				select_newgame.SetActive(false);
				select_quit.SetActive(true);
			break;	
		}
	}
	public void selectMenu()
	{
		
		switch(current_position)
		{
			case 0: 
				if(gameQuestContainer.currentQuestId>0){
					continueGame();
				}
			break;
			case 1: 
				newGame();
			break;
			case 2: 
				continueGame();
				quitGame();
			break;	
		}
	}
	void continueGame()
	{
		print("continue");
		ui.closeMenu();
		//Quest currentQuest=questContainer.getQuestAt(0);
		gameQuestContainer.continueGame();
		
	}
	void newGame()
	{
		print("newGame");
		animMenu.SetTrigger("exit");
		gameQuestContainer.startGame();
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

		if(gameQuestContainer.currentQuestId>0){
			btn_continue.SetActive(true);
			btn_continue_disabled.SetActive(false);
		}
		else
		{
			btn_continue.SetActive(false);
			btn_continue_disabled.SetActive(true);
		}
	}
	public bool isBusy(){
		return busy;
	}
	public void endIntroEscene()
	{
		ui.showIntroVideo();
	}
}


