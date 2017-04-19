using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class QuestContainer: MonoBehaviour
{
	
	public List<Quest> quests;

	public GameObject player;
	PlayerHealth playerHealth;
	QuestManager questManagerPlayer;
	GameObject npc;
	NPCInteract npcInteract;

	public bool loaded = false;
	private int currentQuestId ;
	Quest currentQuest;
	public int coins ;
	public bool FromFile ;	

	public void Awake()
	{
		questManagerPlayer=player.GetComponent <QuestManager>();
		playerHealth=player.GetComponent <PlayerHealth>();
		Load();	
	}
	public Quest getQuestAt(int i)
	{
		return quests[i];
	}

	public void startQuestAt(int i)
	{
		Debug.Log("---------------Quest id= "+i);
		currentQuest = quests[i];
		Debug.Log(currentQuest);
		currentQuestId= i;
		activateQuest(currentQuest);
		npc= currentQuest.getQuestReceiver(); 
		var cam= currentQuest.getCam(); 
		cam.GetComponent<Camera>().enabled=true;
		npcInteract= npc.GetComponent <NPCInteract>(); 
		player.transform.position = currentQuest.getInitPosition().transform.position;
		activateQuestOnNPC(currentQuest);

	}

	public void activateQuest(Quest quest)
	{
		quest.init();
		
		if(quest.isGoToTalkSomeone)
		{
			quest.getQuestReceiver().GetComponent <NPCInteract>().setTurnQuest(quest);
			quest.getQuestReceiver().GetComponent <NPCInteract>().QuestReady();			
		}
	}
	public void activateQuestOnNPC(Quest quest)
	{
		npcInteract.addQuest(quest);
	}

	public void continueGame()
	{
		playerHealth.restart();
		startQuestAt(currentQuestId);
	}
	public void startGame()
	{
		startQuestAt(0);
	}
	public void nextQuest()
	{
		Debug.Log("nextQuest->"+currentQuestId);
		if(currentQuestId+1<=quests.Count)
		{
			startQuestAt(currentQuestId+1);
		}
	}
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+ "/uninfos.dat");

		UserPrefs prefs = new UserPrefs();
		prefs.currentQuestId= currentQuestId;		
		prefs.coins = coins;		

		bf.Serialize(file,prefs);
		file.Close();
	}

	public void Load()
	{
		print("Load");
		if(loaded)return;
		if(FromFile){
			if(File.Exists(Application.persistentDataPath+ "/potb.dat"))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath+ "/potb.dat",FileMode.Open);
				UserPrefs prefs = (UserPrefs)bf.Deserialize(file);

				file.Close();								
				currentQuestId = prefs.currentQuestId ;
				coins = prefs.coins ;								
				
			}
			else
			{
				Save();
			}
		}
		
		loaded= true;
		
	}
	public bool enemyKilled(GameObject enemy)
	{
		
		Debug.Log("killed ");
		int enemy_id=enemy.GetInstanceID();
		bool found= false;
		int cont_quest=currentQuestId;
		
		//find in all quest if a the enemy killed is part of a quest
		while(!found && cont_quest<quests.Count)
		{
			
			foreach(Transform child in quests[cont_quest].transform.Find("Enemies"))
			{
				
				if(enemy_id==child.gameObject.GetInstanceID())
				{
					found= true;
					UpdateStatus(cont_quest,child.gameObject.GetInstanceID());
					Destroy(child.gameObject,1f);					
					break;
				}
			}
			cont_quest++;			
		}
		return found;
	}
	void UpdateStatus(int questAt,int enemyID)
	{
		Debug.Log("UpdateStatus");
		Quest quest= quests[questAt];
		Debug.Log(quest.transform.Find("Enemies").childCount);
		if(quest.transform.Find("Enemies").childCount<=1)
		{
			Debug.Log("endQuest");
			quest.getQuestReceiver().GetComponent <NPCInteract>().QuestReady();
			
		}
	}
	public void finishQuest(Quest quest)
	{
		nextQuest();
		// bool found= false;
		// int cont_quest=0;
		// //TODO: give reward to player
		// //quest.reward

		
		// //find in all quest if a the enemy killed is part of a quest
		// while(!found && cont_quest<quests.Count)
		// {
			
		// 	if(quest.GetInstanceID()==quests[cont_quest].GetInstanceID())
		// 	{
		// 		found= true;
		// 		quests.RemoveAt(cont_quest);
		// 	}
		// 	cont_quest++;			
		// }
	}
	public int getCurrentQuestId()
	{
		return currentQuestId;
	}

}

[Serializable]
class UserPrefs
{
	public int currentQuestId;
	public int coins;	
}