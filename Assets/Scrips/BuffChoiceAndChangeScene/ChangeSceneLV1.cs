using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeSceneLV1 : MonoBehaviour
{
    float changeTime = 7;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;

        if (changeTime <= 0)
        {
            SceneManager.LoadScene("SceneInGame");
        }
    }
}
