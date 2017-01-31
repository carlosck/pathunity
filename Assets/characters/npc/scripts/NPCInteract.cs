using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class NPCInteract : MonoBehaviour
{
	public bool hasQuest = false;
	public bool startAQuest = false;
	public bool endAQuest = false;
	public bool canSell = false;
	public bool canTalk =false;
	public bool canInteract= false;
	public bool busyInteracting =false;
	public bool waitingForQuest=false;
	public bool readyForTurnQuest=false;
	public string NPCName;
	public GameObject questTextContainer;
	public GameObject player;
	public List <Quest> quests;
	public Quest currentQuest;	
	public QuestContainer gameQuestContainer;
	PlayerInteractions playerInteractions;
	GameObject QuestSection;
	Text talkText;
	Text name;
	Text nameShadow;
	int contTalk = 0;

	public string[] dialogs_spanish;
	string[] dialogs;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");		
		playerInteractions = player.transform.Find("QuestInteract").GetComponent <PlayerInteractions>();
		talkText= (Text) questTextContainer.transform.Find("QuestTextPanel/Text").GetComponent <Text>();
		nameShadow= (Text) questTextContainer.transform.Find("QuestTextPanel/nombre_pj_shadow").GetComponent <Text>();
		name= (Text) questTextContainer.transform.Find("QuestTextPanel/nombre_pj").GetComponent <Text>();
		dialogs =dialogs_spanish;
		checkForQuest();
	}
	public void checkForQuest()
	{
		if(hasQuest)
		{
			transform.Find("QuestSection/Give").gameObject.SetActive(true);
			currentQuest= quests[0];
			//waitingForQuest= false;
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
				if(readyForTurnQuest)
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
		questTextContainer.SetActive(true);
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs =dialogs_spanish;
		talkText.text=dialogs[0];
		name.text= NPCName;
		nameShadow.text= NPCName;
		contTalk=0;
	}
	public void StartWaitingQuestTalk()
	{
		questTextContainer.SetActive(true);
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs=currentQuest.questTextWaiting;
		talkText.text=dialogs[0];
		name.text= NPCName;
		nameShadow.text= NPCName;
		contTalk=0;
	}
	public void StartRewardQuestTalk()
	{
		questTextContainer.SetActive(true);
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs=currentQuest.questTextReward;
		talkText.text=dialogs[0];
		name.text= NPCName;
		nameShadow.text= NPCName;
		contTalk=0;
	}
	public void StartQuestTalk()
	{		
		currentQuest = quests[0].GetComponent <Quest>();
		currentQuest.setQuestGiver(gameObject);
		GameObject qr= currentQuest.questReceiver;
		//si el mismo quien da la quest y quien la recibe
		if(qr==null)
		{
			
			currentQuest.setQuestReceiver(gameObject);//.GetComponent <NPCInteract>()			
		}
		else
		{
			currentQuest.setQuestReceiver(currentQuest.questReceiver);			
		}
		
		questTextContainer.SetActive(true);
		playerInteractions.StartInteracting();
		busyInteracting= true;
		dialogs=currentQuest.questTextInit;
		talkText.text=dialogs[0];
		name.text= NPCName;
		nameShadow.text= NPCName;
		contTalk=0;
	}
	public void interactNext()
	{
		contTalk++;

		if(contTalk>=dialogs.Length)
		{
			if(readyForTurnQuest)
			{
				waitingForQuest=false;
				playerInteractions.finishQuest(currentQuest);
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
		questTextContainer.SetActive(false);
		busyInteracting= false;
		playerInteractions.StopInteracting();
	}
	//when player finish the current quest	
	public void QuestReady()
	{
		Debug.Log("QuestReady");
		readyForTurnQuest= true;
		waitingForQuest = false;
		transform.Find("QuestSection/Give").gameObject.SetActive(false);
		transform.Find("QuestSection/Get").gameObject.SetActive(true);
	}
	public void finishQuest()
	{
		Quest quest= currentQuest;
		readyForTurnQuest = false;
		Debug.Log("finishQuest");	

		GameObject qg = quest.getQuestGiver();
		GameObject qr = quest.getQuestReceiver();
				
		if(qg.GetInstanceID()!= gameObject.GetInstanceID())
		{
			qg.GetComponent <NPCInteract>().finishQuest();
			Debug.Log("no son iguales");
			//qr.GetComponent <NPCInteract>().quests.RemoveAt(0);
			//qr.Find("QuestSection/Give").gameObject.SetActive(false);
		}
		else
		{
			Debug.Log("son iguales");
		}
		quests.RemoveAt(0);
		transform.Find("QuestSection/Give").gameObject.SetActive(false);
		transform.Find("QuestSection/Get").gameObject.SetActive(false);
		if(quests.Count==0)
		{
			hasQuest=false;
		}
		else
		{
			checkForQuest();
		}

		gameQuestContainer.nextQuest();
		
	}

	public void setTurnQuest(Quest quest)
	{
		Debug.Log("setTurnQuest");
		
		quests.Insert(0,quest);
		currentQuest= quest;
		hasQuest= true;		
		readyForTurnQuest= true;
	}
	public void addQuest(Quest quest)
	{
		quests.Add(quest);
		hasQuest= true;
		waitingForQuest= true;
		checkForQuest();
	}
}