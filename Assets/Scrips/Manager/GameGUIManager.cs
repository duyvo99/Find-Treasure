using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{

    public Text scoreText;


    public override void Awake()
    {
        MakeSingleton(false);
    }


    public void UpdateScore(int score)
    {
        if(scoreText)
        {
            scoreText.text = score.ToString();
        }    
    }

}
