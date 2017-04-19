using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	Slider healthSlider;
	public Text HealthTextPercent;
	public int defense = 0;

	Animator anim;
	bool isDead;
	bool damaged;
	public Transform show_damage;
	GameObject damage_enemy;
	public QuestContainer quest_container;
	Transform enemy_transform;
	SpriteRenderer renderer;
	CharacterMotor characterMotor;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake()
	{
		enemy_transform= GetComponent<Transform>();	
		anim = transform.Find("animContainer/animations").GetComponent <Animator>();
		characterMotor = GetComponent<CharacterMotor>();
		//questManager = GameObject.FindGameObjectWithTag("Player").GetComponent <QuestManager>();
		anim.speed= Random.Range(0.8f,1.2f);
		healthSlider = transform.Find("Canvas/HealtSlider").GetComponent <Slider>();
		healthSlider.maxValue = startingHealth;
		currentHealth = startingHealth;	
		HealthTextPercent.text = currentHealth.ToString() ;
		damage_enemy = (GameObject)Resources.Load ("prefabs/damage_enemy", typeof(GameObject));
		renderer = transform.Find("animContainer/animations").GetComponent <SpriteRenderer>();
		
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
			StartCoroutine(showRed());
			

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
		anim.SetInteger("Direction", 0);
		characterMotor.Die();
		
		bool isPartOfaQuest= quest_container.enemyKilled(gameObject);
		
		//if(!isPartOfaQuest)
			Destroy(this.gameObject,2f);		
	}

	void ShowDamage(int amount)
	{
		var pos= enemy_transform.position;		

		var show_dmg = (GameObject) Instantiate(damage_enemy, pos, Quaternion.identity);
		//var show_dmg = (Transform) Instantiate(show_damage, pos, Quaternion.identity);
		
		Text dmg_txt = (Text) show_dmg.transform.Find("GameObject/Canvas/Text").GetComponent <Text>();
		dmg_txt.text= amount+" "; 
		Destroy(show_dmg.gameObject,1.1f);
	}
	
	IEnumerator showRed()
	{		
		renderer.color = new Color(1f, 0f, 0f, 1f);
		yield return new WaitForSeconds(0.5f);
		renderer.color = new Color(1f, 1f, 1f, 1f);		
    }

}