using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangagerScripts2 : MonoBehaviour
{

    public static AudioClip playerAttackSound;
    public static AudioClip treasureDestroySound;
    public static AudioClip collectCoin;
    public static AudioClip enemyDead;
    

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
 
        playerAttackSound = Resources.Load<AudioClip>("PlayerAttack");
        treasureDestroySound = Resources.Load<AudioClip>("TreasureDestroySound");
        collectCoin = Resources.Load<AudioClip>("CollectCoin");
        enemyDead = Resources.Load<AudioClip>("EnemyDead");



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
 
            case "PlayerAttack":
                audioSrc.PlayOneShot(playerAttackSound);
                break;

            case "TreasureDestroySound":
                audioSrc.PlayOneShot(treasureDestroySound);
                break;
            case "CollectCoin":
                audioSrc.PlayOneShot(collectCoin);
                break;
            case "EnemyDead":
                audioSrc.PlayOneShot(enemyDead);
                break;

        }
    }


}
