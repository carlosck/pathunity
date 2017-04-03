using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {

	public GameObject container;
	UIActions ps;
	public GameObject introVideo;
		
	// Use this for initialization
	void Awake () {
		//introVideo.SetActive(true);		
		ps= container.GetComponent<UIActions>();
	}
		
	

	void endIntroVideo()
	{
		ps.hideIntro();		
	}

}
