using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerWalkingSound;
    public static AudioClip playerAttackSound;
    public static AudioClip treasureDestroySound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerWalkingSound = Resources.Load<AudioClip>("PlayerWalking");
        //playerAttackSound = Resources.Load<AudioClip>("PlayerAttack");
        //treasureDestroySound = Resources.Load<AudioClip>("TreasureDestroySound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "PlayerWalking":
                audioSrc.PlayOneShot(playerWalkingSound);
                break;

            //case "PlayerAttack":
            //    audioSrc.PlayOneShot(playerAttackSound);
            //    break;
            //case "TreasureDestroySound":
            //    audioSrc.PlayOneShot(treasureDestroySound);
            //    break;
        }
    }

    public static void StopPlaySound()
    {
        audioSrc.Stop();
    }
}
