using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	

	Animator anim;
	bool isDead;
	bool damaged;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake()
	{
		anim = GetComponent <Animator>();
		currentHealth = startingHealth;		
	}
	

	public void TakeDamage(int amount)
	{
		
		damaged = true;
		currentHealth -= amount;
		Debug.Log("tengo "+currentHealth+" de vida");
		//HealthTextPercent.text = currentHealth.ToString() + '%';
		//healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death();
		}
	}

	void Death()
	{
		isDead = true;
	}
}
