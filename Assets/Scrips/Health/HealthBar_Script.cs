using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{

    private Image healthBar;

    public float currentHealth = 100f;

    private float MaxHealth = 100f;


    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        //currentHealth = player.health;

        healthBar.fillAmount = currentHealth / MaxHealth;
    }
}
