using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnermyState
{
    idle,

    walk,

    attack,

    stagger
}


public class EnermyAI : MonoBehaviour
{

    public EnermyState currentState;

    //public int health;

    public string enermyName;

    public int baseAttack;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
