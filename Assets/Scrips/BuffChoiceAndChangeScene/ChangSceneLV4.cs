using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangSceneLV4 : MonoBehaviour
{

    float changeTime = 16;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;

        if(changeTime <= 0 )
        {
            SceneManager.LoadScene("Level4");
        }
    }
}
