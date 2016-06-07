using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	// Use this for initialization

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	
	void Awake () {		
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		//anim = GetComponent<Animator>();
		anim = transform.Find("animContainer/animations").GetComponent <Animator>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject == player)
		{			
			playerInRange = true;
			anim.SetBool("close_to_player",true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
			anim.SetBool("close_to_player",false);
		}
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && playerInRange)
		{			
			Attack();
		}

		if(playerHealth.currentHealth <=0)
		{
			//anim.setTrigger("playerDead");
		}
	}

	void Attack()
	{
		timer = 0f;
		
		if( playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage(attackDamage);
		}
	}
}
