using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    private float nowTime;
    private float startTime;
    private Image image;
    private bool fadeIn;
    private bool fadeOut;

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

    private void Start()
    {
        image = GetComponent<Image>();
        fadeIn = true;
        fadeOut = false;

        image.color = new Color(0,0,0,255);
    }

    private void Update()
    {
        nowTime = Time.time;
        if(fadeIn)
        {
            if (image.color.a == 255)
                startTime = Time.time;

            float alpha = Animation(startTime, startTime + fadeTime, 254, 0, nowTime);
            Debug.Log(alpha);
            Color color = new Color(0, 0, 0, alpha);
            gameObject.GetComponent<Image>().color = color;

            if (color.a == 0)
                fadeIn = false;
        }

        if(fadeOut)
        {
            if (image.color.a <= 0)
                startTime = Time.time;

            Color color = new Color(0, 0, 0, Animation(startTime, startTime + fadeTime, 0, 255, nowTime));
            image.color = color;

            if (color.a >= 255)
                fadeOut = false;
        }
    }

    public void StartFadeIn() => fadeIn = true;
    public void StartFadeOut() => fadeOut = true;
    public bool GetFadeIn() { return fadeIn; }
    public bool GetFadeOut() { return fadeOut; }
}
