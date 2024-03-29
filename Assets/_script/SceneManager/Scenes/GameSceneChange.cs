using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneChange : SceneChange
{
    private void Update()
    {
        if(!fadeinOut.fadeOut)
        {
            fadeinOut.isEndFadeOut = false;
            if (Player.dead)
            {
                sceneName = "GameOverScene";
                ClickSceneChange();
            }

            if (Player.goal)
            {
                sceneName = "GameClearScene";
                ClickSceneChange();
            }
        }        
    }
}
