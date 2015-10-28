using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Text HealthTextPercent;

	Animator anim;
	bool isDead;
	bool damaged;

	void Awake()
	{
		anim = GetComponent <Animator>();
		currentHealth = startingHealth;		
	}

	void Update()
	{
		
	}

	public void TakeDamage(int amount)
	{
		Debug.Log("TakeDamage");
		damaged = true;
		currentHealth -= amount;
		HealthTextPercent.text = currentHealth.ToString() + '%';
		healthSlider.value = currentHealth;
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