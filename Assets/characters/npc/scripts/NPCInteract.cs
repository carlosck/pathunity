using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class NPCInteract : MonoBehaviour
{
	public bool hasQuest = false;
	public bool canSell = false;
	public bool canTalk =false;
	public bool canInteract= false;
	public bool busyInteracting =false;
	public bool waitingForQuest=false;
	public bool readyForQuest=false;
	public GameObject questTextContainer;
	public GameObject player;
	public List <Quest> quests;
	public Quest currentQuest;
	PlayerInteractions playerInteractions;
	GameObject QuestSection;
	Text talkText;
	int contTalk = 0;

	public string[] dialogs_spanish;
	string[] dialogs;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");		
		playerInteractions = player.transform.Find("Quest").GetComponent <PlayerInteractions>();
		talkText= (Text) questTextContainer.transform.Find("QuestTextPanel/Text").GetComponent <Text>();
		dialogs =dialogs_spanish;
		if(hasQuest)
		{
			transform.Find("QuestSection/Give").gameObject.SetActive(true);
			/*Debug.Log(asd);
			asd.gameObject.SetActive(true);*/
		}
	}
	public void StartInteracting()
	{
		
		if(hasQuest)
		{
			if(waitingForQuest)
				StartWaitingQuestTalk();
			else	
				if(readyForQuest)
					StartRewardQuestTalk();
				else	
					StartQuestTalk();
		}
		else
		{
			if(canTalk)
			{
				startTalking();
			}
		}		
	}
	public void startTalking()
	{
		questTextContainer.active=true;
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs =dialogs_spanish;
		talkText.text=dialogs[0];
		contTalk=0;
	}
	public void StartWaitingQuestTalk()
	{
		questTextContainer.active=true;
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs=currentQuest.questTextWaiting;
		talkText.text=dialogs[0];
		contTalk=0;
	}
	public void StartRewardQuestTalk()
	{
		questTextContainer.active=true;
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs=currentQuest.questTextReward;
		talkText.text=dialogs[0];
		contTalk=0;
	}
	public void StartQuestTalk()
	{		
		currentQuest = quests[0].GetComponent <Quest>();
		currentQuest.setQuestGiver(this);
		questTextContainer.active=true;
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs=currentQuest.questTextInit;
		talkText.text=dialogs[0];
		contTalk=0;
	}
	public void interactNext()
	{
		contTalk++;

		if(contTalk>=dialogs.Length)
		{
			if(readyForQuest)
			{
				waitingForQuest=false;
				finishQuest();
			}
			else
				if(hasQuest)
				{
					waitingForQuest=true;
					playerInteractions.setQuest(currentQuest);
				}
			shut();
		}
		else
		{
			talkText.text=dialogs[contTalk];
		}
	}

	void shut()
	{
		questTextContainer.active=false;
		busyInteracting= false;
		playerInteractions.StopInteracting();
	}
	//when player finish the current quest	
	public void QuestReady()
	{
		readyForQuest= true;
		waitingForQuest = false;
		transform.Find("QuestSection/Give").gameObject.SetActive(false);
		transform.Find("QuestSection/Get").gameObject.SetActive(true);
	}
	void finishQuest()
	{
		readyForQuest = false;
		Debug.Log("finishQuest");
		quests.RemoveAt(0);
		if(quests.Count==0)
		{
			hasQuest=false;
		}
		transform.Find("QuestSection/Get").gameObject.SetActive(false);
	}
}