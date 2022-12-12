using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class LightChangeCode : MonoBehaviour
{

    public Slider slider;

    public Light2D sceneLight;

    private float lightNumber = 1f;

    // Start is called before the first frame update
    void Start()
    {
        lightNumber = PlayerPrefs.GetFloat("light", 1);

        sceneLight.intensity = lightNumber;

        slider.value = lightNumber;
    }

    // Update is called once per frame
    void Update()
    {
        sceneLight.intensity = lightNumber;

        PlayerPrefs.SetFloat("light", lightNumber);

    }


    public void UpdateLight(float light)
    {
        lightNumber = light;
    }
}
