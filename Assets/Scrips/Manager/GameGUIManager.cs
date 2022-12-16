using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{

    public Text scoreText;

    public Text treasureText;


    public override void Awake()
    {
        MakeSingleton(false);
    }


    public void UpdateScore(int score)
    {
        if(scoreText && treasureText)
        {
            scoreText.text = score.ToString();

            treasureText.text = score.ToString();
        }    
    }

}
