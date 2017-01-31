using UnityEngine;
using System.Collections;
using System;

public class IntroManager : MonoBehaviour {

	// Use this for initialization
	public GameObject container;	
	public main_menu ps;
	
	
	// Update is called once per frame
	void Awake() {
		ps= container.GetComponent<main_menu>();
	}
	
	public void endIntro()
	{
		ps.endIntroEscene();
	}
	
}
