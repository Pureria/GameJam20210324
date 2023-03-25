using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TimerSpriteScript timer1;
    [SerializeField] private TimerSpriteScript timer2;
    [SerializeField] private TimerSpriteScript timer3;
    [SerializeField] private TimerSpriteScript timer4;

    [SerializeField] private int maxTime = 100;

    private float elapsedTime;
    private int time;

    private int nowTime;
    private float timeElapsed = 0.0f;

    private void Start()
    {
        timer1.SetNowNumbers(0);
        timer2.SetNowNumbers(0);
        timer3.SetNowNumbers(0);
        timer4.SetNowNumbers(0);
    }

    private void Update()
    {
        if(Player.gameStart && !Player.dead && !Player.goal)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 1.0f)
            {
                timeElapsed = 0.0f;
                time += 1;
            }
        }

        if (time > maxTime)
        {
            Player.dead = true;
            return;
        }

        nowTime = maxTime - time;

        int minuteTime = nowTime / 60;
        int secoundTime = nowTime - minuteTime * 60;
        nowTime -= minuteTime * 60;

        if (minuteTime > 9)
        {
            timer1.SetNowNumbers(minuteTime / 10);
            timer2.SetNowNumbers(minuteTime - (minuteTime / 10) * 10);
        }
        else
        {
            timer1.SetNowNumbers(0);
            timer2.SetNowNumbers(minuteTime);
        }

        if(secoundTime > 9)
        {
            timer3.SetNowNumbers(secoundTime / 10);
            timer4.SetNowNumbers(secoundTime - (secoundTime / 10) * 10);
        }
        else
        {
            timer3.SetNowNumbers(0);
            timer4.SetNowNumbers(secoundTime);
        }
    }
}
