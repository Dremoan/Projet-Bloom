using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerSadVillage : MonoBehaviour {

	public FMOD.Studio.EventInstance backgroundMusic;


	// Use this for initialization
	void Start () {
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance("event:/VILLAGE/Sad_Flowertown");
        backgroundMusic.start();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
