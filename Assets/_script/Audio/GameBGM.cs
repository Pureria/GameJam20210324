using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    public AudioClip newClip;

    private AudioSource audioSource;
    private bool bgm2;

    private float startTime;
    [SerializeField] float fadeTime = 1.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bgm2 = false;
    }

    void Update()
    {
        if (gameManager.half && !bgm2)
        {
            startTime = Time.time;
            bgm2 = true;

            /*
            audioSource.clip = newClip;
            audioSource.Play();
            */
        }
        else if(gameManager.half && audioSource.clip != newClip)
        {
            audioSource.volume = Animation(startTime,startTime + fadeTime,0.2f,0.0f,Time.time);

            if (audioSource.volume <= 0)
            {
                audioSource.clip = newClip;
                startTime = Time.time;
                audioSource.Play();
            }
        }

        if(audioSource.clip == newClip && audioSource .volume < 0.2f)
        {
            audioSource.volume = Animation(startTime, startTime + fadeTime, 0.0f, 0.2f, Time.time);
        }
    }

    float Animation(float startTime, float endTime, float startKey, float endKey, float time)
    {
        float animationTime = endTime - startTime;
        float animationValue = endKey - startKey;

        float t = (time - startTime) / animationTime;
        if (t < 0)
            t = 0;
        else if (t > 1)
            t = 1;

        return startKey + animationValue * t;
    }
}
