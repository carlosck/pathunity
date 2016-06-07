using UnityEngine;
using System.Collections;

public class meleeAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	// Use this for initialization

	Animator anim;
	GameObject player;
	HealthSystem enemyHealth;
	CharacterMotor characterMotor;
	bool enemyInRange;
	private GameObject enemy;	
	float timer;
	
	void Awake () {		
		player = GameObject.FindGameObjectWithTag("Player");		
		characterMotor = player.GetComponent<CharacterMotor>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="atacable")
		{
			enemy = other.gameObject;
			enemyInRange= true;
			enemyHealth = enemy.GetComponent<HealthSystem>();

		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag=="atacable")
		{
			enemyInRange = false;
		}
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && enemyInRange && characterMotor.swording)
		{			
			Attack();
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
