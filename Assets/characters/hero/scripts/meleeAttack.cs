using UnityEngine;
using System.Collections;

public class meleeAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	// Use this for initialization

	Animator anim;
	GameObject player;
	EnemyHealth enemyHealth;
	bool enemyInRange;
	GameObject enemy;	
	float timer;
	
	void Awake () {		
		player = GameObject.FindGameObjectWithTag("Player");		
		//anim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="atacable")
		{
			enemy = other.gameObject;
			enemyInRange= true;
			enemyHealth = enemy.GetComponent<EnemyHealth>();
		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			enemyInRange = false;
		}
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && enemyInRange)
		{			
			Attack();
		}

		if(enemyHealth.currentHealth <=0)
		{
			//anim.setTrigger("playerDead");
		}
	}

	void Attack()
	{
		timer = 0f;
		//enemy.GetComponent<Rigidbody>().AddForce(player.forward*2000);
		if( enemyHealth.currentHealth > 0)
		{
			enemyHealth.TakeDamage(attackDamage);
			
		}
	}
}
