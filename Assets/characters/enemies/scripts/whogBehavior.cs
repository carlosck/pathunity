using UnityEngine;
using System.Collections;

public class whogBehavior : behavior {

	public float timeBetweenRuns = 5f;
	
	// Use this for initialization

	
	GameObject player;

	PlayerHealth playerHealth;
	HealthSystem health;
	bool playerInRange;
	bool running = false;
	bool tired = false;
	UnityEngine.AI.NavMeshAgent agent;
	Vector3 playerTemporalPosition ;
	float tiredTime;
	bool facing_left= false;
	
	void Awake () {		
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		agent =GetComponent <UnityEngine.AI.NavMeshAgent>();
		//anim = GetComponent<Animator>();
		anim = transform.Find("animContainer/animations").GetComponent <Animator>();
		health = GetComponent <HealthSystem>();
	}
	
	public void startDefend(Collider other)
	{
		playerInRange = true;
		anim.SetBool("close_to_player",true);
	}
	
	public void stopDefend(Collider other)
	{		
		playerInRange = false;
		anim.SetBool("close_to_player",false);
		if(facing_left)
			anim.SetInteger("Direction", 7);
		else
			anim.SetInteger("Direction", 3);
		
	}
	// Update is called once per frame
	void Update () {
		tiredTime += Time.deltaTime;
		if(playerHealth.currentHealth<=0 && health.currentHealth>0)
		{
			agent.Stop();
			if(facing_left)
				anim.SetInteger("Direction", 7);
			else
				anim.SetInteger("Direction", 3);
		}
		if(health.currentHealth<=0)
		{
			agent.Stop();
			Die();
		}
		else
		{
			checkPosition();
			updateAnim();
		}
		
		
		
		
		 
		 
	}
	void checkPosition()
	{
		if(tiredTime >= timeBetweenRuns) 
		{
			
			tired= false;
		}
		
		if (Vector3.Distance(transform.position, playerTemporalPosition)<0.5 && running)
		{
			running= false;
			tired=true;
			tiredTime = 0f;
		}

		if( playerInRange && !running && !tired)
		{			
			RunToTarget();
		}
	}
	void updateAnim()
	{
		 Vector3 velocity = agent.velocity;
		 
		if(Mathf.Abs(velocity.x) > Mathf.Abs(velocity.z))
		 {
		  if(velocity.x > 0 )
			{
				anim.SetInteger("Direction", 4);				
				facing_left = false;
		  }
			if(velocity.x < 0 )
		  {
		   anim.SetInteger("Direction", 8);		   
			  facing_left = true;
		  }
		 }
			else
			{
				if(velocity.z > 0 )
				{
					anim.SetInteger("Direction", 2);					
					facing_left = true;
				}
				if(velocity.z < 0 )
				{
					anim.SetInteger("Direction", 6);					
					facing_left = true;
				} 
		}
		 
		 
		 if(velocity.z==0 && velocity.x==0)
		 {
		  if(facing_left)
				anim.SetInteger("Direction", 7);
			else
				anim.SetInteger("Direction", 3);

		 }
	}
	void RunToTarget()
	{
		if(playerHealth.currentHealth>=0)
		{
			running= true;
			playerTemporalPosition= player.transform.position;
			agent.SetDestination(playerTemporalPosition);
		}
		
	}
	void Die()
	{
		if(facing_left)
	    {
	    	anim.SetBool("is_dead_left", true);
	    }
	    else
	    {
	    	anim.SetBool("is_dead_right", true);
	    }
	}
}
