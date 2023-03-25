using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    private AudioSource audioSource;

    private bool isAudioEnd;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickButtonSound()
    {
        isAudioEnd = true;
        SceneEnd.isEnd = true;
        
    }

}
