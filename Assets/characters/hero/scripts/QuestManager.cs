using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestManager: MonoBehaviour
{
	
	public List<Quest> quests;
	
	

	public void addQuest(Quest quest)
	{		
		quests.Add(quest);
		quest.init();
		
		if(quest.isGoToTalkSomeone)
		{
			quest.getQuestReceiver().GetComponent <NPCInteract>().setTurnQuest(quest);
			quest.getQuestReceiver().GetComponent <NPCInteract>().QuestReady();

			//quests.RemoveAt(quests.Count-1);
		}
	}

	public void finishQuest(Quest quest)
	{
		bool found= false;
		int cont_quest=0;
		//TODO: give reward to player
		//quest.reward

		
		//find in all quest if a the enemy killed is part of a quest
		while(!found && cont_quest<quests.Count)
		{
			
			if(quest.GetInstanceID()==quests[cont_quest].GetInstanceID())
			{
				found= true;
				quests.RemoveAt(cont_quest);
			}
			cont_quest++;			
		}
		
	}
	public bool enemyKilled(GameObject enemy)
	{
		
		int enemy_id=enemy.GetInstanceID();
		bool found= false;
		int cont_quest=0;
		
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
		Quest quest= quests[questAt];
		Debug.Log(quest.transform.Find("Enemies").childCount);
		if(quest.transform.Find("Enemies").childCount<=1)
		{
			Debug.Log("endQuest");
			quest.getQuestReceiver().GetComponent <NPCInteract>().QuestReady();
			
		}
	}

}

