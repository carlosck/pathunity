using UnityEngine;
using System.Collections;

public class defendTerritory : MonoBehaviour {

	public float timeBetweenRuns = 0.5f;
	public int attackDamage = 10;
	// Use this for initialization
	
	GameObject player;	
	
	float timer;
	
	void Awake () {		
		player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		
		if(other.gameObject == player)
		{			
			gameObject.GetComponentInParent<whogBehavior>().startDefend(other);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{			
			gameObject.GetComponentInParent<whogBehavior>().stopDefend(other);
		}
	}
	// Update is called once per frame
	
}
