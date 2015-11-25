using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Text HealthTextPercent;
	public int defense = 0;
	Animator anim;
	bool isDead;
	bool damaged;	
	public Transform show_damage;
	GameObject player;
	Transform player_transform;

	void Awake()
	{
		anim = GetComponent <Animator>();
		currentHealth = startingHealth;	
		player = GameObject.FindGameObjectWithTag("Player");
		player_transform= player.GetComponent<Transform>();
		//childObject.transform.parent.gameObject	
	}

	void Update()
	{
		
	}

	public void TakeDamage(int amount)
	{
		if(isDead) {return ;}
		
		int total_damage = amount-defense;
		if(total_damage<=0)
			total_damage = 0;
		else
		{
			damaged = true;
			currentHealth -= total_damage;
		}
				
		ShowDamage(total_damage);	
		
		if(currentHealth>0)
		{
			
			HealthTextPercent.text = currentHealth.ToString() ;
			healthSlider.value = currentHealth;
		}
		else
		{
			HealthTextPercent.text = "0";
			healthSlider.value = 0;
			if(currentHealth <= 0 && !isDead)
			{
				Death();
			}
		}
	}

	void Death()
	{
		isDead = true;

	}
	void ShowDamage(int amount)
	{
		var pos= (Vector3) player.GetComponent<Transform>().position;
		
		
		var show_dmg = (Transform) Instantiate(show_damage, pos, Quaternion.identity);
		
		Text dmg_txt = (Text) show_dmg.transform.Find("GameObject/Canvas/Text").GetComponent <Text>();
		dmg_txt.text= amount+" "; 
		Destroy(show_dmg.gameObject,1.1f);

	}
}