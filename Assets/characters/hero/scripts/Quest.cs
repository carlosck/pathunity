using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest: MonoBehaviour
{
	public bool completed=false;
	public string[] questTextInit;
	public string[] questTextWaiting;
	public string[] questTextReward;
	GameObject[] enemys;
	public GameObject[] objects;
	NPCInteract questGiver;

	public GameObject reward;

	public void init()
	{		
		gameObject.SetActive(true);
		Debug.Log(transform.parent);
		//questGiver=
	}
	
	public void setQuestGiver(NPCInteract qg)
	{
		questGiver= qg;
	}

	public NPCInteract getQuestGiver()
	{
		return questGiver;
	}
	

}