using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerVillageHappy : MonoBehaviour
{

    public FMOD.Studio.EventInstance backgroundMusic;

    void Start()
    {
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance("event:/VILLAGE/FlowerTown");
        backgroundMusic.start();

    }
}


