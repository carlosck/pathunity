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
	}

	public bool enemyKilled(GameObject enemy)
	{
		
		int enemy_id=enemy.GetInstanceID();
		bool found= false;
		int cont_quest=0;
		
		//find in all quest if a the enemy killed is part of a quest
		while(!found && cont_quest<quests.Count)
		{
			int cont_enemies=0;
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
		return true;
	}
	void UpdateStatus(int questAt,int enemyID)
	{
		Quest quest= quests[questAt];
		Debug.Log(quest.transform.Find("Enemies").childCount);
		if(quest.transform.Find("Enemies").childCount<=1)
		{
			Debug.Log("endQuest");
			quest.getQuestGiver().QuestReady();
			quests.RemoveAt(questAt);
		}
	}
	

}