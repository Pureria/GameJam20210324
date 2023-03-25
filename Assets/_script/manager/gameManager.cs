using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static bool half;
    public static bool goal;
    public static bool death;

    private void Update()
    {
        goal = Player.goal;
        death = Player.dead;

        if ((goal || death) && !fadeinOut.isEndFadeOut)
        {
            fadeinOut.fadeOut = true;
        }
    }
}
