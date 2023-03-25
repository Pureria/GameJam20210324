using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneChange : SceneChange
{
    public void GameNextSceneChange()
    {
        if (SceneEnd.isEnd)
        {
            base.ClickSceneChange();
        }
    }
}
