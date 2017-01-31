using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest: MonoBehaviour
{
	public bool completed=false;
	public GameObject playerStartAt;
	public string[] questTextInit;
	public string[] questTextWaiting;
	public string[] questTextReward;
	GameObject[] enemys;
	public GameObject[] objects;
	public bool isGoToTalkSomeone;
	public GameObject questGiver;
	public GameObject questReceiver= null;
	public GameObject cam;

	public GameObject reward;

	public void init()
	{		
		gameObject.SetActive(true);
	}
	
	public void setQuestGiver(GameObject qg)
	{
		questGiver= qg;
	}

	public void setQuestReceiver(GameObject qr)
	{
		questReceiver= qr;
	}

	public GameObject getQuestGiver()
	{
		return questGiver;
	}

	public GameObject getQuestReceiver()
	{
		return questReceiver;
	}
	public GameObject getInitPosition()
	{
		return playerStartAt;
	}
	public GameObject getCam()
	{
		return cam;
	}
	

}