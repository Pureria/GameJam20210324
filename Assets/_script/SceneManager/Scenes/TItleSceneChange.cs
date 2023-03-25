using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TItleSceneChange : SceneChange
{
    public void TitleNextSceneChange()
    {
        if (SceneEnd.isEnd)
        {
            base.ClickSceneChange();
        }
    }
}
