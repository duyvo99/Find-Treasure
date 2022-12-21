using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SoundVolumeMainMenu : MonoBehaviour
{
    private AudioSource AudioSource;

    private float MusicVolume = 0.5f;

    public Slider volumeSlider;



    public GameObject ObjectMusic;



    // Start is called before the first frame update
    private void Start()
    {

        volumeSlider.value = 0.5f;

        ObjectMusic = GameObject.FindWithTag("MusicVolumeMainMenu");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();



        MusicVolume = PlayerPrefs.GetFloat("volume", 0.5f);

        MusicVolume = volumeSlider.value;

        AudioSource.volume = volumeSlider.value;

    }

    // Update is called once per frame
    private void Update()
    {

        AudioSource.volume = volumeSlider.value;

        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void UpdateVolume(float volume)
    {
        MusicVolume = volume;
    }
}
