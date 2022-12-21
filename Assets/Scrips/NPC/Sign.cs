using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject infoCanvas;

    public bool canvasActive;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && canvasActive)
        {
            if(infoCanvas.activeInHierarchy)
            {
                infoCanvas.SetActive(false);
            }

            else
            {
                infoCanvas.SetActive(true);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canvasActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasActive = false;

            infoCanvas.SetActive(false);
        }
    }


}
