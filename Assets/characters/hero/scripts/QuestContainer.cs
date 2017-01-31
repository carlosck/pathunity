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
	QuestManager questManagerPlayer;
	GameObject npc;
	NPCInteract npcInteract;

	public bool loaded = false;
	public int currentQuestId ;
	public int coins ;
	public bool FromFile ;	

	public void Awake()
	{
		questManagerPlayer=player.GetComponent <QuestManager>();
		Load();	
	}
	public Quest getQuestAt(int i)
	{
		return quests[i];
	}

	public void startQuestAt(int i)
	{
		var currentQuest = quests[i];
		Debug.Log(currentQuest);

		activateQuestOnPlayer(currentQuest);
		npc= currentQuest.getQuestReceiver(); 
		var cam= currentQuest.getCam(); 
		cam.GetComponent<Camera>().enabled=true;
		npcInteract= npc.GetComponent <NPCInteract>(); 
		player.transform.position = currentQuest.getInitPosition().transform.position;
		activateQuestOnNPC(currentQuest);

	}

	public void activateQuestOnPlayer(Quest quest)
	{
		questManagerPlayer.addQuest(quest);
	}
	public void activateQuestOnNPC(Quest quest)
	{
		npcInteract.addQuest(quest);
	}

	public void continueGame()
	{
		startQuestAt(currentQuestId);
	}
	public void startGame()
	{
		startQuestAt(0);
	}
	public void nextQuest()
	{
		
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

}

[Serializable]
class UserPrefs
{
	public int currentQuestId;
	public int coins;	
}