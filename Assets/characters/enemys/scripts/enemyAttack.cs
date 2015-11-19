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
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("me pego:"+other.tag);
		if(other.gameObject == player)
		{			
			playerInRange = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
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
