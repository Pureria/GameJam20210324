using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{

    private AudioSource bgm;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        volume = bgm.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.range)
        {
            bgm.volume = volume * 0.5f;
        }
        else
        {
            bgm.volume = volume;
        }
    }
}
