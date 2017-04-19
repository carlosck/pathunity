using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteractions : MonoBehaviour
{
	GameObject NPC;
	GameObject player;
	NPCInteract NPCinteract;
	bool NPCInRange = false;
	CharacterMotor characterMotor;
	float timer;
	public QuestContainer quest_container;
	public float timeBetweenInteractions = 0.5f;
	List <Quest> quests;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		characterMotor = player.GetComponent<CharacterMotor>();
		//questManager=player.GetComponent<QuestManager>();
		//quests = new List<Quest>();
	}

	void OnTriggerEnter(Collider other)
	{		
		if(other.tag=="NPC")
		{			
			NPC = other.transform.parent.gameObject;				
			var NPCName = NPC.transform.Find("Name").GetComponent<Canvas>();
			NPCName.enabled = true;
			NPCinteract = NPC.GetComponent<NPCInteract>();			
			NPCInRange = true;
			characterMotor.InteractiveInRange = true;
		}		
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag=="NPC")
		{			
			NPC = other.transform.parent.gameObject;				
			var NPCName = NPC.transform.Find("Name").GetComponent<Canvas>();
			NPCName.enabled = false;
			NPCInRange = false;
			characterMotor.InteractiveInRange = false;
		}		
	}
	void Update()
	{
		timer += Time.deltaTime;

		if(NPCInRange && Input.GetKey("x") && NPCinteract.canInteract && timer >= timeBetweenInteractions)
		{
			Debug.Log("x");
			if(!NPCinteract.busyInteracting)
			{
				NPCinteract.StartInteracting();
			}
			else
			{
				NPCinteract.interactNext();	
			}

			timer = 0f;
			
		}
	}

	public void StartInteracting()
	{
		characterMotor.canControl= false;
	}

	public void StopInteracting()
	{
		characterMotor.canControl= true;
	}

	
}