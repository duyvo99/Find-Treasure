using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{

    public GameObject infoPlayerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        infoPlayerCanvas.SetActive(false);
    }

    public void OpenInfoPlayerCanvas()
    {
        infoPlayerCanvas.SetActive(true);
    }

    public void CloseInfoPlayerCanvas()
    {
        infoPlayerCanvas.SetActive(false);
    }
}
