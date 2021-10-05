using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioSource[] audiosOnScene;
    public Slider slid;

    private void Start()
    {
        audiosOnScene = FindObjectsOfType<AudioSource>();
    }

    public void ChangeSliderValue()
    {
        for (int i = 0; i < audiosOnScene.Length; i++)
        {
            audiosOnScene[i].volume = slid.value;
        }
    }
}
