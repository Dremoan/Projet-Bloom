using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSection3 : MonoBehaviour {

	public GameObject triggerSection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D () 
	{
		FindObjectOfType<MusicManagerTuto> ().toSection3.setValue(1f);
		FindObjectOfType<MusicManagerTuto> ().outGrotte.setValue(1f);
		triggerSection.SetActive (false);
	}
}
