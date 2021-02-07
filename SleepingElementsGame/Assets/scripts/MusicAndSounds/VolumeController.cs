using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{

    private AudioSource[] audioSrc;

    private float musicVol;

    // Start is called before the first frame update
    void Start()
    {

        musicVol = 1;
        audioSrc = GetComponents<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audioSrc.Length; i++)
        {

            audioSrc[i].volume = musicVol;

        }
    }


    public void ChangeVolume(float vol)
    {

        musicVol = vol;

    }
}
