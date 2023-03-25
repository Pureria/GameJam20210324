using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSceneChange : SceneChange
{
    public void GameClearNextSceneChange()
    {
        if (SceneEnd.isEnd)
        {
            base.ClickSceneChange();
        }
    }
}
