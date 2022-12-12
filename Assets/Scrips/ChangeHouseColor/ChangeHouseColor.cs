using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class ChangeHouseColor : MonoBehaviour
{

    private Tilemap tileMap;


    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Color newColor = new Color(1f, 1f, 1f, 0.3f);

            tileMap.color = newColor;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Color newColor = new Color(1f, 1f, 1f, 1f);

            tileMap.color = newColor;
        }
    }

}
