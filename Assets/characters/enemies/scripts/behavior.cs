using UnityEngine;
using System.Collections;

public class behavior : MonoBehaviour {

	
	
	// Use this for initialization

	public Animator anim;
	GameObject player;

	PlayerHealth playerHealth;
	HealthSystem health;
	bool playerInRange;
	bool running = false;
	bool tired = false;
	NavMeshAgent agent;
	Vector3 playerTemporalPosition ;
	float tiredTime;
	bool facing_left= false;
	
	void Awake () {		
		
	}
	
	public void startDefend(Collider other)
	{
		
	}
	
	public void stopDefend(Collider other)
	{		
		
		
	}
	// Update is called once per frame
	void Update () {
		
		
		
		
		 
		 
	}
	void checkPosition()
	{
		
	}
	void updateAnim()
	{
		 
	}
	void RunToTarget()
	{
		
		
	}
	
	public void Die()
	{

	}
}