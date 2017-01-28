using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {

	// Use this for initialization
	public GameObject select_continue; 
	public GameObject select_newgame; 
	public GameObject select_quit; 
	int current_position=0;
	void Start () {
		 //Time.timeScale = 0.0F;
	}
	
	// Update is called once per frame
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
}
