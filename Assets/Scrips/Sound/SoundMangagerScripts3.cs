using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangagerScripts3 : MonoBehaviour
{
    public static AudioClip playerDie;
    public static AudioClip playerRevivel;


    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerDie = Resources.Load<AudioClip>("PlayerDie");
        playerRevivel = Resources.Load<AudioClip>("PlayerRevivel");

        audioSrc = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "PlayerDie":
                audioSrc.PlayOneShot(playerDie);
                break;

            case "PlayerRevivel":
                audioSrc.PlayOneShot(playerRevivel);
                break;
        }
    }
}
