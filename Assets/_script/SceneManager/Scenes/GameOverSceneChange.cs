using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneChange : SceneChange
{
    public void GameOverNextSceneChange()
    {
        if (SceneEnd.isEnd)
        {
            base.ClickSceneChange();
        }
    }
}
