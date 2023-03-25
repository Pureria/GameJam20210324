using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeinOut : MonoBehaviour
{

    public static bool fadeIn;
    public static bool fadeOut;
    public static bool isEndFadeOut;
    private bool checkStartTime;
    [SerializeField] private Image image;
    private float startTime;
    [SerializeField] private float fadeTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn = true;
        fadeOut = false;
        startTime = 0;
        image.color = new Color(0, 0, 0, 1);
        checkStartTime = false;
        isEndFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (!checkStartTime)
            {
                startTime = Time.time;
                checkStartTime = true;
            }
            float alpha = Animation(startTime, startTime + fadeTime, 1.0f, 0.0f, Time.time);
            image.color = new Color(0, 0, 0, alpha);

            if (image.color.a <= 0)
            {
                fadeIn = false;
                checkStartTime = false;
            }
        }

        if (fadeOut)
        {
            if (!checkStartTime)
            {
                startTime = Time.time;
                checkStartTime = true;
            }

            float alpha = Animation(startTime, startTime + fadeTime, 0.0f, 1.0f, Time.time);
            image.color = new Color(0, 0, 0, alpha);

            if (image.color.a >= 1)
            {
                fadeOut = false;
                checkStartTime = false;
                isEndFadeOut = true;
            }
        }


    }

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

    public void startFadeOut() => fadeOut = true;
}
