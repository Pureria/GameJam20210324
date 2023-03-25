using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    public AudioClip newClip;

    private AudioSource audioSource;
    private bool bgm2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bgm2 = false;
    }

    void Update()
    {
        if (gameManager.half && !bgm2)
        {
            bgm2 = true;
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}
