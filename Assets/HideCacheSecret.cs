using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCacheSecret : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<MusicManagerLvl1>().backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FindObjectOfType<MusicManagerLvl1>().secretMusic.start();
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<MusicManagerLvl1>().secretMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FindObjectOfType<MusicManagerLvl1>().backgroundMusic.start();
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
