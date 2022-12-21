using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusicLV4 : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicVolumeLV4");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
