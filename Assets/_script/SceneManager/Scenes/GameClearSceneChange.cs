using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSceneChange : SceneChange
{
    [SerializeField] private AudioSource audio;
    bool flg;

    private void Start()
    {
        flg = false;
    }

    private void Update()
    {
        if (flg && !audio.isPlaying)
        {
            base.ClickSceneChange();

            Player.gameStart = false;
            Player.goal = false;
            Player.dead = false;
        }
    }
    public void GameClearNextSceneChange()
    {
        if (audio.isPlaying)
        {
            flg = true;
        }
    }
}
