using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {

	public GameObject container;
	UIActions ps;
	public GameObject introVideo;
	MovieTexture mt;
	public GameObject fadeObj ;
	// Use this for initialization
	void Awake () {
		//introVideo.SetActive(true);
		RawImage rim = introVideo.GetComponent<RawImage>();
		mt = (MovieTexture)rim.mainTexture;		
		ps= container.GetComponent<UIActions>();
	}
		

	void Start()
	{
		mt.Play();
		StartCoroutine(FindEnd());
	}
	private IEnumerator FindEnd()
	{
		while(mt.isPlaying)
		{
		yield return 0;
		}

		endIntroVideo();
		yield break;
	}

	void endIntroVideo()
	{
		StartCoroutine(cortinilla());
	}
	IEnumerator cortinilla()
	{	
		
		Instantiate(fadeObj, new Vector3(0, 0, 0), Quaternion.identity); // The Instantiate command takes a GameObject, a Vector3 for position and a Quaternion for rotation.  		
		ps.hideIntro();
		yield return new WaitForSeconds(1f);
		
	}
}
