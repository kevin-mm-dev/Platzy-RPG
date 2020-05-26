using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumenController[] audios;
    public float maxVolumeLevel;
    public float currentVolumeLevel;


    void Start()
    {
        audios = FindObjectsOfType<AudioVolumenController>();
        ChangeGlobalAudioVolume();
    }

    private void Update()
    {
        ChangeGlobalAudioVolume();
    }

    public void ChangeGlobalAudioVolume()
    {
        if(currentVolumeLevel >= maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        foreach(AudioVolumenController avc in audios)
        {
            avc.SetAudioLevel(currentVolumeLevel);
        }

    }
}
