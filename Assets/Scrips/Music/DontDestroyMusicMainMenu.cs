using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusicMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicVolumeMainMenu");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}