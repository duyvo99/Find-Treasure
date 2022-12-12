using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalPlayer : MonoBehaviour
{

    ////REVIVAL PLAYER
    public GameObject revivalPlayerPanel;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ////REVIVAL PLAYER
        if (PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer <= 0)
        {

            //Time.timeScale = 0f;
            player.SetActive(false);


            revivalPlayerPanel.SetActive(true);

            
        }
    }


    ////REVIVAL PLAYER
    public void RevivalPlayerOkButton()
    {
        revivalPlayerPanel.SetActive(false);

        //Time.timeScale = 1f;
        player.SetActive(true);

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer = 100;
        //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer = 100;

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentManaPlayer = 200;
        //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer = 200;
    }
}
