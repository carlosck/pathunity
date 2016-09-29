using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestHolder: MonoBehaviour
{
	
	public List<Quest> quests;
		

	public void addQuest(Quest quest)
	{
		quests.Add(quest);
	}

}