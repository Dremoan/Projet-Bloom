using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOtherScene : MonoBehaviour {

	public GameObject clouds1;
	public GameObject clouds2;
	public Animator anim;
	public string sceneName;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			clouds1.SetActive (false);
			clouds2.SetActive (false);
			anim.Play ("BecomingBlack");
		}
	}

	void LoadScene()
	{
		SceneManager.LoadScene (sceneName);
	}
}
